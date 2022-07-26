using System.Threading.Tasks;
using OPM.Data;
using OPM.Data.Dto;
using OPM.Data.Resources;

namespace OPM.Repository
{
    public interface INLogRespository : IGenericRepository<NLog>
    {
        Task<NLogList> GetNLogsAsync(NLogResource nLogResource);
    }
}
