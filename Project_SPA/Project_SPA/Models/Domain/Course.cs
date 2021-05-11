using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SPA.Models.Domain
{
    public class Course
    {

        private int id;
        private string code;
        private string name;
        private string credits;
        private string semester;
        private int year;

        public Course() {
        }

        public Course(int id, string code, string name, string credits, string semester, int year)
        {
            this.id = id;
            this.code = code;
            this.name = name;
            this.credits = credits;
            this.semester = semester;
            this.year = year;
        }
    }
}
