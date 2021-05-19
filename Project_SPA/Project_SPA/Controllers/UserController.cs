using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_SPA.Models.Data;
using Project_SPA.Models.Domain;
using Project_SPA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SPA.Controllers
{
    public class UserController : Controller
    {
        AdminDAO adminDAO;
        StudentDAO studentDAO;
        ProfessorDAO professorDAO;

        public IActionResult Index()
        {
            //Get User Info from Session
            var userInfo = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));
            return View();
        }
        private readonly IF4101_2021_SPAContext _context;
        
        
        public UserController(IF4101_2021_SPAContext context)
        {
            
        }

    }
}
