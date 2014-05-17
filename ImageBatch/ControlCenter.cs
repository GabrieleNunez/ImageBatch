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
        }

        void manager_AtMaxCapacity(BatchManager manager)
        {
            BatchManager batchManager = new BatchManager(batchSettings);
            batchManager.AtMaxCapacity += manager_AtMaxCapacity;
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
