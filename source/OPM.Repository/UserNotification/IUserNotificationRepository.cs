using OPM.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OPM.Data.Dto;
using OPM.Data.Resources;

namespace OPM.Repository
{
    public interface IUserNotificationRepository : IGenericRepository<UserNotification>
    {
        Task SaveUserNotification(Guid? folderId, Guid? documentId, List<Guid> users);
        Task<UserNotificationList> GetUserNotifications(NotificationSource notificationSource);
    }
}
