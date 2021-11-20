using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WebAPI.Persistence
{
    public class WebDbContext : DbContext
    {
        public DbSet<Family> Families { get; set; } 
        public DbSet<User> Users { get; set; }
        // public DbSet<Adult> Adults { get; set; }
        // public DbSet<Job> Jobs { get; set; }
        // public DbSet<Person> Persons { get; set; }
        // public DbSet<Pet> Pets { get; set; }
        // public DbSet<Interest> Interests { get; set; }
        // public DbSet<Child> Children { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // name of database
            optionsBuilder.UseSqlite("Data Source = WebAPI.db");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Interest>().HasKey(interest => interest.Type);
            modelBuilder.Entity<Job>().HasKey(job => job.Id);
        }

        public List<Family> getFamilies()
        {
            return Families.ToList();
        }

        public void removeFamily(Family family)
        {
            Families.ToList().Remove(family);
            Families.Remove(family);
            SaveChanges();
        }

    }
}