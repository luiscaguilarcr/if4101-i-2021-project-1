using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SPA.Models.Entities
{
    public partial class Professor
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int AcademicDegreeId { get; set; }
        public string CreationUser { get; set; }
        public string UpdateUser { get; set; }
    }
}
