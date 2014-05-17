using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ImageBatch.Core
{
    public delegate void BatchEventHandler(BatchManager manager);
    /// <summary>
    /// Every batch manager will be in charge of its own set of files.
    /// It'll process and do whatever it has to do to the images
    /// on its own thread.
    /// </summary>
    public class BatchManager
    {
        private ConcurrentStack<string> files;
        private Thread operationThread;
        private BatchSettings batchSettings;
        private int processed;
        private bool isRunning;

        private const int PROPERTY_ID_DATETIME = 36867;

        public event BatchEventHandler AtMaxCapacity;
        public event BatchEventHandler FileAdded;
        public int TotalProcessed { get { return processed; } }
        public bool IsRunning { get { return isRunning; } }
        public bool IsFilled { get { return files.Count == batchSettings.MaxFiles;}}
        
        public BatchManager(BatchSettings BatchSettings)
        {
            processed = 0;
            isRunning = false;
            files = new ConcurrentStack<string>();
            batchSettings = BatchSettings;
            ParameterizedThreadStart threadStart = new ParameterizedThreadStart(operationExecute);
            operationThread = new Thread(threadStart);
        }
        
        public void WatchScanner(Scanner scanner)
        {
            scanner.ImageFound += scannerImageFound;
        }

        private IEnumerable<ImageOperation> GetPriorities(ImageOperation[] operations,int min, int max)
        {
            return from op in operations
                   where op.Priority >= min &&
                   op.Priority < max
                   select op;
        }
        private void operationExecute(object parameter)
        {
            isRunning = true;

            ImageOperation[] operations = (ImageOperation[])parameter;

            ImageOperation maxPriority = (from op in operations
                                          where op.Priority == ImageOperation.PRIORITY_MAX
                                          select op).First();

            IEnumerable<ImageOperation> highPriorities = GetPriorities(operations,
                                                         ImageOperation.PRIORITY_HIGH,
                                                         ImageOperation.PRIORITY_MAX);
            IEnumerable<ImageOperation> mediumPriorities = GetPriorities(operations,
                                                            ImageOperation.PRIORITY_MEDIUM,
                                                            ImageOperation.PRIORITY_HIGH);
            IEnumerable<ImageOperation> lowPriorities = GetPriorities(operations,
                                                            ImageOperation.PRIORITY_LOW,
                                                            ImageOperation.PRIORITY_MEDIUM);
            StringBuilder builder = new StringBuilder();

            while (!files.IsEmpty)
            {
                builder.Clear();
                string file = "";
                if (files.TryPop(out file))
                {
                    try
                    {
                        using (Bitmap bitmap = (Bitmap)Bitmap.FromFile(file))
                        {
                            foreach (ImageOperation op in lowPriorities)
                                op.Perform(bitmap);
                            foreach (ImageOperation op in mediumPriorities)
                                op.Perform(bitmap);
                            foreach (ImageOperation op in highPriorities)
                                op.Perform(bitmap);
                            if (maxPriority != null)
                                maxPriority.Perform(bitmap);

                            if (!string.IsNullOrEmpty(batchSettings.OutputDirectory))
                                builder.Append(batchSettings.OutputDirectory);
                            else
                                builder.Append(Path.GetPathRoot(file));

                            if (batchSettings.OrganizeByDate)
                            {
                                DateTime dateTaken = DateTime.Now;
                                try
                                {
                                    PropertyItem property = bitmap.GetPropertyItem(PROPERTY_ID_DATETIME);
                                    if (!DateTime.TryParse(Encoding.UTF8.GetString(property.Value), out dateTaken))
                                        dateTaken = File.GetCreationTime(file);

                                }
                                catch (ArgumentException)
                                {
                                    dateTaken = File.GetCreationTime(file);
                                }
                                finally
                                {
                                    builder.AppendFormat("\\{0}\\", dateTaken.Date.ToString("yyyy-MM-dd"));
                                }
                            }
                            if (!string.IsNullOrEmpty(batchSettings.FileLabel))
                                builder.Append(batchSettings.FileLabel);
                            builder.Append(Path.GetExtension(file));
                            ImageFormat imgFormat = GetImageFormat(Path.GetExtension(file));
                            processed++;
                            bitmap.Save(builder.ToString(), imgFormat);
                        }
                    }
                    catch (System.InvalidOperationException)
                    {
                        //ignore for now
                        //TODO implement InvalidOperationException
                    }
                }
            }
            isRunning = false;
        }
        private ImageFormat GetImageFormat(string extension)
        {
            switch (extension.ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    return ImageFormat.Jpeg;
                case ".gif":
                    return ImageFormat.Gif;
                case ".png":
                    return ImageFormat.Png;
                case ".tiff":
                    return ImageFormat.Tiff;
                default:
                   return ImageFormat.Bmp;
            }
        }
        private void scannerImageFound(Scanner scanner,ScannerEventArgs e)
        {
            if (!e.Handled && files.Count != batchSettings.MaxFiles)
            {
                e.NowHandled();
                files.Push(e.File);
                if (FileAdded != null)
                    FileAdded.Invoke(this);
                if (files.Count == batchSettings.MaxFiles)
                {
                    if (AtMaxCapacity != null)
                        AtMaxCapacity.Invoke(this);
                }
            }
        }
        public void Launch(ImageOperation[] operations)
        {
            if (!operationThread.IsAlive)
            {
                processed = 0;
                operationThread.Start(operations);
            }
        }
        public void Abort()
        {
            if (operationThread.IsAlive)
                operationThread.Abort();
        }
    }
}
