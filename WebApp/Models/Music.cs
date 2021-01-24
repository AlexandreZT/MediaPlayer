using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    /* Une table */
    public class Music
    {
        /* Les colonnes */
        public int Id { get; set; }
        public string MusicTitle { get; set; }
        public int IdPlaylist { get; set; }
    }
}
