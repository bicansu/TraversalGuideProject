using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_EntityLayer.Concrete
{
    public class MailRequest
    {
        public int MailRequestID { get; set; }
        public string Name { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
