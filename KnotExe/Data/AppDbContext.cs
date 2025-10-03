using KnotExe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using static KnotExe.Models.Post;

namespace KnotExe.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> tblUsuario { get; set; }
        public DbSet<Post> tblPost { get; set; }

    }
}
