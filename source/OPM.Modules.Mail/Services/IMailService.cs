using System.Collections.Generic;
using OPM.Modules.Mail.Models;

namespace OPM.Modules.Mail.Services
{
  public interface IMailService
  {
    IEnumerable<MailMessage> Messages { get; set; }

    void GetMessages(string folder);

    void Send(MailMessage message);
  }
}