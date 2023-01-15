using System;
using System.Threading.Tasks;

namespace VatSim.Snapshots
{
    public interface ISnapshotManager
    {
        Snapshot CurrentSnapshot { get; }

        string MemberStatsUrl { get; }

        string MetarServer { get; }

        bool Suspended { get; set; }

        event EventHandler UrlFetchInitiated;

        event EventHandler<int> UrlFetchCompleted;

        event EventHandler<string> UrlFetchError;

        event EventHandler<string> DataRefreshInitiated;

        event EventHandler<int> DataRefreshProgress;

        event EventHandler<bool> DataRefreshCompleted;

        event EventHandler<SnapshotRefreshErrorArgs> DataRefreshError;

        Task FetchUrls();

        void StopAutoRefresh();

        Task RefreshData();

        void CancelRefresh();

        void Resume();

        void ActivatePendingSnapshot();
    }
}
