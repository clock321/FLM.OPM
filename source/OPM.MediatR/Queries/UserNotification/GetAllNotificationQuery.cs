using OPM.Data.Resources;
using OPM.Repository;
using MediatR;

namespace OPM.MediatR.Queries
{
    public class GetAllNotificationQuery : IRequest<UserNotificationList>
    {
        public NotificationSource NotificationSource { get; set; }
    }
}
