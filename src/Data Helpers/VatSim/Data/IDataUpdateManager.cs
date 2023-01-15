using System;
using System.Threading.Tasks;

namespace VatSim.Data
{
    public interface IDataUpdateManager
    {
        event EventHandler MainDataDownloadStarted;

        event EventHandler FirBoundaryDataDownloadStarted;

        Task CheckForNewDataFiles();
    }
}
