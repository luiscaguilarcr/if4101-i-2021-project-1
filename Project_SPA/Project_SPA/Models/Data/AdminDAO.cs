using Project_SPA.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Project_SPA.Models.Data
{
    public class AdminDAO
    {
        
        private readonly IF4101_2021_SPAContext _context;
        private List<Admin> admins;

        public AdminDAO(IF4101_2021_SPAContext context)
        {
            _context = context;
        }

        public AdminDAO()
        {
        }

        public Entities.Professor GetAdminByCode(string code)
        {
            ProfessorDAO professorDAO = new ProfessorDAO();

            if(professorDAO.GetProfessorByCode(code)!= null)
            {
                Professor professor = professorDAO.GetProfessorByCode(code);

                if (AdminExists(professor.Id))
                {
                    if (professor.Code.Equals(code))
                    {
                        return professor;
                    }

                }
            }

            return null;
        }

        private bool AdminExists(int id)
        {
            return _context.Admins.Any(e => e.ProfessorId == id);
        }
        
    }
}
