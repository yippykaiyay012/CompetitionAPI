using CompetitionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CompetitionAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CompetitionResult> CompetitionResults { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
    }


}
