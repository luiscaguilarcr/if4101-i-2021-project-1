using System;
using System.Collections.Generic;

#nullable disable

namespace Project_API.Models.Entities
{
    public partial class News
    {
        public News()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string NewsTitle { get; set; }
        public string Descrip { get; set; }
        public byte[] Image { get; set; }
        public byte[] File { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
