using Labb3v4.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3v4.Data
{
    public class MusicContext : DbContext
    {
        //context
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        {
        }
        //wich tables/classes we should use
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Cd> Cd { get; set; }
    }


}
