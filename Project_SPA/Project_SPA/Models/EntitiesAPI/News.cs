using System;
using System.Collections.Generic;

#nullable disable

namespace Project_SPA.Models.EntitiesAPI
{
    public partial class News
    {
        public int Id { get; set; }
        public string NewsTitle { get; set; }
        public string Descrip { get; set; }
        public byte[] Image { get; set; }
        public byte[] File { get; set; }
    }
}
