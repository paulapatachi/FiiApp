using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiiApp.Dashboard.Models
{
  public class FiiAppEmailModel
  {
    public string FromEmail { get; set; }
    public string FromName { get; set; }
    public string Body { get; set; }
    public string Subject { get; set; }
    public IEnumerable<string> ToEmail { get; set; }
    public IEnumerable<string> CcEmail { get; set; }
    public IEnumerable<EmailAttachmentModel> Attachments { get; set; }
  }
}
