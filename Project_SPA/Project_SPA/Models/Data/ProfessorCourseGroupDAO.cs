using Project_SPA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SPA.Models.Data
{
    public class ProfessorCourseGroupDAO
    {
        private readonly IF4101_2021_SPAContext _context;

        public ProfessorCourseGroupDAO(IF4101_2021_SPAContext context)
        {
            _context = context;
        }

        public ProfessorCourseGroupDAO()
        {

        }

        public List<Entities.ProfessorCourseGroup> GetProfessorCourseGroup()
        {
            List<Entities.ProfessorCourseGroup> professors = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                professors = context.ProfessorCourseGroups.Select(professorItem => new Entities.ProfessorCourseGroup()
                {
                    ProfessorId = professorItem.ProfessorId,
                    CourseId = professorItem.CourseId,
                    GorupId = professorItem.GorupId,

                }).ToList<Entities.ProfessorCourseGroup>();
            }

            return professors;
        }

    }
}
