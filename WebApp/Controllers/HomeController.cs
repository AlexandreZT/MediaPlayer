using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISession session;
        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            this.session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult Index()
        { 
            // Si un utilisteur est connecté, alors afficher la view playlist
            if (HttpContext.Session.GetInt32("Id") != null)
            {
                return RedirectToAction("Index", "MusicPlayer");
            }
            // sinon la view home page
            else
            {
                return View();
            }            
        }       
    }
}
