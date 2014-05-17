using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageBatch.Core
{
    /// <summary>
    /// What actually gets passed around for our scanner event
    /// </summary>
    public class ScannerEventArgs : EventArgs
    {
        private string file;
        private bool handled;

        public string File { get { return file; } }
        public bool Handled { get { return handled; } }

        public ScannerEventArgs(string filePath)
        {
            file = filePath;
        }
        public void NowHandled()
        {
            if (!handled)
                handled = true;
        }
    }
}
