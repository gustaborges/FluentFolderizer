using FluentFolderizer.Tags;
using System.Collections.Generic;
using System.Linq;

namespace FluentFolderizer.DirectoryStructureValidators
{
    class AudioTagSequenceValidator : IAudioTagSequenceValidator
    {

        public void Validate(IList<AudioTag> tagSequence)
        {
            if (SequenceContainsDuplicateTags(tagSequence))
            {
                throw new InvalidDirectoryStructureException("The sequence must not contain duplicate tags.");
            }

            if (SequenceContainsAlbumTagNotInLastPosition(tagSequence))
            {
                throw new InvalidDirectoryStructureException("The tag \"Album\" is not allowed if not in last position");
            }
        }

        private static bool SequenceContainsAlbumTagNotInLastPosition(IList<AudioTag> tagSequence)
        {
            return (tagSequence.Contains(AudioTag.Album)) && (tagSequence.Last() != AudioTag.Album);
        }

        private static bool SequenceContainsDuplicateTags(IList<AudioTag> tagSequence)
        {
            return tagSequence.Count != tagSequence.Distinct().Count();
        }
    }
}
