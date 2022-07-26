using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using OPM.Data;
using OPM.Data.Dto;
using OPM.Infrastructure.Helper;
using OPM.MediatR.Commands;
using OPM.Repository;

namespace OPM.MediatR.Handlers
{
    public class AddLogCommandHandler : IRequestHandler<AddLogCommand, ServiceResponse<NLogDto>>
    {
        private readonly INLogRespository _nLogRespository;
        private readonly IUnitOfWork<OPMContext> _uow;
        public AddLogCommandHandler(INLogRespository nLogRespository,
            IUnitOfWork<OPMContext> uow)
        {
            _nLogRespository = nLogRespository;
            _uow = uow;
        }
        public async Task<ServiceResponse<NLogDto>> Handle(AddLogCommand request, CancellationToken cancellationToken)
        {
            _nLogRespository.Add(new NLog
            {
                Id = Guid.NewGuid(),
                Logged = DateTime.UtcNow,
                Level = "Error",
                Message = request.ErrorMessage,
                Source = "Angular",
                Exception = request.Stack
            });
            await _uow.SaveAsync();
            return ServiceResponse<NLogDto>.ReturnSuccess();
        }
    }
}
