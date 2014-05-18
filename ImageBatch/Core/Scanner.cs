using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace ImageBatch.Core
{
    public delegate void ScannerEventHandler(Scanner scanner,ScannerEventArgs eventArgs);

    /// <summary>
    /// Scanner will enumurate over files in the given directory.
    /// As it scans any file with valid extension will be trigger a ImageFound event
    /// </summary>
    public class Scanner
    {
        private string directory;
        private SearchOption searchOption;
        public event ScannerEventHandler ImageFound;

        public Scanner(string Directory,SearchOption SearchOption)
        {
            directory = Directory;
            searchOption = SearchOption;
        }

        /// <summary>
        /// Start scanning and enumurating picking up any files with valid extensions
        /// </summary>
        public void Scan()
        {
            try
            {
                IEnumerable<string> files = Directory.EnumerateFiles(directory, "*.*", searchOption);
                foreach (string path in files)
                {
                    switch (Path.GetExtension(path).ToLower())
                    {
                        case ".jpg":
                        case ".jpeg":
                        case ".png":
                        case ".gif":
                        case ".tiff":
                            if (ImageFound != null)
                            {
                                ScannerEventArgs args = new ScannerEventArgs(path);
                                ImageFound.Invoke(this, args);
                            }
                            continue;
                        default:
                            continue;
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
               //silently end operation
            }
        }
    }
}
