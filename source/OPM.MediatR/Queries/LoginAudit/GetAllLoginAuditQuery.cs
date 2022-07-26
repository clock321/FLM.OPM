using MediatR;
using OPM.Data.Resources;
using OPM.Repository;

namespace OPM.MediatR.Queries
{
    public class GetAllLoginAuditQuery : IRequest<LoginAuditList>
    {
        public LoginAuditResource LoginAuditResource { get; set; }
    }
}
