using Project_SPA.Models.EntitiesAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SPA.Models.Data
{
    public class CommentsDAO
    {

        private readonly IF4101_SPA_APIContext _context;

        public CommentsDAO(IF4101_SPA_APIContext context)
        {
            _context = context;
        }

        public CommentsDAO()
        {

        }



    }
}
