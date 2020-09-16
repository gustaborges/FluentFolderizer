using NUnit.Framework;
using System;
using System.IO;

namespace FluentFolderizer.Tests.Configs
{
    /// <summary>
    /// This struct provides valid and invalid directory paths for the execution of unit tests.
    /// </summary>
    readonly struct TestPaths
    {
        private static string _rootAudioTestFolder = Path.Combine(TestContext.CurrentContext.TestDirectory, "FileManipulationFolder");
        
        private static string _validBasePath = Path.Combine(_rootAudioTestFolder, "Valid Base Path");
        private static string _validMountingPath = Path.Combine(_rootAudioTestFolder, "Valid Mounting Path");
        private static string _inexistentDirectoryPath = Path.Combine(_rootAudioTestFolder, "Invalid Base Path");

        /// <summary>
        /// <para>Provides the path of the root testing environment. This folder contains audio file samples which can be copied to the BasePath folder, when <see cref="PopulateBasePath"/> is called, so that the tests can be run.</para>
        /// </summary>
        public static string RootTestFolderPath
        {
            get
            {
                Directory.CreateDirectory(_rootAudioTestFolder);
                return _rootAudioTestFolder;
            }
        }
        /// <summary>
        /// <para>Provides the path of an existing directory. In runtime, the getter creates the directory if needed, so that it's always valid.</para>
        /// </summary>
        public static string ValidBasePath
        {
            get
            {
                Directory.CreateDirectory(_validBasePath);
                return _validBasePath;
            }
        }

        /// <summary>
        /// <para>Provides the path of an existing directory. In runtime, the getter creates the directory if needed, so that it's always valid.</para>
        /// <para>By default: </para>
        /// </summary>
        public static string ValidMountingPath
        {
            get
            {
                Directory.CreateDirectory(_validMountingPath);
                return _validMountingPath;
            }
        }

        /// <summary>
        /// <para>Provides the path of an inexistent directory.</para>
        /// </summary>
        public static string NotCreatedDirectory
        {
            get
            {
                if (Directory.Exists(_inexistentDirectoryPath))
                {
                    Directory.Delete(_inexistentDirectoryPath, true);
                }
                return _inexistentDirectoryPath;
            }
        }



    }
}