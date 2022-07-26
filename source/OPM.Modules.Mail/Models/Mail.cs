using System;

namespace OPM.Modules.Mail.Models
{
  public class MailMessage
  {
    public string Content { get; set; }

    public string From { get; set; }

    public int MailId { get; set; }

    public DateTime ReceivedOn { get; set; }

    public string Subject { get; set; }
  }
}