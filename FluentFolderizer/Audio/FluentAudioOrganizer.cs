using FluentFolderizer.DirectoryStructureValidators;
using FluentFolderizer.Results;
using FluentFolderizer.Tags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FluentFolderizer.Audio
{
    public partial class FluentAudioOrganizer : IValidatable
    {
        internal FluentAudioOrganizer() { }

        public void Validate()
        {
            if(BasePath is null)
                throw new InvalidOperationException("Failed to build the organizer. The location of the files to be organized must be given.");

            bool directoryStructureNotSet = _tagSequence.Count == 0;

            if (directoryStructureNotSet)
                throw new InvalidOperationException("Failed to build the organizer. The new desired directory structure must be given.");
        }
    }

    public partial class FluentAudioOrganizer : IOrganizer
    {
        public OrganizationResult Run()
        {
            var result = new OrganizationResult();
            var files = Directory.EnumerateFiles(BasePath);

            foreach (string file in files)
            {
                try
                {
                    this.OrganizeFileIntoNewLocation(file);
                }
                catch (Exception ex)
                {
                    result.AddFailure(file, ex);
                }
            }
            return result;
        }

        public Task<OrganizationResult> RunAsync()
        {
            return Task.Run(Run);
        }


        private void OrganizeFileIntoNewLocation(string file)
        {
            if (NotAudioFile(file))
                return;

            string finalDirectoryPath = GenerateNewDirectoryPath(filePath: file, MountingPath);
            string finalFilePath = Path.Combine(finalDirectoryPath, Path.GetFileName(file));

            Directory.CreateDirectory(finalDirectoryPath);

            if (this.HandlingMethod == FileHandling.Move)
            {
                File.Move(file, finalFilePath);
            }
            else
            {
                File.Copy(file, finalFilePath);
            }
        }

        private string GenerateNewDirectoryPath(string filePath, string mountingPath)
        {
            foreach (AudioTag tag in _tagSequence)
            {
                mountingPath = Path.Combine(mountingPath, GetTagValueFromFile(tag, filePath));
            }
            return mountingPath;
        }

        private string GetTagValueFromFile(AudioTag tag, string filePath)
        {
            TagLib.File file = TagLib.File.Create(filePath);

            switch (tag)
            {
                case AudioTag.Album: return file.Tag.Album;
                case AudioTag.Artist: return file.Tag.FirstAlbumArtist;
                case AudioTag.Year: return file.Tag.Year.ToString();
                case AudioTag.Genre: return file.Tag.FirstGenre;
                default: return String.Empty;
            }
        }

        private bool NotAudioFile(string filePath) => !AudioFormats.ExtensionsList.Contains(Path.GetExtension(filePath));
    }

    public partial class FluentAudioOrganizer : IOrganizerSettings
    {
        private string _mountingPath;

        private string MountingPath
        {
            get => _mountingPath ?? BasePath;
            set => _mountingPath = value;
        }
        private string BasePath { get; set; }
        private FileHandling HandlingMethod { get; set; } = FileHandling.Copy;
        private uint MaxSearchDepth { get; set; }

        IAudioDirectoryStructurer IOrganizerSettings.Organize => this;

        public IOrganizerSettings HandleFilesBy(FileHandling fileHandling)
        {
            this.HandlingMethod = fileHandling;
            return this;
        }

        public IOrganizerSettings LocatedIn(string path, bool recursive = false)
        {
            this.BasePath = path;
            return this;
        }

        public IOrganizerSettings OrganizeInto(string path)
        {
            this.MountingPath = path;
            return this;
        }

        public IOrganizer Build()
        {
            this.Validate();
            return this;
        }
    }

    public partial class FluentAudioOrganizer : IAudioDirectoryStructurer
    {
        private IList<AudioTag> _tagSequence = new List<AudioTag>();
        private IAudioTagSequenceValidator _sequenceValidator = new AudioTagSequenceValidator();


        public IAudioDirectoryStructurer By(AudioTag tag)
        {
            _tagSequence.Add(tag);
            _sequenceValidator.Validate(_tagSequence);
            return this;
        }

        public IAudioDirectoryStructurer ThenBy(AudioTag tag)
        {
            return By(tag);
        }

        public IOrganizerSettings Apply()
        {
            return this;
        }
    }

}
