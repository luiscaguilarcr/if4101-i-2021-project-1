using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SPA.Models.Entities
{
    public partial class ScheduleGroupScheduleProfessor
    {
        public int AttendanceScheduleId { get; set; }
        public int GroupId { get; set; }
        public int ProfessorId { get; set; }
        public int CourseId { get; set; }

        public virtual AttendanceSchedule AttendanceSchedule { get; set; }
        public virtual Course Course { get; set; }
        public virtual Group Group { get; set; }
    }
}
