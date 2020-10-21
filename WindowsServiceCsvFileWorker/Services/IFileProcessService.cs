using System.Threading.Tasks;

namespace WindowsServiceCsvFileWorker.Services
{
    public interface IFileProcessService
    {
        Task ProcesFileIfExsists();
    }
}
