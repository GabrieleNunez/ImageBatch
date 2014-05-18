using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using ImageBatch.Core;
using System.Drawing.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
namespace ImageBatch.ImageOperations
{
    public class WatermarkOperation : ImageOperation
    {

        private Bitmap watermark;
        private bool loaded = false;
        
 
        public override string Name
        {
            get { return "Water Mark"; }
        }

        public override int Priority
        {
            get { return PRIORITY_HIGH; }
        }
        public override bool Loaded
        {
            get { return loaded; }
        }
        public override void Load(BatchSettings settings)
        {
            LoadWaterMark(settings.AdditionalImage);
            loaded = true;
        }
        private void LoadWaterMark(string file)
        {
            if (watermark != null)
                watermark.Dispose();
            if (File.Exists(file))
                watermark = (Bitmap)Bitmap.FromFile(file);
            else
            {
                watermark = null;
                MessageBox.Show("You've selected Watermark however no image was supplied.\nHit stop if you want to add one");
            }
        }
        public override void Dispose()
        {
            if (watermark != null)
            {
                watermark.Dispose();
                watermark = null;
            }
        }
        public override void Perform(ref Bitmap bitmap)
        {
            try
            {
                if (watermark != null)
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        Debug.WriteLine("Watermarking");
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.CompositingQuality = CompositingQuality.HighQuality;

                        int width = watermark.Width;
                        int height = watermark.Height;

                        float diffX = (float)watermark.Width / (float)width;
                        float diffY = (float)watermark.Height / (float)height;

                        float aspectRatio = diffY < diffX ? diffY : diffX;

                        int newWidth = (int)((width * aspectRatio));
                        int newHeight = (int)((height * aspectRatio));

                        graphics.DrawImage(watermark, bitmap.Width / 2 - (newWidth / 2), bitmap.Height / 2 - (newHeight / 2),
                            newWidth, newHeight);
                    }
                }
            }
            catch 
            { 
                //Unfortunately if an Indexed image is processed. GDI+ only throws a System.Exception. 
                //Only way around this is to catch and silently fail the operation
            }
        }
    }
}
