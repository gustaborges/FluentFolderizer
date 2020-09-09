using FluentFolderizer.Audio;
using System;

namespace FluentFolderizer
{
    public class FluentOrganizerBuilder : IOrganizerBuilder
    {
        private IOrganizer _organizer;

        public IOrganizerSettings ForAudioFiles()
        {
            return (_organizer = new FluentAudioOrganizer()) as IOrganizerSettings;
        }

        public IOrganizerSettings ForImageFiles()
        {
            throw new NotImplementedException();
        }

        public IOrganizer Build()
        {
            return _organizer;
        }
    }
}
