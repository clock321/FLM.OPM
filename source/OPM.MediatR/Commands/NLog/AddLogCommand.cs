using MediatR;
using OPM.Data.Dto;
using OPM.Infrastructure.Helper;

namespace OPM.MediatR.Commands
{
    public class AddLogCommand : IRequest<ServiceResponse<NLogDto>>
    {
        public string ErrorMessage { get; set; }
        public string Stack { get; set; }
    }
}
