using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SPA.Models.Entities
{
    public partial class AttendanceSchedule
    {
        public AttendanceSchedule()
        {
            AttendanceProfessorCourseGroups = new HashSet<AttendanceProfessorCourseGroup>();
        }

        public int Id { get; set; }
        public int StartDateHour { get; set; }
        public int EndDateHour { get; set; }

        public virtual ICollection<AttendanceProfessorCourseGroup> AttendanceProfessorCourseGroups { get; set; }
    }
}
