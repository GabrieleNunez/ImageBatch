using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageBatch.Core
{
    public abstract class ImageOperation : IDisposable
    {
        public const int PRIORITY_MAX =  int.MaxValue;
        public const int PRIORITY_HIGH = 1000;
        public const int PRIORITY_MEDIUM = 500;
        public const int PRIORITY_LOW = 0;

        public abstract string Name { get; }
        public abstract int Priority { get; }
        public abstract void Perform(Bitmap bitmap);

        public override string ToString()
        {
            return Name;
        }

        public abstract void Dispose();
    }
}
