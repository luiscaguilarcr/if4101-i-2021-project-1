using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SPA.Models.Entities
{
    public partial class ProfessorCourseGroup
    {
        public int ProfessorId { get; set; }
        public int CourseId { get; set; }
        public int GorupId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }

        public virtual Professor Professor { get; set; }
    }
}
