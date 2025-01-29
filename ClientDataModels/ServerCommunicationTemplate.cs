using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataModels
{
    public class ServerCommunicationTemplate
    {
        public int header {  get; set; }
        public string body { get; set; }

        public static ServerCommunicationTemplate GetLogInTemplate(string username,  string password)
        {
            return new ServerCommunicationTemplate { header = 0, body = $"{username}${password}" };

        }

        public static ServerCommunicationTemplate GetAllClientsRequestTemplate()
        {
            return new ServerCommunicationTemplate { header = 1, body = "" };
        }

        public override string ToString()
        {
            return $"{header}${body}";
        }
    }
}
