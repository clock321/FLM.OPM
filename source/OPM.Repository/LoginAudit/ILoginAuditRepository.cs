using System.Threading.Tasks;
using OPM.Data;
using OPM.Data.Dto;
using OPM.Data.Resources;

namespace OPM.Repository
{
    public interface ILoginAuditRepository : IGenericRepository<LoginAudit>
    {
        Task<LoginAuditList> GetDocumentAuditTrails(LoginAuditResource loginAuditResrouce);
        Task LoginAudit(LoginAuditDto loginAudit);
    }
}
