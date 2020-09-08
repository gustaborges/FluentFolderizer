using System;

namespace FluentFolderizer
{
    public class FluentOrganizerBuilder
    {
        private IOrganizerSettings _organizer;

        public IOrganizerSettings ForAudioFiles()
        {
            return (_organizer = new FluentAudioOrganizer());
        }


        public IOrganizerSettings Build()
        {
            return _organizer;
        }

    }
}
