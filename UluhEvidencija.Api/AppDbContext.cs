using Microsoft.EntityFrameworkCore;
using UluhEvidencija.Contract.Models;

namespace UluhEvidencija.Api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(builder =>
            {
                builder.HasKey(a => a.ID);
                builder.Property(a => a.FreeFormAddress).IsRequired();
            });

            modelBuilder.Entity<LocationType>(builder =>
            {
                builder.HasKey(lt => lt.ID);
                builder.Property(lt => lt.Name).IsRequired();
                builder.Property(lt => lt.Description);
            });
            modelBuilder.Entity<Location>(builder =>
            {
                builder.HasKey(l => l.ID);
                builder.Property(l => l.Name).IsRequired();
                builder.Property(l => l.Description);
                builder.Property(l => l.MaxCapacity).IsRequired();
                builder.Property(l => l.LocationTypeID).IsRequired();
                builder.Property(l => l.AddressID).IsRequired();
                builder.HasOne(l => l.LocationType).WithMany(lt => lt.Locations).HasForeignKey(l => l.LocationTypeID);
                builder.HasOne(l => l.Address).WithMany(a => a.Locations).HasForeignKey(l => l.AddressID);
            });
        }
    }
}
