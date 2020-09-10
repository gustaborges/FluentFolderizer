using FluentFolderizer.Audio;
using FluentFolderizer.Tags;
using FluentFolderizer.Tests.Config;
using NUnit.Framework;
using System;

namespace FluentFolderizer.Tests.Audio
{
    public class FluentAudioOrganizer_Tests
    {
        //var organizer = new FluentOrganizerBuilder()
        //    .ForAudioFiles()
        //        .LocatedIn(path: "", recursive: false)
        //        .OrganizeInto(path: "")
        //        .HandleFilesBy(FileHandling.Move)
        //        .NewDirectoryStructure
        //            .By(AudioTag.Album)
        //            .ThenBy(AudioTag.Artist)
        //            .ThenBy(AudioTag.Genre)
        //        .Apply()
        //    .Build();

        [Test]
        public void WhenLocationOfFilesToBeOrganizedIsNotProvided_ShouldThrowInvalidOperationExceptionOnBuild()
        {

            Assert.Throws<InvalidOperationException>(() => 
            {
                new FluentOrganizerBuilder()
                    .ForAudioFiles()
                    .Build();
            });
        }

        [Test]
        public void WhenNewDesiredDirectoryStructureIsNotProvided_ShouldThrowInvalidOperationExceptionOnBuild()
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
        public void WhenNewDesiredDirectoryStructureAndLocationOfFilesAreProvided_ShouldSuccesfullyBuildTheInstance()
        {
            new FluentOrganizerBuilder()
                .ForAudioFiles()
                    .LocatedIn(TestPaths.ValidBasePath)
                    .Organize
                        .By(AudioTag.Album)
                    .Apply()
                .Build();
        }


    }
}