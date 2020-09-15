using FluentFolderizer.Audio;

namespace FluentFolderizer
{
    public interface IOrganizerSettings
    {
        /// <summary>
        /// Provides options for setting the desired directory structure.
        /// </summary>
        /// <returns></returns>
        IAudioDirectoryStructurer Organize { get; }

        /// <summary>
        /// Defines where the files to be organized are located and optional search preference.
        /// </summary>
        /// <param name="path">The root path of the directory where the files to be organized are located</param>
        /// <param name="recursive">Settles whether to look for files recursively or not.</param>
        /// <returns></returns>
        IOrganizerSettings LocatedIn(string path, bool recursive = false);

        /// <summary>
        /// Defines the directory where the desired folder structure along with the organized files will be located.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        IOrganizerSettings DestinationFolder(string path);

        /// <summary>
        /// Defines whether the files will be copied or moved to the new directory structure.
        /// </summary>
        /// <param name="fileHandling"></param>
        /// <returns></returns>
        IOrganizerSettings HandleFilesBy(FileHandlingMethods fileHandling);

        /// <summary>
        /// Validates the organizer and returns an <see cref="IOrganizer"/> configured according to the provided preferences.
        /// </summary>
        /// <returns></returns>
        IOrganizer Build();
    }
}