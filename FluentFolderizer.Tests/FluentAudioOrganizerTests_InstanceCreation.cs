using FluentFolderizer.Audio;
using FluentFolderizer.DirectoryStructureValidators;
using FluentFolderizer.Tags;
using FluentFolderizer.Tests.Configs;
using NUnit.Framework;
using System;

namespace FluentFolderizer.Tests
{
    public class FluentAudioOrganizerTests_InstanceCreation
    {
        #region Build()

        [Test]
        public void Build_WhenLocationOfFilesToBeOrganizedIsNotProvided_ShouldThrowInvalidOperationException()
        {

            Assert.Throws<InvalidOperationException>(() => 
            {
                new FluentOrganizerBuilder()
                    .ForAudioFiles()
                    .Build();
            });
        }

        [Test]
        public void Build_WhenNewDesiredDirectoryStructureIsNotProvided_ShouldThrowInvalidOperationException()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                new FluentOrganizerBuilder()
                    .ForAudioFiles()
                        .LocatedIn(TestPaths.ValidBasePath)
                    .Build();
            });
        }


        [Test]
        public void Build_WhenNewDesiredDirectoryStructureAndLocationOfFilesAreProvided_ShouldSuccesfullyReturnTheInstance()
        {
            new FluentOrganizerBuilder()
                .ForAudioFiles()
                    .LocatedIn(TestPaths.ValidBasePath)
                    .Organize
                        .By(AudioTag.Album)
                    .Apply()
                .Build();
        }


        [Test]
        public void Build_WhenNewDirectoryStructureContainsAlbumTagNotInLastPosition_ShouldThrowInvalidDirectoryStructureException()
        {
            Assert.Throws<InvalidDirectoryStructureException>(() =>
            {
                new FluentOrganizerBuilder()
                    .ForAudioFiles()
                        .LocatedIn(TestPaths.ValidBasePath)
                        .Organize
                            .By(AudioTag.Album)
                            .ThenBy(AudioTag.Artist)
                        .Apply()
                    .Build();
            });
        }

        [Test]
        public void Build_WhenNewDirectoryStructureContainsDuplicateTag_ShouldThrowInvalidDirectoryStructureException()
        {
            Assert.Throws<InvalidDirectoryStructureException>(() =>
            {
                new FluentOrganizerBuilder()
                    .ForAudioFiles()
                        .LocatedIn(TestPaths.ValidBasePath)
                        .Organize
                            .By(AudioTag.Artist)
                            .ThenBy(AudioTag.Artist)
                        .Apply()
                    .Build();
            });
        }


        [Test]
        public void Build_WhenNewDirectoryStructureIsValid_ShouldSuccesfullyReturnTheInstance()
        {
            new FluentOrganizerBuilder()
                .ForAudioFiles()
                    .LocatedIn(TestPaths.ValidBasePath)
                    .Organize
                        .By(AudioTag.Year)
                        .ThenBy(AudioTag.Artist)
                        .ThenBy(AudioTag.Album)
                    .Apply()
                .Build();
        }



        #endregion

        #region TagSequence

        [Test]
        public void TagSequence_WhenNewDirectoryStructureIsValid_TagSequenceContainsFolderStructureInCorrectOrder()
        {
            FluentAudioOrganizer organizer = new FluentOrganizerBuilder()
                .ForAudioFiles()
                    .LocatedIn(TestPaths.ValidBasePath)
                    .Organize
                        .By(AudioTag.Year)
                        .ThenBy(AudioTag.Artist)
                        .ThenBy(AudioTag.Album)
                    .Apply()
                .Build() as FluentAudioOrganizer;

            Assert.AreEqual(AudioTag.Year, organizer.TagSequence[0]);
            Assert.AreEqual(AudioTag.Artist, organizer.TagSequence[1]);
            Assert.AreEqual(AudioTag.Album, organizer.TagSequence[2]);
        }

        #endregion

        #region MountingPath

        [Test]
        public void DestinationFolder_WhenMountingPathIsNotSpecified_MountingPathShouldEqualBasePath()
        {
            FluentAudioOrganizer organizer = new FluentOrganizerBuilder()
                .ForAudioFiles()
                    .LocatedIn(TestPaths.ValidBasePath)
                    .Organize
                        .By(AudioTag.Album)
                    .Apply()
                .Build() as FluentAudioOrganizer;

            Assert.AreEqual(organizer.BasePath, organizer.MountingPath);
        }

        [Test]
        public void DestinationFolder_WhenMountingPathIsSpecified_MountingPathShouldBeDifferentFromBasePath()
        {
            FluentAudioOrganizer organizer = new FluentOrganizerBuilder()
                .ForAudioFiles()
                    .LocatedIn(TestPaths.ValidBasePath)
                    .DestinationFolder(TestPaths.ValidMountingPath)
                    .Organize
                        .By(AudioTag.Album)
                    .Apply()
                .Build() as FluentAudioOrganizer;

            Assert.AreEqual(TestPaths.ValidMountingPath, organizer.MountingPath);
        }
        #endregion

        #region FileHandlingMethod
        
        [Test]
        public void FileHandlingMethod_WhenHandlingMethodIsNotSpecified_ShouldEqualToCopy()
        {
            FluentAudioOrganizer organizer = new FluentOrganizerBuilder()
                .ForAudioFiles()
                    .LocatedIn(TestPaths.ValidBasePath)
                    .DestinationFolder(TestPaths.ValidMountingPath)
                    .Organize
                        .By(AudioTag.Album)
                    .Apply()
                .Build() as FluentAudioOrganizer;

            Assert.AreEqual(FileHandlingMethods.Copy, organizer.FileHandlingMethod);
        }

        #endregion
    }
}