﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SPA.Models.Domain
{
    public class User
    {
        private string code;
        private string paswword;

        public string Code { get => code; set => code = value; }
        public string Paswword { get => paswword; set => paswword = value; }
    }
}
