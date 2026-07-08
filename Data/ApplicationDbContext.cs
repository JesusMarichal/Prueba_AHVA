using Microsoft.EntityFrameworkCore;

namespace PruebaAHVA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add DbSets here as needed for your application
    }
}
