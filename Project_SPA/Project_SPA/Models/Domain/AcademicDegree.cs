using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SPA.Models.Domain
{
    public class AcademicDegree
    {

        private int id;
        private string degree;

        public AcademicDegree(int id, string degree)
        {
            this.id = id;
            this.degree = degree;
        }
        public int Id { get => id; set => id = value; }
        public string Degree { get => degree; set => degree = value; }
    }
}
