using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataModels
{
    public class SendedMessage
    {
        public int msg_id {  get; set; }

        public int reciever_id { get; set; }

        public DateTime msg_time { get; set; }

        public bool seen {  get; set; }

        public bool recieved { get; set; }

        public string msg_body { get; set; }
    }
}
