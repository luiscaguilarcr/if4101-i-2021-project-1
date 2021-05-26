using Microsoft.EntityFrameworkCore;
using Project_SPA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SPA.Models.Data
{
    public class AppointmentAttendanceDAO
    {
        private readonly IF4101_2021_SPAContext _context;


        public AppointmentAttendanceDAO(IF4101_2021_SPAContext context)
        {
            _context = context;
        }

        public AppointmentAttendanceDAO()
        {

        }

        public List<Entities.AppointmentAttendance> Get()
        {
            List<Entities.AppointmentAttendance> appointmentAttendance = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                appointmentAttendance = context.AppointmentAttendances.Select(appointmentAttendanceItem => new Entities.AppointmentAttendance()
                {
                    Id = appointmentAttendanceItem.Id,
                    

                }).ToList<Entities.AppointmentAttendance>();
            }

            return appointmentAttendance;
        }

   /*     public Entities.AppointmentAttendance GetById(int id)
        {
            List<Entities.AppointmentAttendance> appointmentAttendances = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                appointmentAttendances = context.AppointmentAttendances.Select(appointmentAttendanceItem => new Entities.AppointmentAttendance()
                {
                    Id = appointmentAttendanceItem.Id,
                    AttendanceId = appointmentAttendanceItem.AttendanceId,
                    StartDateHour = appointmentAttendanceItem.StartDateHour,
                    EndDateHout = appointmentAttendanceItem.EndDateHout,
                    StudentId = appointmentAttendanceItem.StudentId,
                    ProfessorId = appointmentAttendanceItem.ProfessorId,
                    GroupId = appointmentAttendanceItem.GroupId,
                    CourseId = appointmentAttendanceItem.CourseId

                }).ToList<Entities.AppointmentAttendance>();
            }

            foreach (Entities.AppointmentAttendance appointmentAttendance in appointmentAttendances)
            {
                if (appointmentAttendance.Id == id)
                {
                    return appointmentAttendance;
                }
            }
            return null;
        }*/

        public Entities.TemporalAppointmentAttendance GetTemporalById(int id)
        {
            List<Entities.TemporalAppointmentAttendance> appointmentAttendances = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                appointmentAttendances = context.TemporalAppointmentAttendances.Select(temporalAppointmentAttendanceItem => new Entities.TemporalAppointmentAttendance()
                {
                    Id = temporalAppointmentAttendanceItem.Id,
                    AttendanceId = temporalAppointmentAttendanceItem.AttendanceId,
                    StartDateHour = temporalAppointmentAttendanceItem.StartDateHour,
                    EndDateHour = temporalAppointmentAttendanceItem.EndDateHour,
                    StudentId = temporalAppointmentAttendanceItem.StudentId,
                    ProfessorId = temporalAppointmentAttendanceItem.ProfessorId,
                    GroupId = temporalAppointmentAttendanceItem.GroupId,
                    CourseId = temporalAppointmentAttendanceItem.CourseId

                }).ToList<Entities.TemporalAppointmentAttendance>();
            }

            foreach (Entities.TemporalAppointmentAttendance appointmentAttendance in appointmentAttendances)
            {
                if (appointmentAttendance.Id == id)
                {
                    return appointmentAttendance;
                }
            }
            return null;
        }

        public IEnumerable<Entities.AppointmentAttendance> GetEF()
        {
            var AppointmentAttendance = _context.AppointmentAttendances;
            return AppointmentAttendance.ToList();
        }

        public int Add(Entities.AppointmentAttendance appointmentAttendance)
        {
            int resultToReturn;
            try
            {
                _context.Add(appointmentAttendance);
                resultToReturn = _context.SaveChangesAsync().Result;
            }

            catch (DbUpdateException)
            {

                throw;

            }
            return resultToReturn;

        }

        public int AddTemporal(Entities.TemporalAppointmentAttendance appointmentAttendance)
        {
            int resultToReturn;
            try
            {
                _context.Add(appointmentAttendance);
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
            var appointmentAttendanceToRemove = _context.AppointmentAttendances.Find(id);
            _context.AppointmentAttendances.Remove(appointmentAttendanceToRemove);
            resultToReturn = _context.SaveChangesAsync().Result;

            return resultToReturn;

        }

        public int RemoveTemporal(int id)
        {
            int resultToReturn;
            var appointmentAttendanceToRemove = _context.TemporalAppointmentAttendances.Find(id);
            _context.TemporalAppointmentAttendances.Remove(appointmentAttendanceToRemove);
            resultToReturn = _context.SaveChangesAsync().Result;

            return resultToReturn;

        }

        private bool AppointmentAttendanceExists(int id)
        {
            return _context.AppointmentAttendances.Any(e => e.Id == id);
        }
    }
}
