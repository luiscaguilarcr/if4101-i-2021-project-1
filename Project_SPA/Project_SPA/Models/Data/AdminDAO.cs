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
                admin = context.Admins.Select(professorItem => new Entities.Admin()
                {
                    Id = professorItem.Id,
                    Code = professorItem.Code,
                    Name = professorItem.Name,
                    Email = professorItem.Email,
                    Password = professorItem.Password,
                    AcademicDegreeId = professorItem.AcademicDegreeId

                }).ToList<Entities.Admin>();
            }


            return admin;
        }

        public Entities.Admin GetAdminByCode(string code)
        {
            List<Entities.Admin> admins = GetAdmin();

            foreach (Admin admin in admins)
            {
                if (admin.Code.Equals(code))
                {
                    return admin;
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
