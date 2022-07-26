using MediatR;
using OPM.Data.Resources;
using OPM.Repository;

namespace OPM.MediatR.Queries
{
    public class GetNLogsQuery : IRequest<NLogList>
    {
        public NLogResource NLogResource { get; set; }
    }
}
