using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SPA.Models.Domain
{
    public class Student
    {

        private int id;
        private string code;
        private string name;
        private string email;
        private string password;

        public Student()
        {

        }

        public Student(int id, string code, string name, string email, string password)
        {
            this.id = id;
            this.code = code;
            this.name = name;
            this.email = email;
            this.password = password;
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Code { get => code; set => code = value; }
    }
}
