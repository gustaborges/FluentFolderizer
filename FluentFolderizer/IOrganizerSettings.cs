﻿using FluentFolderizer.Audio;

namespace FluentFolderizer
{
    public interface IOrganizerSettings
    {
        /// <summary>
        /// Defines where the files to be organized are located and optional search preference.
        /// </summary>
        /// <param name="path">The root path of the directory where the files to be organized are located</param>
        /// <param name="recursive">Settles whether to look for files recursively or not.</param>
        /// <returns></returns>
        IOrganizerSettings LocatedIn(string path, bool recursive);

        /// <summary>
        /// Defines the directory where the desired folder structure along with the organized files will be located.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        IOrganizerSettings OrganizeInto(string path);

        /// <summary>
        /// Defines whether the files will be copied or moved to the new directory structure.
        /// </summary>
        /// <param name="fileHandling"></param>
        /// <returns></returns>
        IOrganizerSettings HandleFilesBy(FileHandling fileHandling);

        /// <summary>
        /// Provides options for setting the desired directory structure.
        /// </summary>
        /// <returns></returns>
        IAudioDirectoryStructurer Organize();

        /// <summary>
        /// Returns an <see cref="IOrganizer"/> configured according to the provided preferences.
        /// </summary>
        /// <returns></returns>
        IOrganizer Build();
    }
}