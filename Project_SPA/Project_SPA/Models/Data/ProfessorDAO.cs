using Project_SPA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SPA.Models.Data
{
    public class ProfessorDAO
    {
        private readonly IF4101_2021_SPAContext _context;

        public ProfessorDAO(IF4101_2021_SPAContext context)
        {
            _context = context;
        }

        public ProfessorDAO()
        {

        }

        public IEnumerable<Entities.Student> GetEF()
        {
            var students = _context.Students;
            return students.ToList();
        }
    }
}
