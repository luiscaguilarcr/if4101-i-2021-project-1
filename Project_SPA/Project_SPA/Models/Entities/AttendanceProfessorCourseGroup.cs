using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SPA.Models.Entities
{
    public partial class AttendanceProfessorCourseGroup
    {
        public int AttendanceScheduleId { get; set; }
        public int GroupId { get; set; }
        public int ProfessorId { get; set; }
        public int CourseId { get; set; }
        public int Id { get; set; }
    }
}
