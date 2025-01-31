using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataModels
{
    public class MessageModel
    {
        public bool isOut {  get; set; }
        public string message { get; set; }

        public DateTime date { get; set; }

        public bool sent { get; set; }

        public bool seen { get; set; }
    }
}
