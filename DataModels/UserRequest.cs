using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class UserRequest
    {
        public int reqType { get; set; }
        public string reqBody { get; set; }

        public static UserRequest ParseFromString(string str)
        {
            string[] temp = str.Split('#');
            int header = int.Parse(temp[0]);
            return new UserRequest { reqBody = temp[1], reqType = header };
        }
    }
}
