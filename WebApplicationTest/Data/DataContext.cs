using Microsoft.EntityFrameworkCore;
using WebApplicationTest.Models;

namespace WebApplicationTest.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) 
        {
            
        }

        public DbSet<SuperHero> SuperHeroesGroup { get; set; }
       // public DbSet<OneMore> OneMoresGroup { get; set; }
    }
}
