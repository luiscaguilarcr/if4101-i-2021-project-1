using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SPA.Models.Entities
{
    public partial class AttendanceProfessorCourseGroup
    {
        public AttendanceProfessorCourseGroup()
        {
            AppointmentAttendances = new HashSet<AppointmentAttendance>();
            TemporalAppointmentAttendances = new HashSet<TemporalAppointmentAttendance>();
        }

        public int AttendanceScheduleId { get; set; }
        public int GroupId { get; set; }
        public int ProfessorId { get; set; }
        public int CourseId { get; set; }
        public int Id { get; set; }

        public virtual AttendanceSchedule AttendanceSchedule { get; set; }
        public virtual Course Course { get; set; }
        public virtual Group Group { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual ICollection<AppointmentAttendance> AppointmentAttendances { get; set; }
        public virtual ICollection<TemporalAppointmentAttendance> TemporalAppointmentAttendances { get; set; }
    }
}
