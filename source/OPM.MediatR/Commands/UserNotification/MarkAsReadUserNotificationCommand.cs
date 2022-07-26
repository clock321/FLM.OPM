using MediatR;
using System;

namespace OPM.MediatR.Commands
{
    public class MarkAsReadUserNotificationCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
