using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FluentFolderizer.Audio
{
    struct AudioFormats
    {
        public static IReadOnlyList<string> ExtensionsList = new List<string>
        {
            ".aa", ".aax", ".aac", ".aiff", ".ape", ".dsf", ".flac", ".m4a", ".m4b", ".m4p", 
            ".mp3", ".mpc", ".mpp", ".ogg", ".oga", ".wav", ".wma", ".wv", ".webm"
        };
    }
}
