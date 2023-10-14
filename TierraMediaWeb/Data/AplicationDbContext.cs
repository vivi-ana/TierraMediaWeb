using Microsoft.EntityFrameworkCore;
using TierraMediaWeb.Models;

namespace TierraMediaWeb.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<UserCredential> UserCredential { get; set; }
    }
}
