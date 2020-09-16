using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FluentFolderizer.Tests.Configs.Helpers
{
    class TestEnvironmentHelper
    {
        public void PopulateBasePath()
        {
            IEnumerable rootTestFolderFiles = Directory.EnumerateFiles(TestPaths.RootTestFolderPath);

            foreach (string file in rootTestFolderFiles)
            {
                try
                {
                    string fileDestinationName = file.Split("\\").Last();
                    File.Copy(file, Path.Combine(TestPaths.ValidBasePath, fileDestinationName));
                }
                catch { return; }
            }
        }

        public void DeleteBasePath()
        {
            if (Directory.Exists(TestPaths.ValidBasePath))
                Directory.Delete(TestPaths.ValidBasePath, true);
        }

        public void DeleteMountingPath()
        {
            if (Directory.Exists(TestPaths.ValidMountingPath))
                Directory.Delete(TestPaths.ValidMountingPath, true);
        }
    }
}
