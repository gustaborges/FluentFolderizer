using System;
using System.Runtime.Serialization;

namespace FluentFolderizer.DirectoryStructureValidators
{
    [Serializable]
    public class InvalidDirectoryStructureException : Exception
    {
        public InvalidDirectoryStructureException()
        {
        }

        public InvalidDirectoryStructureException(string message) : base(message)
        {
        }

        public InvalidDirectoryStructureException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDirectoryStructureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}