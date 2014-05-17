using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using ImageBatch.Core;
using System.Drawing.Text;
namespace ImageBatch.ImageOperations
{
    public class WatermarkOperation : ImageOperation
    {

        private Bitmap watermark;
        public WatermarkOperation()
        {
        }
        public void LoadWaterMark(string file)
        {
            if (watermark != null)
                watermark.Dispose();

            watermark = (Bitmap)Bitmap.FromFile(file);
        }
        public override void Dispose()
        {
            if (watermark != null)
            {
                watermark.Dispose();
                watermark = null;
            }
        }
        public override string Name
        {
            get { return "Water Mark"; }
        }

        public override int Priority
        {
            get { return PRIORITY_HIGH; }
        }

        public override void Perform(Bitmap bitmap)
        {
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.CompositingMode = CompositingMode.SourceOver;

                int width = watermark.Width;
                int height = watermark.Height;

                float diffX = (float)bitmap.Width / (float)width;
                float diffY = (float)bitmap.Height / (float)height;

                float aspectRatio = diffY < diffX ? diffY : diffX;

                int newWidth = (int)((width * aspectRatio));
                int newHeight = (int)((height * aspectRatio));

                graphics.DrawImage(bitmap, bitmap.Width / 2 - (newWidth / 2), bitmap.Height / 2 - (newHeight / 2),
                    newWidth, newHeight);
            }
        }
    }
}
