using Microsoft.EntityFrameworkCore;

namespace Mission06_Tuinei.Models
{
    public class MovieFormContext : DbContext
    {
        // create a class with context options of this type
        // we want options passed in and the options
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base (options)
        {

        }
        public DbSet<Mission06_Tuinei.Models.Application> Applications { get; set; }


    }
}
