using DiskActivity.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskActivity.Services
{
    class DiskActivityService : IDiskActivityService
    {
        private Action<DisckActivityEvent> _observer;
        private string _observationTarget;
        private readonly IQueryService _queryService;

        public DiskActivityService(IQueryService queryService)
        {
            _observationTarget = "g:\\DiskActivity";
            _queryService = queryService;
        }

        public void RegisterObserver(Action<DisckActivityEvent> observer)
        {
            _observer = observer;

            var watcher = new FileSystemWatcher();
            watcher.Path = _observationTarget;
            watcher.Filter = "*.*";

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.LastAccess | NotifyFilters.LastWrite;
            watcher.IncludeSubdirectories = true;

            watcher.EnableRaisingEvents = true;
        }

        // Define the event handlers.
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                if (!_queryService.GetCanFind(e.FullPath))
                    return;
            }

            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
    }
}
