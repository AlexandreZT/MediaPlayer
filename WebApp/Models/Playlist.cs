using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaPlayer.Models
{
    /* Une table */
    public class Playlist
    {
        /* Les colonnes */
        public int Id { get; set; }
        public string PlaylistTitle { get; set; }
        // public List<Music> Musics { get; set; }
        public int IdUser { get; set; }

    }
}
