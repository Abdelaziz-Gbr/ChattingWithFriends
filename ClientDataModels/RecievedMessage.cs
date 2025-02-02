using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataModels
{
    public class RecievedMessage
    {
        public int msg_id {  get; set; }

        public int sender_id { get; set; }

        public DateTime msg_time { get; set; }
        public string msg_body{ get; set; }

        public override string ToString()
        {
            return $"@{msg_time}:{Environment.NewLine}{msg_body}";
        }

    }
}
