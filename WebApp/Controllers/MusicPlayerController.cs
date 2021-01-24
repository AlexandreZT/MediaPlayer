using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Diagnostics;

namespace WebApp.Controllers
{
    public class MusicPlayerController : Controller
    {        
        public ActionResult Index()
        {
            IList<Playlist> playlist = new List<Playlist>();
            IList<Music> music = new List<Music>();

            // ref id user <-> playlist / ref id playlit <-> music

            using (var db = new WebAppDbContext())
            {
                foreach (var Playlist in db.Playlists)
                {
                    if (Playlist.IdUser == HttpContext.Session.GetInt32("Id"))
                    {
                        Debug.WriteLine($"{Playlist.PlaylistTitle}");
                        playlist.Add(new Playlist() { PlaylistTitle = $"{Playlist.PlaylistTitle}" });
                    }

                    using (var db2 = new WebAppDbContext())
                    {
                        foreach (var Music in db2.Musics)
                        {
                            if (Music.IdPlaylist == Playlist.Id)
                            {
                                Debug.WriteLine($"{Music.MusicTitle}");
                                music.Add(new Music() { MusicTitle = $"{Music.MusicTitle}" });
                            }

                        }
                    }
                }
            }
            
            ViewData["playlists"] = playlist;

            ViewData["musics"] = music;

            return View();
        }

        [HttpPost]
        public ActionResult PlaylistManagement(string action)
        {
            if (action == "addPlaylist"){
                Debug.WriteLine("Create playlist");
            }
            else if (action == "delPlaylist")
            {
                Debug.WriteLine("Delete playlist");
            }            
            return View();
        }

        /*public ActionResult Disconnect() // Déconnexion
        {
            // HttpContext.Session.Remove("Id");  // supprime l'id de session

            HttpContext.Session.Clear(); // supprime toutes les données de session (dont "Id")
            
            return RedirectToAction("Index", "Home");
        }*/

        // récupérer les playlist de la base de données (table playlist)
        // récupérer les musique associés aux playlist (table music)
        // [HttpGet]
        /*public ActionResult Playlist()
        {
            using (var db = new WebAppDbContext())
            {
                foreach (var Playlist in db.Playlists)
                {
                    Debug.WriteLine($"{Playlist}");

                    foreach (var Music in db.Musics)
                    {
                        Debug.WriteLine($"{Music}");
                    }
                }
            }
        }*/

    }
}