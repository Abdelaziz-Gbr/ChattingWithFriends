﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataModels
{
    public class Friend
    {
        public int id {  get; set; }
        public string username {  get; set; }

        public override string ToString()
        {
            return username;
        }
    }
}
