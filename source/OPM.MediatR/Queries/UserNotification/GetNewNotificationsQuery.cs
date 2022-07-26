using OPM.Data.Dto;
using MediatR;
using System.Collections.Generic;

namespace OPM.MediatR.Queries
{
    public class GetNewNotificationsQuery : IRequest<List<UserNotificationDto>>
    {
    }
}
