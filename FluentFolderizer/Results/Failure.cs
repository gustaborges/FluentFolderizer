using System;

namespace FluentFolderizer.Results
{
    public struct Failure
    {
        public Failure(string file, Exception ex)
        {
            File = file;
            Exception = ex;
        }

        public string File { get; }
        public Exception Exception { get; }
    }
}
