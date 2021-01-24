using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{

    /* Une table */
    public class User
    {
        /* Les colonnes */
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
