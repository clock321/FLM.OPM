using OPM.Data;
using OPM.MediatR.Commands;
using OPM.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace OPM.MediatR.Handlers
{
    public class MarkAsReadUserNotificationCommandHandler : IRequestHandler<MarkAsReadUserNotificationCommand, bool>
    {
        private readonly IUserNotificationRepository _userNotificationRepository;
        private readonly IUnitOfWork<OPMContext> _uow;


        public MarkAsReadUserNotificationCommandHandler(IUserNotificationRepository userNotificationRepository,
            IUnitOfWork<OPMContext> uow)
        {
            _userNotificationRepository = userNotificationRepository;
            _uow = uow;
        }

        public async Task<bool> Handle(MarkAsReadUserNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = await _userNotificationRepository.FindAsync(request.Id);
            if (notification != null)
            {
                notification.IsRead = true;
                _userNotificationRepository.Update(notification);
                await _uow.SaveAsync();
            }

            return true;
        }
    }
}
