using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class UserRequest
    {
        public int reqType {  get; set; }
        public string reqBody {  get; set; }

        public static UserRequest ParseFromString(string str)
        {
            string[] temp = str.Split('$');
            int header = int.Parse(temp[0]);
            string body = "";
            for (int i = 1; i < temp.Length; i++)
            {
                if (i == temp.Length - 1)
                    body += temp[i];
                else
                    body += temp[i] + "$";
            }
            return new UserRequest { reqBody = body, reqType = header };
        }
    }
}
