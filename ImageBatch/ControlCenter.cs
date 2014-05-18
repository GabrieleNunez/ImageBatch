using ImageBatch.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ImageBatch
{
    public class ControlCenter
    {
        private List<BatchManager> batchManagers;
        private List<Scanner> scanners;
        private BatchSettings batchSettings;
        private int totalFiles;
        private int totalDone;
        private int totalManagersDone;

        public int BatchManagerCount { get { return batchManagers.Count; } }
        public int ScannerCount { get { return scanners.Count; } }
        public int TotalFiles { get { return totalFiles; } }
        public int TotalProcessed { get { return totalDone; } }
        public event EventHandler Done;

        private BatchManager LeastFilledManager
        {
            get
            {
                //should always be the last manager
                return batchManagers.Last();
            }
        }

        public ControlCenter(BatchSettings settings)
        {
            batchManagers = new List<BatchManager>();
            batchSettings = settings;
            scanners = new List<Scanner>();
            BatchManager manager = new BatchManager(batchSettings);
            batchManagers.Add(manager);
            manager.AtMaxCapacity += manager_AtMaxCapacity;
            manager.FileAdded += manager_FileAdded;
            manager.Done += manager_Done;
            manager.ProcessedFile += manager_ProcessedFile;
        }

        void manager_ProcessedFile(BatchManager manager)
        {
            totalDone++;
        }

        private void manager_Done(BatchManager manager)
        {
            totalManagersDone++;
            if (totalManagersDone == batchManagers.Count)
            {
                if (Done != null)
                    Done.Invoke(this, null);
            }
        }

        private void manager_FileAdded(BatchManager manager)
        {
            totalFiles++;
        }

        private void manager_AtMaxCapacity(BatchManager manager)
        {
            BatchManager batchManager = new BatchManager(batchSettings);
            batchManager.AtMaxCapacity += manager_AtMaxCapacity;
            batchManager.FileAdded += manager_FileAdded;
            batchManager.Done += manager_Done;
            batchManager.ProcessedFile += manager_ProcessedFile;
            batchManagers.Add(batchManager);
            foreach (Scanner scanner in scanners)
                batchManager.WatchScanner(scanner);
        }

        public void AddFolder(string folder)
        {
            scanners.Add(new Scanner(folder, SearchOption.AllDirectories));
            LeastFilledManager.WatchScanner(scanners.Last());
        }
        public void Start(ImageOperation[] operations)
        {
            //run the scanners
            foreach (Scanner scanner in scanners)
                scanner.Scan();

            //launch managers with a set of operations
            foreach (BatchManager manager in batchManagers)
                manager.Launch(operations);
        }
        public void Stop()
        {
            foreach (BatchManager manager in batchManagers)
                manager.Abort();
        }
    }
}
