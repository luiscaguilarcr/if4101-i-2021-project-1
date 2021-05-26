using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SPA.Models.Entities
{
    public partial class Course
    {
        public Course()
        {
            AttendanceProfessorCourseGroups = new HashSet<AttendanceProfessorCourseGroup>();
            Groups = new HashSet<Group>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }

        public virtual ICollection<AttendanceProfessorCourseGroup> AttendanceProfessorCourseGroups { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
