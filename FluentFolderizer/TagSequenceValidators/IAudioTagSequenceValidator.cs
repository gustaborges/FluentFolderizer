using FluentFolderizer.Tags;
using System.Collections.Generic;

namespace FluentFolderizer.DirectoryStructureValidators
{
    interface IAudioTagSequenceValidator
    {
        void Validate(IList<AudioTag> structure);
    }
}
