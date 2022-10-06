using CD_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace CD_Service.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<CoinLookUp> CoinLookup { get; set; }

    }
}
