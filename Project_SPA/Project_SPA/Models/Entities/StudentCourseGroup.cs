using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SPA.Models.Entities
{
    public partial class StudentCourseGroup
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int GroupId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }

        public virtual Course Course { get; set; }
        public virtual Group Group { get; set; }
        public virtual Student Student { get; set; }
    }
}
