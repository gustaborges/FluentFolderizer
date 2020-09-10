using NUnit.Framework;
using System;
using System.IO;

namespace FluentFolderizer.Tests.Config
{
    /// <summary>
    /// This struct provides valid and invalid directory paths for the execution of unit tests.
    /// </summary>
    readonly struct TestPaths
    {
        private static string _rootAudioTestFolder = Path.Combine(TestContext.CurrentContext.TestDirectory, "AudioTestDataContext");
        
        private static string _validBasePath = Path.Combine(_rootAudioTestFolder, "Valid Base Path");
        private static string _validMountingPath = Path.Combine(_rootAudioTestFolder, "Valid Mounting Path");
        private static string _inexistentDirectoryPath = Path.Combine(_rootAudioTestFolder, "Invalid Base Path");

        /// <summary>
        /// <para>Provides the path of the root test folder, where files can be put to test the library. These files will be copied to the BasePath folder at runtime.</para>
        /// <para>See: <see cref="ValidBasePath"/></para>
        /// <para>By default, RootTestFolderPath points to: <c>MyMusic/FolderizerLibTest</c></para>
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
        /// <para>Provides the path of an existing directory, set in this property's private field.</para>
        /// <para>In runtime, the getter creates the directory pointed in it's respective private field, 
        /// if it doesn't exist</para>
        /// <para>By default: <c>MyMusic/FolderizerLibTest/Folderizer-Valid-Base-Path</c></para>
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
        /// <para>Provides the path of an existing directory, set in this property's private field.</para>
        /// <para>In runtime, the getter creates the directory pointed in it's respective private field, 
        /// if it doesn't exist.</para>
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
                    Directory.Delete(_inexistentDirectoryPath);
                }
                return _inexistentDirectoryPath;
            }
        }



    }
}