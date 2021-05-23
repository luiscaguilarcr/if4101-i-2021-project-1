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
        public List<Entities.Admin> GetAdmin()
        {
            List<Entities.Admin> admin = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                admin = context.Admins.Select(adminItem => new Entities.Admin()
                {
                    ProfessorId = adminItem.ProfessorId

                }).ToList<Entities.Admin>();
            }


            return admin;
        }

        public Entities.Professor GetAdminByCode(string code)
        {
            ProfessorDAO professorDAO = new ProfessorDAO();
            List<Entities.Admin> admins = GetAdmin();

            if (professorDAO.GetProfessorByCode(code)!= null)
            {
                Professor professor = professorDAO.GetProfessorByCode(code);
                
                foreach(Admin admin in admins){
                    if (professor.Id.Equals(admin.ProfessorId))
                    {
                        return professor;
                    }
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
        
    }
}
