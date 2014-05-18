using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageBatch.Core
{
    /// <summary>
    /// The settings a BatchManager needs to start and mantain operations
    /// </summary>
    public class BatchSettings
    {
        public string AdditionalImage { get; set; }
        public string OutputDirectory { get; set; }
        public string FileLabel { get; set; }

        public bool OrganizeByDate { get; set; }
        public bool MaintainAspectRatio { get; set; }

        public int MaxFiles { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public BatchSettings()
        {
            MaxFiles = 25;
            OrganizeByDate = true;
            MaintainAspectRatio = true;
            Width = 256;
            Height = 256;
        }
        
    }
}
