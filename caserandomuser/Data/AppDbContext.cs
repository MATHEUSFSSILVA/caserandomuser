
using caserandomuser.Entities;
using Microsoft.EntityFrameworkCore;

namespace caserandomuser.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CadastrosEntity> Cadastros { get; set; }
        public DbSet<CoordinatesEntity> Coordinateses { get; set; }
        public DbSet<DobEntity> Dobs { get; set; }
        public DbSet<IdEntity> Ids { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }
        public DbSet<LoginEntity> Logins { get; set; }
        public DbSet<NameEntity> Names { get; set; }
        public DbSet<PictureEntity> Pictures { get; set; }
        public DbSet<RegisteredEntity> Registereds { get; set; }
        public DbSet<StreetEntity> Streets { get; set; }
        public DbSet<TimezoneEntity> Timezones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CadastrosEntity>()
                .HasOne(l => l.Name)
                .WithOne()
                .HasForeignKey<CadastrosEntity>(c => c.NameEntityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CadastrosEntity>()
                .HasOne(l => l.Location)
                .WithOne()
                .HasForeignKey<CadastrosEntity>(c => c.LocationEntityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CadastrosEntity>()
                .HasOne(l => l.Login)
                .WithOne()
                .HasForeignKey<CadastrosEntity>(c => c.LoginEntityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CadastrosEntity>()
                .HasOne(l => l.Dob)
                .WithOne()
                .HasForeignKey<CadastrosEntity>(c => c.DobEntityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CadastrosEntity>()
                .HasOne(l => l.Registered)
                .WithOne()
                .HasForeignKey<CadastrosEntity>(c => c.RegisteredEntityId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<CadastrosEntity>()
                .HasOne(l => l.Id)
                .WithOne()
                .HasForeignKey<CadastrosEntity>(c => c.IdEntityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CadastrosEntity>()
                .HasOne(l => l.Picture)
                .WithOne()
                .HasForeignKey<CadastrosEntity>(c => c.PictureEntityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LocationEntity>()
                .HasOne(l => l.Street)
                .WithOne()
                .HasForeignKey<LocationEntity>(c => c.StreetEntityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LocationEntity>()
                .HasOne(l => l.Coordinates)
                .WithOne()
                .HasForeignKey<LocationEntity>(c => c.CoordinatesEntityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LocationEntity>()
                .HasOne(l => l.Timezone)
                .WithOne()
                .HasForeignKey<LocationEntity>(c => c.TimezoneEntityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}