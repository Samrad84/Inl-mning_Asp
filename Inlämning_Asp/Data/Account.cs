using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_Asp.Data
{
    public class Account
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string[] Roles { get; set; }
    }
}
