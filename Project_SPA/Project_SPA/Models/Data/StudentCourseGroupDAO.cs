using Project_SPA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SPA.Models.Data
{
    public class StudentCourseGroupDAO
    {
        private readonly IF4101_2021_SPAContext _context;

        public StudentCourseGroupDAO(IF4101_2021_SPAContext context)
        {
            _context = context;
        }

        public StudentCourseGroupDAO()
        {

        }

        
        public List<Entities.StudentCourseGroup> GetStudentsCourseGroup()
        {
            List<Entities.StudentCourseGroup> students = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                students = context.StudentCourseGroups.Select(studentItem => new Entities.StudentCourseGroup()
                {
                    StudentId = studentItem.StudentId,
                    CourseId = studentItem.CourseId,
                    GroupId = studentItem.GroupId,

                }).ToList<Entities.StudentCourseGroup>();
            }

            return students;
        }

        public List<Entities.Group> GetGroup()
        {
            List<Entities.Group> groups = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                groups = context.Groups.Select(groupItem => new Entities.Group()
                {
                    Id = groupItem.Id,
                    Code = groupItem.Code,
                    CourseId = groupItem.CourseId,


                }).ToList<Entities.Group>();
            }

            return groups;
        }

        public Entities.Group GetGroupById(int id)
        {
            List<Entities.Group> groups = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                groups = context.Groups.Select(groupItem => new Entities.Group()
                {
                    Id = groupItem.Id,
                    Code = groupItem.Code,
                    CourseId = groupItem.CourseId,


                }).ToList<Entities.Group>();
            }

            foreach (Entities.Group group in groups)
            {
                if (group.Id == id)
                {
                    return group;
                }
            }
            return null;
        }
    }
}
