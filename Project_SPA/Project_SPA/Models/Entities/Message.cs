using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SPA.Models.Entities
{
    public partial class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }

        public virtual Professor User { get; set; }
        public virtual Student UserNavigation { get; set; }
    }
}
