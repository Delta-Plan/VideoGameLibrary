using LibraryService.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryService
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
