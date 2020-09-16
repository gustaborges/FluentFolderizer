using FluentFolderizer.Tags;
using FluentFolderizer.Tests.Configs;
using FluentFolderizer.Tests.Configs.Helpers;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace FluentFolderizer.Tests
{
    public class FluentAudioOrganizerTests_OrganizationRun
    {

        private AudioFilesRepository _filesRepository = new AudioFilesRepository();
        private TestEnvironmentHelper _environmentHelper = new TestEnvironmentHelper();

        [SetUp]
        public void Setup()
        {
            _environmentHelper.DeleteBasePath();
            _environmentHelper.PopulateBasePath();
            _environmentHelper.DeleteMountingPath();
        }


        [Test]
        public void Run_WhenDestinationFolderIsNotSpecified_NewDirectoryStructureHasOneCriteria_ShouldOrganizeTheNewDirectoryStructureInBasePath()
        {
            var organizer = new FluentOrganizerBuilder()
                .ForAudioFiles()
                    .LocatedIn(TestPaths.ValidBasePath)
                    .Organize
                        .By(AudioTag.Artist)
                    .Apply()
                .Build();

            organizer.Run();

            AssertDirectoryStructureArtist(TestPaths.ValidBasePath);
        }

        [Test]
        public void Run_WhenDestinationFolderIsNotSpecified_NewDirectoryStructureHasMoreThanOneCriteria_ShouldOrganizeTheNewDirectoryStructureInBasePath()
        {
            var organizer = new FluentOrganizerBuilder()
             .ForAudioFiles()
                 .LocatedIn(TestPaths.ValidBasePath)
                 .Organize
                     .By(AudioTag.Artist)
                     .ThenBy(AudioTag.Album)
                 .Apply()
             .Build();

            organizer.Run();

            AssertDirectoryStructureArtistAlbum(TestPaths.ValidBasePath);
        }

        [Test]
        public void Run_WhenDestinationFolderIsValid_NewDirectoryStructureHasOneCriteria_ShouldOrganizeTheNewDirectoryStructureInTheSpecifiedDestinationFolder()
        {
            var organizer = new FluentOrganizerBuilder()
             .ForAudioFiles()
                 .LocatedIn(TestPaths.ValidBasePath)
                 .DestinationFolder(TestPaths.ValidMountingPath)
                 .Organize
                     .By(AudioTag.Artist)
                 .Apply()
             .Build();

            organizer.Run();

            AssertDirectoryStructureArtist(TestPaths.ValidMountingPath);
        }


        [Test]
        public void Run_WhenDestinationFolderIsValid_NewDirectoryStructureHasMoreThanOneCriteria_ShouldOrganizeTheNewDirectoryStructureInTheSpecifiedDirectory()
        {
            var organizer = new FluentOrganizerBuilder()
             .ForAudioFiles()
                 .LocatedIn(TestPaths.ValidBasePath)
                 .DestinationFolder(TestPaths.ValidMountingPath)
                 .Organize
                     .By(AudioTag.Artist)
                     .ThenBy(AudioTag.Album)
                 .Apply()
             .Build();

            organizer.Run();

            AssertDirectoryStructureArtistAlbum(TestPaths.ValidMountingPath);
        }

        [Test]
        public void Run_WhenDestinationFolderIsInexistent_ShouldCreateTheFolderAndOrganize()
        {
            var organizer = new FluentOrganizerBuilder()
             .ForAudioFiles()
                 .LocatedIn(TestPaths.ValidBasePath)
                 .DestinationFolder(TestPaths.ValidMountingPath)
                 .Organize
                     .By(AudioTag.Artist)
                     .ThenBy(AudioTag.Album)
                 .Apply()
             .Build();

            _environmentHelper.DeleteMountingPath();

            organizer.Run();

            AssertDirectoryStructureArtistAlbum(TestPaths.ValidMountingPath);
        }

        [Test]
        public void Run_WhenBasePathIsInvalid_ShouldThrowDirectoryNotFoundException()
        {
            var organizer = new FluentOrganizerBuilder()
             .ForAudioFiles()
                 .LocatedIn(TestPaths.NotCreatedDirectory)
                 .Organize
                     .By(AudioTag.Album)
                 .Apply()
             .Build();
            
            Assert.Throws<DirectoryNotFoundException>(() => { organizer.Run(); });
        }


        [Test]
        public void Run_WhenFileHandlingMethodIsMove_ShouldMoveAndOrganizeTheFilesInTheNewLocation()
        {
            var organizer = new FluentOrganizerBuilder()
                 .ForAudioFiles()
                     .LocatedIn(TestPaths.ValidBasePath)
                     .DestinationFolder(TestPaths.ValidMountingPath)
                     .HandleFilesBy(FileHandlingMethods.Move)
                     .Organize
                         .By(AudioTag.Year)
                         .ThenBy(AudioTag.Album)
                     .Apply()
                 .Build();

            organizer.Run();

            AssertDirectoryStructureYearAlbum(TestPaths.ValidMountingPath);
            AssertFilesHaveBeenMovedFromBasePath();
        }

        [Test]
        public void Run_WhenExceptionOccursWhileOrganizingTheFiles_ShouldReturnExecutionResultWithFailureLogged()
        {
            //var fileWithForcedError = TestAudioFiles.Files[0];
            //var fileWithForcedErrorPath = $"{folderizerAudio.BasePath}\\{fileWithForcedError.Name}{fileWithForcedError.Format}";

            //using (var stream = File.OpenRead(fileWithForcedErrorPath))
            //{
            //    folderizerAudio.MountingPath = TestPaths.ValidMountingPath;
            //    folderizerAudio.OperationMethod = OperationMethod.Move;
            //    folderizerAudio.SetDesiredDirectoryStructure(AudioTag.Year, AudioTag.Album);

            //    ExecutionResult executionResult = folderizerAudio.Organize();

            //    Assert.True(executionResult.Errors.Length > 0);
            //    Assert.True(executionResult.Errors[0].FilePath.Equals(fileWithForcedErrorPath));
            //}
        }

        private void AssertFilesHaveBeenMovedFromBasePath()
        {
            foreach (var file in _filesRepository.Files)
            {
                Assert.False(File.Exists(Path.Combine(TestPaths.ValidBasePath, $"{file.Name}.{file.Format}")));
            }
        }

        private void AssertDirectoryStructureArtistAlbum(string path)
        {
            var distinctArtists = _filesRepository.Files
                .Select((f) => f.AlbumArtist)
                .Distinct();

            foreach (var artist in distinctArtists)
            {
                var albumsOfTheArtist = _filesRepository.Files
                   .Where((f) => f.AlbumArtist.Equals(artist))
                   .Select((f) => f.Album)
                   .Distinct();

                foreach (var album in albumsOfTheArtist)
                    Assert.True(Directory.Exists(Path.Combine(path, artist, album)));
            }
        }

        private void AssertDirectoryStructureYearAlbum(string path)
        {
            var distinctYears = _filesRepository.Files
                .Select((f) => f.Year)
                .Distinct();

            foreach (var year in distinctYears)
            {
                var albumsOfTheYear = _filesRepository.Files
                   .Where((f) => f.AlbumArtist.Equals(year))
                   .Select((f) => f.Album)
                   .Distinct();

                foreach (var album in albumsOfTheYear)
                {
                    Assert.True(Directory.Exists(Path.Combine(path,year,album)));
                }
            }
        }

        private void AssertDirectoryStructureArtist(string path)
        {
            var distinctArtists = _filesRepository.Files
                .Select(f => f.AlbumArtist)
                .Distinct();

            foreach (var artist in distinctArtists)
            {
                Assert.True(Directory.Exists(Path.Combine(path, artist)));
            }
        }


    }
}