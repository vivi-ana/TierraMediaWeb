using Microsoft.EntityFrameworkCore;
using TierraMediaWeb.Pages.Account;

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
