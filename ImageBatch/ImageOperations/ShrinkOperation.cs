using ImageBatch.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace ImageBatch.ImageOperations
{
    public class ShrinkOperation : ImageOperation
    {
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }
        private bool loaded = false;

        public override string Name
        {
            get { return "Shrink"; }
        }
        public override bool Loaded
        {
            get { return loaded; }
        }
        public override int Priority
        {
            get { return PRIORITY_LOW; }
        }
        public override void Load(BatchSettings settings)
        {
            MaxWidth = settings.Width;
            MaxHeight = settings.Height;
            loaded = true;
        }
        public override void Perform(ref Bitmap bitmap)
        {
            Debug.WriteLine("Shrinking");
            int width = bitmap.Width;
            int height = bitmap.Height;

            float diffX = (float)MaxWidth / (float)width;
            float diffY = (float)MaxHeight / (float)height;

            float aspectRatio = diffY < diffX ? diffY : diffX;

            int newWidth = (int)((width * aspectRatio));
            int newHeight = (int)((height * aspectRatio));
            try
            {
                using (Bitmap resizeBitmap = new Bitmap(newWidth, newHeight))
                {
                    using (Graphics graphics = Graphics.FromImage(resizeBitmap))
                    {
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.DrawImage(bitmap, 0, 0, newWidth, newHeight);
                    }
                    bitmap.Dispose();
                    bitmap = (Bitmap)resizeBitmap.Clone();
                }
            }
            catch { }
            

        }

        public override void Dispose()
        {
            
        }
    }
}
