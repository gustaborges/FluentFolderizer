using System;
using System.Collections.Generic;
using System.Text;

namespace FluentFolderizer
{
    class FluentAudioOrganizer : IOrganizer, IOrganizerSettings
    {
        public IOrganizerSettings HandleFilesBy(FileHandling fileHandling)
        {
            throw new NotImplementedException();
        }

        public IOrganizerSettings LocatedIn(string path, bool recursive)
        {
            throw new NotImplementedException();
        }

        public IDirectoryStructurer Organize()
        {
            throw new NotImplementedException();
        }

        public IOrganizerSettings OrganizeInto(string path)
        {
            throw new NotImplementedException();
        }

        public IOrganizerSettings Build()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            
        }
    }
}
