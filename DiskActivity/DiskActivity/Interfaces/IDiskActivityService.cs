using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskActivity.Interfaces
{
    /// <summary>
    /// Describes a type of activity observered on a file system
    /// </summary>
    public enum Activity
    {
        Created,
        Deleted,
        Moved,
        Renamed,
        Changed
    }

    /// <summary>
    /// Describes the activity observerd on a file system
    /// </summary>
    public struct DisckActivityEvent
    {
        public string FileName { get; private set; }

        public Activity Activity { get; private set; }

        public DisckActivityEvent(string fileName, Activity activity)
        {
            FileName = fileName;
            Activity = activity;
        }
    }

    /// <summary>
    /// Service to observe disk activity
    /// </summary>
    interface IDiskActivityService
    {
        void RegisterObserver(Action<DisckActivityEvent> oobserver);
    }
}
