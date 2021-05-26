using Microsoft.EntityFrameworkCore;
using Project_SPA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SPA.Models.Data
{
    public class CourseDAO
    {
        private readonly IF4101_2021_SPAContext _context;

        public CourseDAO(IF4101_2021_SPAContext context)
        {
            _context = context;
        }

        public CourseDAO()
        {

        }

        public List<Entities.Course> GetCourse()
        {
            List<Entities.Course> courses = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                courses = context.Courses.Select(courseItem => new Entities.Course()
                {
                    Id = courseItem.Id,
                    Code = courseItem.Code,
                    Name = courseItem.Name,
                    Credits = courseItem.Credits,
                    Semester = courseItem.Semester,
                    Year = courseItem.Year

                }).ToList<Entities.Course>();
            }
            return courses;
        }

        public Entities.Course GetCourseById(int id)
        {
            List<Entities.Course> courses = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                courses = context.Courses.Select(courseItem => new Entities.Course()
                {
                    Id = courseItem.Id,
                    Code = courseItem.Code,
                    Name = courseItem.Name,

                }).ToList<Entities.Course>();
            }

            foreach (Entities.Course course in courses)
            {
                if (course.Id == id)
                {
                    return course;
                }
            }
            return null;
        }

        public IEnumerable<Entities.Course> GetEF()
        {
            var courses = _context.Courses;
            return courses.ToList();
        }


        public int Add(Entities.Course course)
        {
            int resultToReturn;
            try
            {
                _context.Add(course);
                resultToReturn = _context.SaveChangesAsync().Result;
            }

            catch (DbUpdateException)
            {

                throw;

            }
            return resultToReturn;

        }

        public int Remove(int id)
        {
            int resultToReturn;
            var courseToRemove = _context.Courses.Find(id);
            _context.Courses.Remove(courseToRemove);
            resultToReturn = _context.SaveChangesAsync().Result;
            return resultToReturn;
        }

        public int Edit(Entities.Course course)
        {
            int resultToReturn = 0;

            try
            {
                if (!CourseExists(course.Id))
                {
                    _context.Update(course);
                    resultToReturn = _context.SaveChangesAsync().Result;
                }

            }
            catch (DbUpdateException)
            {

                throw;

            }

            return resultToReturn;

        }
        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}