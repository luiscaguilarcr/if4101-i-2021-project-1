using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Project_SPA.Models.Domain;
using Project_SPA.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Project_SPA.Models.Data
{
    public class AdminDAO
    {
        
        private readonly IF4101_2021_SPAContext _context;

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
 
                if (professor.Code.Equals(code))
                {
                    return professor;
                }

            }

            return null;
        }

        public System.Boolean ValidateAdmin(Professor professor, User user)
        {
            if (professor.Code.Equals(user.Code) && professor.Password.Equals(user.Password))
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Entities.Admin> GetEF()
        {
            var admins = _context.Admins;
            return admins.ToList();
        }

        private bool AdminExists(int id)
        {
            return _context.Admins.Any(e => e.ProfessorId == id);
        }
        
    }
}
