using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SPA.Models.Entities
{
    public partial class DateAttendance
    {
        public int Id { get; set; }
        public int AttendanceId { get; set; }
        public DateTime StartDateHour { get; set; }
        public DateTime EndDateHout { get; set; }
        public int StudentId { get; set; }

        public virtual AttendanceProfessorCourseGroup Attendance { get; set; }
        public virtual Student Student { get; set; }
    }
}
