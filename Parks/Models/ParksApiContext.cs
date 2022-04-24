using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;


namespace ParksApi.Models
{
    public class ParksApiContext : DbContext
    {
        public DbSet<Park> Parks { get; set; }
        public ParksApiContext(DbContextOptions<ParksApiContext> options)  : base(options) { }
        
// Protected override since we only want this method to be accessible to the class itself and we want to override the default method
//Since the method doesn't return anything we specify void as the return value
        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<Park>()
            .HasData(
              new Park{ ParkId = 1, Name = "Etosha", Size = 8600, City = "", State = "", Country = "Namibia" },
              new Park{ ParkId = 2, Name = "Grand Canyon", Size = 1904, City = "", State = "Arizona", Country = "USA" },
              new Park{ ParkId = 3, Name = "Jim Corbett", Size = 201, City = "", State = "Uttarakhand", Country = "India" },
              new Park{ ParkId = 4, Name = "Kruger", Size = 7512, City = "", State = "", Country = "South Africa" },
              new Park{ ParkId = 5, Name = "Dolomiti Bellunesi", Size = 12, City = "", State = "", Country = "Italy" },
              new Park{ ParkId = 6, Name = "Mount Kilimanjaro", Size = 652, City = "Moshi", State = "", Country = "Tanzania" },
              new Park{ ParkId = 7, Name = "Serengeti", Size = 5200, City = "", State = "", Country = "Tanzania" }
             );
        }
    }
}
