using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Blogify.Models
{
    public class BlogifyContext : DbContext
    {
        public BlogifyContext() {}
        public BlogifyContext(DbContextOptions<BlogifyContext> options) : base (options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-514ED7U\\SQLEXPRESS;Database=BlogifyDb;User Id=MuhammetErenCelik;Password=113411;TrustServerCertificate=True;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Bildiri> Bildiris { get; set; }
    }
}