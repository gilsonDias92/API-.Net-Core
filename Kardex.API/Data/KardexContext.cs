using Microsoft.EntityFrameworkCore;

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

    }
}
