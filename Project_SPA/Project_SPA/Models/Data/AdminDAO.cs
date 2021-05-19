

using Microsoft.EntityFrameworkCore;
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

        /*public List<Entities.Admin> GetAdmin()
        {
            List<Entities.Admin> admin = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                admin = context.Admin.Select(adminItem => new Entities.Admin()
                {
                    Id = adminItem.Id,
                    Code = adminItem.Code,
                    Name = adminItem.Name,
                    Email = adminItem.Email,
                    Password = adminItem.Password,
                }).ToList<Entities.Admin>();
            }

            return professor;
        }

        public IEnumerable<Entities.Admin> GetEF()
        {
            var admin = _context.Professors;
            return admin.ToList();
        }

        public int Add(Entities.Admin admin)
        {
            int resultToReturn;
            try
            {
                _context.Add(admin);
                resultToReturn = _context.SaveChangesAsync().Result;
            }

            catch (DbUpdateException)
            {

                throw;

            }
            return resultToReturn;

        }

        public int Remove(int id) //PRUEBA DISTINTA AL PROFE
        {
            int resultToReturn;
            var adminToRemove = _context.Admin.Find(id);
            _context.Admin.Remove(adminToRemove);
            resultToReturn = _context.SaveChangesAsync().Result;

            return resultToReturn;

        }

        public int Edit(Entities.Admin admin)
        {
            int resultToReturn = 0;

            try
            {
                if (!AdminExists(admin.Id))
                {
                    _context.Update(admin);
                    resultToReturn = _context.SaveChangesAsync().Result;
                }

            }
            catch (DbUpdateException)
            {

                throw;

            }

            return resultToReturn;

        }
        private bool AdminExists(int id)
        {
            return _context.Professors.Any(e => e.Id == id);
        }
        */
    }
}
