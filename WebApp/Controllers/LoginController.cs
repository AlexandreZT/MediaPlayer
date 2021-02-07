using System.Linq;
using MediaPlayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;


namespace MediaPlayer.Controllers
{
    public class LoginController : Controller
    {
        /*private readonly ISession session;
        public LoginController(IHttpContextAccessor httpContextAccessor)
        {
            this.session = httpContextAccessor.HttpContext.Session;
        }*/
        public ActionResult Index()
        {
            return View();
        }

        // Envoie les indentifians de connexion pour se connecter (username / password)
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Debug.WriteLine("Button Login working !");

            using (var db = new MediaPlayerDbContext())
            {
                var connected = false;
                foreach (var User in db.Users) // peut être optimisé imo
                {
                    if (User.Username == username && User.Password == password) // créer une connexion
                    {
                        Debug.WriteLine($"Vous êtes connecté {username}");

                        HttpContext.Session.SetInt32("Id", User.Id); // création d'une session

                        if (HttpContext.Session.GetInt32("Id") != null)
                        {
                            Debug.WriteLine(HttpContext.Session.GetInt32("Id"));
                            return RedirectToAction("Index", "MusicPlayer");
                        }
                        connected = true;
                    }
                    if (!connected)
                    {
                        Debug.WriteLine("Nom d'utilistaur ou mot de passe incorrecte");
                        ViewData["error"] = "Nom d'utilistaur ou mot de passe incorrecte";
                    }

                }
            }
            return View("index");
        }
        public ActionResult Logout() // Déconnexion
        {
            // HttpContext.Session.Remove("Id");  // supprime l'id de session

            HttpContext.Session.Clear(); // supprime toutes les données de session (dont "Id")

            return RedirectToAction("Index", "Home");
        }

    }
}