﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using OPM.MediatR.Queries;
using OPM.Repository;

namespace OPM.MediatR.Handlers
{
    public class GetAllLoginAuditQueryHandler : IRequestHandler<GetAllLoginAuditQuery, LoginAuditList>
    {
        private readonly ILoginAuditRepository _loginAuditRepository;
        public GetAllLoginAuditQueryHandler(ILoginAuditRepository loginAuditRepository)
        {
            _loginAuditRepository = loginAuditRepository;
        }
        public async Task<LoginAuditList> Handle(GetAllLoginAuditQuery request, CancellationToken cancellationToken)
        {
            return await _loginAuditRepository.GetDocumentAuditTrails(request.LoginAuditResource);
        }
    }
}
