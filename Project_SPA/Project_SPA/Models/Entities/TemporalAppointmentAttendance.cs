using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SPA.Models.Entities
{
    public partial class TemporalAppointmentAttendance
    {
        public int Id { get; set; }
        public int AttendanceId { get; set; }
        public DateTime StartDateHour { get; set; }
        public DateTime EndDateHour { get; set; }
        public int StudentId { get; set; }
        public int ProfessorId { get; set; }
        public int GroupId { get; set; }
        public int CourseId { get; set; }

        public virtual AttendanceProfessorCourseGroup Attendance { get; set; }
    }
}
