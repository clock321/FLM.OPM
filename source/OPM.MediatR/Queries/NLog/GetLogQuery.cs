using MediatR;
using System;
using OPM.Data.Dto;
using OPM.Infrastructure.Helper;

namespace OPM.MediatR.Queries
{
    public class GetLogQuery : IRequest<ServiceResponse<NLogDto>>
    {
        public Guid Id { get; set; }
    }
}
