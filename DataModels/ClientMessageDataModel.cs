using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    internal class ClientMessageDataModel
    {
        public int id {  get; set; }
        public string message { get; set; }
        public DateTime time { get; set; }

        public ClientMessageDataModel() { }
    }
}
