using ImageBatch.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace ImageBatch.ImageOperations
{
    public class ResizeOperation : ImageOperation
    {
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }

        public override string Name
        {
            get { return "Resize"; }
        }

        public override int Priority
        {
            get { return PRIORITY_LOW; }
        }

        public override void Perform(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            float diffX = (float)MaxWidth / (float)width;
            float diffY = (float)MaxHeight / (float)height;

            float aspectRatio = diffY < diffX ? diffY : diffX;

            int newWidth = (int)((width * aspectRatio));
            int newHeight = (int)((height * aspectRatio));

            Bitmap resizeBitmap = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(resizeBitmap))
            {
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(bitmap, 0, 0, newWidth, newHeight);
            }
            bitmap.Dispose();
            bitmap = resizeBitmap;

        }

        public override void Dispose()
        {
            
        }
    }
}
