using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SPA.Models.Entities
{
    public partial class Group
    {
        public Group()
        {
            AttendanceProfessorCourseGroups = new HashSet<AttendanceProfessorCourseGroup>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public int CourseId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<AttendanceProfessorCourseGroup> AttendanceProfessorCourseGroups { get; set; }
    }
}
