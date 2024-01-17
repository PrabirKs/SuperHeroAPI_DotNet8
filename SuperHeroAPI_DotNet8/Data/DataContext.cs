using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Entities;

namespace SuperHeroAPI_DotNet8.Data
{
    //DbContext is a class in Entity Framework Core that represents a
    //session with the database and provides APIs for querying and saving data.
    public class DataContext : DbContext
    {   //constructor and pass to the base constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<SuperHero> Superheroes { get; set; }
    }
}
 