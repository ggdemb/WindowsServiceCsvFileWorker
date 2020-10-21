using System.Threading;
using System.Threading.Tasks;

namespace WindowsServiceCsvFileWorker.Services
{
    public interface IFileProcessService
    {
        Task ProcesFileIfExsistsAsync(CancellationToken stoppingToken);
    }
}
