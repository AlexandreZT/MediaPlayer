using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace MediaPlayer.Models
{
    public class MediaPlayerDbContext : DbContext
    {
        public DbSet <User> Users { get; set; }
        public DbSet <Music> Musics { get; set; }
        public DbSet <Playlist> Playlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Database=WebAppDb;"
                +"Trusted_Connection=True;");
        }

    }
}
