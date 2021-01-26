using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebApp.Controllers
{
    public class RegisterController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // reqûete envoie des informations (username/password) dans la base de donnée (table user)
        // récupère les informations du formulaire
        [HttpPost]
        public ActionResult Register(string username, string password, string repassword)
        {
            // Data received from the form
            Debug.WriteLine($"Button Register working !");
            Debug.WriteLine($"{username}, {password}, {repassword}");

            using (var db = new WebAppDbContext())
            {
                // check if password and the confirmation and the same
                if (password == repassword)
                {
                    var usernameAlreadyTaken = false;
                    foreach (var User in db.Users)
                    {
                        if (username == User.Username)
                        {
                            usernameAlreadyTaken = true;
                        }
                    }

                    /* si le nom d'utilisateur n'est pas déjà dans la base de données,
                    alors ajoute le nouvelle utilisateur dans la base de données */
                    if (usernameAlreadyTaken == false)
                    {
                        db.Users.AddRange(
                        new User
                        {
                            Username = username,
                            Password = password
                        });
                        db.SaveChanges();
                        Debug.WriteLine($"Vous êtes désormais inscrit !");
                        ViewData["info"] = "Vous êtes désormais inscrit !";
                        // var count = db.SaveChanges();
                        // Debug.WriteLine($"{count} record added");
                    }
                    else
                    {
                        Debug.WriteLine($"Le nom d'utilisateur est déjà prit");
                        ViewData["info"] = "Le nom d'utilisateur est déjà prit";
                    }
                }
                else
                {
                    Debug.WriteLine($"Les mots de passe sont différents");
                    ViewData["info"] = "Les mots de passe sont différents";
                }                  
            }                
            return View("index"); // si mot de passe foiré
        }
    }
}