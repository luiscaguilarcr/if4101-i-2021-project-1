using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SPA.Models.Domain
{
    public class Professor
    {

        private int id;
        private string code;
        private string name;
        private string email;
        private string password;
        private string academic_degree;

        public Professor(int id, string code, string name, string email, string password, string academic_degree)
        {
            this.id = id;
            this.code = code;
            this.name = name;
            this.email = email;
            this.password = password;
            this.academic_degree = academic_degree;
        }

        public int Id { get => id; set => id = value; }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Academic_degree { get => academic_degree; set => academic_degree = value; }
        public string Password { get => password; set => password = value; }
    }
}
