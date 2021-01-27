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
        private IWebHostEnvironment _env;

        public MusicPlayerController(IWebHostEnvironment env)
        {
            _env = env;
        }
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Id") is null) // Si on est pas connecté mais qu'on tente d'accdécer à la page à partir d'un lien
            {
                return RedirectToAction("Index", "Home"); // On est redirigé à l'accueil
            }
            IList<Playlist> playlist = new List<Playlist>();
            IList<Music> music = new List<Music>();
            // IDictionary<Music, Playlist> relation = new Dictionary<Music, Playlist>();
            // ref id user <-> playlist / ref id playlit <-> music

            using var db = new WebAppDbContext();            
            foreach (var Playlist in db.Playlists)
            {
                if (Playlist.IdUser == HttpContext.Session.GetInt32("Id"))
                {
                    // Debug.WriteLine($"{Playlist.PlaylistTitle}");
                    playlist.Add(new Playlist() { 
                        Id = Playlist.Id,
                        PlaylistTitle = $"{Playlist.PlaylistTitle}",
                        IdUser = Playlist.IdUser
                    });
                }

                using var db2 = new WebAppDbContext();
                foreach (var Music in db2.Musics)
                {
                    if (Music.IdPlaylist == Playlist.Id)
                    {
                        // Debug.WriteLine($"{Music.MusicTitle}");
                        music.Add(new Music()
                        {
                            Id = Music.Id,
                            MusicTitle = $"{Music.MusicTitle}",
                            IdPlaylist = Music.IdPlaylist
                        });
                    }
                }
            }
            ViewData["playlists"] = playlist;
            ViewData["musics"] = music;
            return View();
        }

        [HttpGet]
        public ActionResult DisplayChoosenPlaylist()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PlaylistManagement(string action, string title, IFormFile file) // récupère seulement les données désirées d'un formulaire
        {
            Debug.WriteLine("Action request send !");
            Debug.WriteLine("action: " + action);
            //Debug.WriteLine("Request.Form: "+ Request.Form["action"]);
            Debug.WriteLine("title: " + title);            
            string code = action.Substring(0, 2);
            var id = Int32.Parse(action.Substring(3, action.Length - 4));
            Debug.WriteLine(code);
            Debug.WriteLine(id);
            var userId = HttpContext.Session.GetInt32("Id");
            using var db = new WebAppDbContext();
            
            switch (code) // les deux premier caractère designe l'action
            {                
                case "AP":
                    if (String.IsNullOrEmpty(title))
                    {
                        title = "Untitled playlist";
                    }
                    /*
                     * On récupère l'id courant, et on ajoute le nom passé en valeur
                     */
                        /*var playlistTitleAlreadyTaken = false;
                        foreach (var playlist in db.Playlists)
                        {
                            if (userId == playlist.IdUser)
                            {
                                if (newPlaylistTitle == playlist.PlaylistTitle)
                                {
                                    playlistTitleAlreadyTaken = true;
                                }    
                            }
                        }*/
                    if (true) // !playlistTitleAlreadyTaken
                    {
                        db.Playlists.AddRange(
                        new Playlist
                        {
                            PlaylistTitle = title,
                            IdUser = (int)userId
                        });
                        db.SaveChanges();
                    }
                    Debug.WriteLine("Create playlist");                    
                    break;
                case "UP":
                    var newPlaylistTitleIsTaken = false;

                    /*foreach (var playlist in db.Playlists)
                    {
                        if (userId == playlist.IdUser)
                        {
                            if (title == playlist.PlaylistTitle)
                            {
                                newPlaylistTitleIsTaken = true;
                            }
                        }
                    }*/
                    
                    if (newPlaylistTitleIsTaken == false && (!String.IsNullOrEmpty(title)))
                    {
                        Playlist updatePlaylist = db.Playlists.Where(a => a.Id == id && a.IdUser == userId).ToArray()[0];
                        updatePlaylist.PlaylistTitle = title;
                        db.Playlists.Update(updatePlaylist);
                        db.SaveChanges();
                    }
                    Debug.WriteLine("Rename playlist");
                    /*
                     * On récupère l'id courant, et on remplace le nom de la playlist par le nouveau passé en valeur
                     */
                    break;
                case "DP":
                    /*var playlistTitleCanBeRemoved = false;
                    foreach (var playlist in db.Playlists)
                    {
                        if (userId == playlist.IdUser)
                        {
                            if (newPlaylistTitle == playlist.PlaylistTitle)
                            {
                                playlistTitleCanBeRemoved = true;
                            }
                        }
                    }
                    if (playlistTitleCanBeRemoved)
                    {
                        Playlist removePlaylist = db.Playlists.Where(a => a.Id == id && a.IdUser == userId).ToArray()[0];
                        db.Playlists.Remove(removePlaylist);
                        db.SaveChanges();                        
                    }*/

                    Playlist removePlaylist = db.Playlists.Where(a => a.Id == id && a.IdUser == userId).ToArray()[0];
                    db.Playlists.Remove(removePlaylist);
                    try // si la playlist est vide ça ne fonctionnera pas
                    {
                        Music associatedMusicsInTheRemovedPlaylist = db.Musics.Where(a => a.IdPlaylist == id).ToArray()[0];
                        db.Musics.RemoveRange(associatedMusicsInTheRemovedPlaylist);
                        string folder = Path.Combine(_env.WebRootPath, "media/" + userId + "/" + id);
                        Debug.WriteLine(folder);
                        // Debug.WriteLine(file.FileName);
                        // Debug.WriteLine(Directory.EnumerateFiles(folder));
                    }                        
                    catch (Exception)
                    {
                        Debug.WriteLine("");
                    }
                    db.SaveChanges();

                    Debug.WriteLine("Delete playlist");
                    break;
                case "AM":                                         
                    if (file != null && !String.IsNullOrEmpty(file.FileName))
                    {
                        string folder = Path.Combine(_env.WebRootPath, "media/" + userId + "/" + id);
                        Debug.WriteLine(folder);
                        Debug.WriteLine(file.FileName);
                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);                            
                        }

                        file.CopyTo(new FileStream(Path.Combine(folder, file.FileName), FileMode.Create));

                        db.Musics.AddRange(
                        new Music
                        {
                            MusicTitle = file.FileName,
                            IdPlaylist = id
                        });
                        db.SaveChanges();
                    }
                    Debug.WriteLine("Add music");
                    break;
                case "UM":
                    if (!String.IsNullOrEmpty(title))
                    {
                        Music renameMusic = db.Musics.Where(a => a.Id == id).ToArray()[0];
                        string oldMusicTitle = renameMusic.MusicTitle;
                        var playlistId = renameMusic.IdPlaylist;
                        renameMusic.MusicTitle = title;
                        db.Musics.Update(renameMusic);
                        string path = Path.Combine(_env.WebRootPath, "media/" + userId + "/" + playlistId + "/");
                        FileInfo updateFile = new System.IO.FileInfo(path + oldMusicTitle);
                        updateFile.MoveTo(path + title);     // attention s'il est inUse à ne pas supprimer -> correction à faire                  
                        db.SaveChanges();
                    }
                    
                    // check oldMusicTitle
                    // changes with title
                    // renameMusic.IdPlaylist;
                    Debug.WriteLine("Rename music");
                    break;
                case "DM":
                    if (true)
                    {
                        Music deleteMusic = db.Musics.Where(a => a.Id == id).ToArray()[0];
                        db.Musics.Remove(deleteMusic);
                        db.SaveChanges();
                    }
                    Debug.WriteLine("Delete music");
                    break;
                case "PP":
                    Debug.WriteLine("Play playlist");
                    break;
                default:
                    Debug.WriteLine("Playlist Management action not recognized");
                    break;  
            }
            return RedirectToAction("Index", "MusicPlayer");
        }

        [HttpPost]
        public ActionResult UploadMusicInSelectedPlaylist()
        {
            return View();
        }

        public ActionResult PlayPlaylist()
        {

            Debug.WriteLine("ok pp");
            return View();
        }

        // récupérer les musique associés aux playlist (table music)
        /*[HttpGet]
        public ActionResult getMusicFromPlaylist(int playlistId)
        {
            using (var db = new WebAppDbContext())
            {
                foreach (var Music in db.Musics)
                {
                    if (playlistId == Music.IdPlaylist)
                    {
                        Debug.WriteLine($"{Music.MusicTitle}");
                    }
                }
            }
            return RedirectToAction("Index", "MusicPlayer");
        }*/
    }
}