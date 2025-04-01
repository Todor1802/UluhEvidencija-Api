using Microsoft.EntityFrameworkCore;
using UluhEvidencija.Contract.Models;

namespace UluhEvidencija.Migration
{
    public class AppDbContext : DbContext
    {
        public DbSet<Painting> Paintings { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<ExhibitionPainting> ExhibitionPaintings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Technique> Techniques { get; set; }
        public DbSet<Format> Formats { get; set; }

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
            modelBuilder.Entity<Exhibition>(builder =>
            {
                builder.HasKey(e => e.ID);
                builder.Property(e => e.Title).IsRequired();
                builder.Property(e => e.Description);
                builder.Property(e => e.StartDate).IsRequired();
                builder.Property(e => e.EndDate);
                builder.Property(e => e.CoverImagePath);
                builder.Property(e => e.IsActive).IsRequired();
                builder.Property(e => e.LocationID).IsRequired();
                builder.HasOne(e => e.Location).WithMany(l => l.Exhibitions).HasForeignKey(e => e.LocationID);
            });
            modelBuilder.Entity<ExhibitionPainting>(builder =>
            {
                builder.HasKey(ep => new { ep.ExhibitionID, ep.PaintingID });
                builder.Property(e => e.DisplayOrder);
                builder.HasOne(ep => ep.Exhibition).WithMany(e => e.ExhibitionPaintings).HasForeignKey(ep => ep.ExhibitionID);
                builder.HasOne(ep => ep.Painting).WithMany(p => p.ExhibitionPaintings).HasForeignKey(ep => ep.PaintingID);
            });
            modelBuilder.Entity<Painting>(builder =>
            {
                builder.HasKey(p => p.ID);
                builder.Property(p => p.Title).IsRequired();
                builder.Property(p => p.Year).IsRequired();
                builder.Property(p => p.PhotoPath).IsRequired();
                builder.Property(p => p.AuthorID);
                builder.Property(p => p.TechniqueID);
                builder.Property(p => p.FormatID);
                builder.Property(p => p.Description);
                builder.HasOne(p => p.Author).WithMany(a => a.Paintings).HasForeignKey(p => p.AuthorID);
                builder.HasOne(p => p.Technique).WithMany(t => t.Paintings).HasForeignKey(p => p.TechniqueID);
                builder.HasOne(p => p.Format).WithMany(f => f.Paintings).HasForeignKey(p => p.FormatID);
            });
            modelBuilder.Entity<Author>(builder =>
            {
                builder.HasKey(a => a.ID);
                builder.Property(a => a.FirstName).IsRequired();
                builder.Property(a => a.LastName).IsRequired();
                builder.Property(a => a.BirthDate);
                builder.Property(a => a.DeathDate);
                builder.Property(a => a.ProfilePhotoPath);
            });
            modelBuilder.Entity<Technique>(builder =>
            {
                builder.HasKey(t => t.ID);
                builder.Property(t => t.Name).IsRequired();
                builder.Property(t => t.Description);
            });
            modelBuilder.Entity<Format>(builder =>
            {
                builder.HasKey(f => f.ID);
                builder.Property(f => f.Name).IsRequired();
                builder.Property(f => f.WidthCm).HasPrecision(5, 2);
                builder.Property(f => f.HeightCm).HasPrecision(5, 2);
            });

            modelBuilder.Entity<Address>().ToTable("Addresses");
            modelBuilder.Entity<LocationType>().ToTable("LocationTypes");
            modelBuilder.Entity<Location>().ToTable("Locations");
            modelBuilder.Entity<Exhibition>().ToTable("Exhibitions");
            modelBuilder.Entity<ExhibitionPainting>().ToTable("ExhibitionPaintings");
            modelBuilder.Entity<Painting>().ToTable("Paintings");
            modelBuilder.Entity<Author>().ToTable("Authors");
            modelBuilder.Entity<Technique>().ToTable("Techniques");
            modelBuilder.Entity<Format>().ToTable("Formats");

        }
    }
}
