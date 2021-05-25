using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project_SPA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SPA.Models.Data
{
    public class StudentDAO
    {
        private readonly IF4101_2021_SPAContext _context;

        public StudentDAO(IF4101_2021_SPAContext context)
        {
            _context = context;
        }

        public StudentDAO()
        {

        }

        public List<Entities.Student> GetStudents()
        {
            List<Entities.Student> students = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                students = context.Students.Select(studentItem => new Entities.Student()
                  {
                      Id = studentItem.Id,
                      Code = studentItem.Code,
                      Name = studentItem.Name,
                      Email = studentItem.Email,
                      Password = studentItem.Password

                  }).ToList<Entities.Student>();
            }

            return students;
        }

        public List<Entities.TemporalStudent> GetTemporal()
        {
            List<Entities.TemporalStudent> students = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                students = context.TemporalStudents.Select(studentItem => new Entities.TemporalStudent()
                {
                    Id = studentItem.Id,
                    Code = studentItem.Code,
                    Name = studentItem.Name,
                    Email = studentItem.Email,
                    Password = studentItem.Password

                }).ToList<Entities.TemporalStudent>();
            }

            return students;
        }

        public Entities.Student GetStudentByCode(string code)
        {
            List<Entities.Student> students = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                students = context.Students.Select(studentItem => new Entities.Student()
                {
                    Id = studentItem.Id,
                    Code = studentItem.Code,
                    Name = studentItem.Name,
                    Email = studentItem.Email,
                    Password = studentItem.Password

                }).ToList<Entities.Student>();
            }

            foreach (Entities.Student student in students)
            {
                if (student.Code.Equals(code))
                {
                    return student;
                }
            }
            return null;
        }

        public Entities.TemporalStudent GetTemporalStudentByCode(string code)
        {
            List<Entities.TemporalStudent> students = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                students = context.Students.Select(studentItem => new Entities.TemporalStudent()
                {
                    Id = studentItem.Id,
                    Code = studentItem.Code,
                    Name = studentItem.Name,
                    Email = studentItem.Email,
                    Password = studentItem.Password

                }).ToList<Entities.TemporalStudent>();
            }

            foreach (Entities.TemporalStudent student in students)
            {
                if (student.Code.Equals(code))
                {
                    return student;
                }
            }
            return null;
        }

        public Entities.Student GetStudentById(int id)
        {
            List<Entities.Student> students = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                students = context.Students.Select(studentItem => new Entities.Student()
                {
                    Id = studentItem.Id,
                    Code = studentItem.Code,
                    Name = studentItem.Name,
                    Email = studentItem.Email,
                    Password = studentItem.Password

                }).ToList<Entities.Student>();
            }

            foreach (Entities.Student student in students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }

        public Entities.TemporalStudent GetTemporalStudentById(int id)
        {
            List<Entities.TemporalStudent> students = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                students = context.TemporalStudents.Select(studentItem => new Entities.TemporalStudent()
                {
                    Id = studentItem.Id,
                    Code = studentItem.Code,
                    Name = studentItem.Name,
                    Email = studentItem.Email,
                    Password = studentItem.Password

                }).ToList<Entities.TemporalStudent>();
            }

            foreach (Entities.TemporalStudent student in students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }

        public IEnumerable<Entities.Student> GetEF()
        {
            var students = _context.Students;
            return students.ToList();
        }

        public int Add(Entities.Student student)
        {
            int resultToReturn;
            try
            {
                _context.Add(student);
                resultToReturn = _context.SaveChangesAsync().Result;
            }

            catch (DbUpdateException)
            {

                throw;

            }
            return resultToReturn;

        }

        public int AddTemporal(Entities.TemporalStudent student)
        {
            int resultToReturn;
            try
            {
                _context.Add(student);
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
            var studentToRemove = _context.Students.Find(id);
            _context.Students.Remove(studentToRemove);
            resultToReturn = _context.SaveChangesAsync().Result;

            return resultToReturn;

        }

        public int RemoveTemporal(int id)
        {
            int resultToReturn;
            var studentToRemove = _context.TemporalStudents.Find(id);
            _context.TemporalStudents.Remove(studentToRemove);
            resultToReturn = _context.SaveChangesAsync().Result;

            return resultToReturn;

        }

        public int Edit(Entities.Student student)
        {
            int resultToReturn = 0;

            try
            {
                if (!StudentExists(student.Id))
                {
                    _context.Update(student);
                    resultToReturn = _context.SaveChangesAsync().Result;
                }

            }
            catch (DbUpdateException)
            {

                throw;

            }

            return resultToReturn;

        }
        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}