using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SPA.Models.Entities
{
    public partial class Professor
    {
        public Professor()
        {
            AttendanceProfessorCourseGroups = new HashSet<AttendanceProfessorCourseGroup>();
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int AcademicDegreeId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }

        public virtual ICollection<AttendanceProfessorCourseGroup> AttendanceProfessorCourseGroups { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
