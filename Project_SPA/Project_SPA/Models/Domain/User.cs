using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SPA.Models.Domain
{
    public class User
    {
        private string code;
        private string password;

        public User() { }

        public User(string code, string password)
        {
            this.code = code;
            this.password = password;
        }

        public string Code { get => code; set => code = value; }
        public string Password { get => password; set => password = value; }
    }
}
