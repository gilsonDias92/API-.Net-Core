using Microsoft.EntityFrameworkCore;
using Kardex.API.Models;

namespace Kardex.API.Models
{
    public class KardexContext : DbContext
    {
        public KardexContext(DbContextOptions<KardexContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<CardList> CardList { get; set; }
        public DbSet<Produce> Produce { get; set; }
        public DbSet<Board> Board { get; set; }
        public DbSet<Panel> Panel { get; set; }
    }
}
