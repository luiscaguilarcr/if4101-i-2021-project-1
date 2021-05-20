using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SPA.Models.Entities
{
    public partial class Admin
    {
        public int ProfessorId { get; set; }

        public virtual Professor Professor { get; set; }
    }
}
