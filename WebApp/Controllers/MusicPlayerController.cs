using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using MediaPlayer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Diagnostics;

namespace MediaPlayer.Controllers
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

            using var db = new MediaPlayerDbContext();            
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

                using var db2 = new MediaPlayerDbContext();
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
            using var db = new MediaPlayerDbContext();
            
            switch (code) // les deux premier caractère désignent l'action
            {                
                case "AP":
                    if (String.IsNullOrEmpty(title)) // si on ne donne pas de nom à la playlist lors de sa création
                    {
                        title = "Untitled playlist"; // on lui en donne un par défaut
                    }
                    /*
                     * On récupère l'id courant, et on ajoute le nom passé en valeur
                     */
                    if (true)
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
                    if (!String.IsNullOrEmpty(title))
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
                        // il faut supprimer les fichiers du dossier playlist local avant de le supprimer
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
                        string extension = Path.GetExtension(file.FileName);
                        if (extension == ".mp3" || extension == ".wav")
                        {
                            string folder = Path.Combine(_env.WebRootPath, "media/" + userId + "/" + id);
                            Debug.WriteLine(folder);
                            Debug.WriteLine(file.FileName);
                            if (!Directory.Exists(folder))
                            {
                                Directory.CreateDirectory(folder);
                            }

                            string path = Path.Combine(folder, file.FileName);

                            using (var dispose = new FileStream(Path.Combine(folder, file.FileName), FileMode.Create))
                            {
                                file.CopyTo(dispose);
                            }

                            db.Musics.AddRange(
                            new Music
                            {
                                MusicTitle = file.FileName,
                                IdPlaylist = id
                            });
                            db.SaveChanges();
                        }
                        else
                        {
                            Debug.WriteLine("Le format de fichier n'est pas prit en charge, uniquement .mp3 ou. wav");
                        }
                    }                        
                    Debug.WriteLine("Add music");
                    break;
                case "UM":
                    if (!String.IsNullOrEmpty(title))
                    {
                        try
                        {
                            Music renameMusic = db.Musics.Where(a => a.Id == id).ToArray()[0];
                            string oldMusicTitle = renameMusic.MusicTitle;
                            var playlistId = renameMusic.IdPlaylist;
                            renameMusic.MusicTitle = title;
                            db.Musics.Update(renameMusic);
                            string path = Path.Combine(_env.WebRootPath, "media/" + userId + "/" + playlistId + "/");
                            FileInfo updateFile = new System.IO.FileInfo(path + oldMusicTitle);

                            updateFile.MoveTo(path + title);                
                            db.SaveChanges();
                        } catch(Exception e)
                        {
                            Debug.WriteLine(e);
                        }
                        
                    }

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
                default:
                    Debug.WriteLine("Playlist Management action not recognized");
                    break;  
            }
            return RedirectToAction("Index", "MusicPlayer");
        }       
    }
}