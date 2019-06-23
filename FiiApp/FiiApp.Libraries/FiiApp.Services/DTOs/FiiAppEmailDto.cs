using System;
using System.Collections.Generic;
using System.Text;

namespace FiiApp.Services.DTOs
{
    public class FiiAppEmailDto
    {
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public IEnumerable<string> ToEmail { get; set; }
        public IEnumerable<string> CcEmail { get; set; }
        public IEnumerable<EmailAttachmentDto> Attachments { get; set; }
    }
}
