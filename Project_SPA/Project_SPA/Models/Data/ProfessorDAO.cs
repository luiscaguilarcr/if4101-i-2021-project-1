using Microsoft.EntityFrameworkCore;
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

        public List<Entities.Professor> GetProfessor()
        {
            List<Entities.Professor> professor = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                professor = context.Professors.Select(professorItem => new Entities.Professor()
                {
                    Id = professorItem.Id,
                    Code = professorItem.Code,
                    Name = professorItem.Name,
                    Email = professorItem.Email,
                    Password = professorItem.Password,
                    AcademicDegreeId = professorItem.AcademicDegreeId

                }).ToList<Entities.Professor>();
            }

            return professor;
        }

        public Entities.Professor GetProfessorByCode(string code)
        {
            List<Entities.Professor> professors = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                professors = context.Professors.Select(professorItem => new Entities.Professor()
                {
                    Id = professorItem.Id,
                    Code = professorItem.Code,
                    Name = professorItem.Name,
                    Email = professorItem.Email,
                    Password = professorItem.Password

                }).ToList<Entities.Professor>();
            }

            foreach (Entities.Professor professor in professors)
            {
                if (professor.Code.Equals(code))
                {
                    return professor;
                }
            }
            return null;
        }

        public IEnumerable<Entities.Professor> GetEF()
        {
            var professor = _context.Professors;
            return professor.ToList();
        }

        public int Add(Entities.Professor professor)
        {
            int resultToReturn;
            try
            {
                _context.Add(professor);
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
            var professorToRemove = _context.Professors.Find(id);
            _context.Professors.Remove(professorToRemove);
            resultToReturn = _context.SaveChangesAsync().Result;

            return resultToReturn;

        }

        public int Edit(Entities.Professor professor)
        {
            int resultToReturn = 0;

            try
            {
                if (!ProfessorExists(professor.Id))
                {
                    _context.Update(professor);
                    resultToReturn = _context.SaveChangesAsync().Result;
                }

            }
            catch (DbUpdateException)
            {

                throw;

            }

            return resultToReturn;

        }
        private bool ProfessorExists(int id)
        {
            return _context.Professors.Any(e => e.Id == id);
        }
    }
}

