using System;

namespace VatSim.Snapshots
{
    public class SnapshotRefreshErrorArgs
    {
        public SnapshotRefreshErrorType Type;
        public string Message;
        public Uri Server;
        public DateTime LastUpdated;

        public SnapshotRefreshErrorArgs(SnapshotRefreshErrorType type) => this.Type = type;

        public SnapshotRefreshErrorArgs(SnapshotRefreshErrorType type, string message, Uri server)
        {
            this.Type = type;
            this.Message = message;
            this.Server = server;
        }

        public SnapshotRefreshErrorArgs(
          SnapshotRefreshErrorType type,
          Uri server,
          DateTime lastUpdated)
        {
            this.Type = type;
            this.Server = server;
            this.LastUpdated = lastUpdated;
        }
    }
}
