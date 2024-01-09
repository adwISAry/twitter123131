using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Business.ExternalServices.Interfaces
{
    public interface IEmailService
    {
        public void SendEmail(string to, string header, string body, bool isHtml = true);
    }
}
