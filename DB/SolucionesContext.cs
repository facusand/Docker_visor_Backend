using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class SolucionesContext : DbContext
    {
        public SolucionesContext(DbContextOptions<SolucionesContext> options)
            : base(options)
        {
            
        }
        public DbSet<Trabajo> Trabajos { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<TrabajoImage> TrabajosImages { get; set; }
        public DbSet<Catalogo> Catalogos { get; set; }
        public DbSet<PubliImage> PubliImages { get; set; }


        public DbSet<User> Users { get; set; }

        // Nuevas tablas para el proyecto Visor de TV
        public DbSet<WeatherData> WeatherData { get; set; }
        public DbSet<LiveCamera> LiveCameras { get; set; }
        public DbSet<SocialPost> SocialPosts { get; set; }
        public DbSet<TVConfig> TVConfigs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trabajo>().ToTable("Trabajo");
            modelBuilder.Entity<Image>().ToTable("Image");
            modelBuilder.Entity<TrabajoImage>().ToTable("TrabajoImage");
            modelBuilder.Entity<Catalogo>().ToTable("Catalogo");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<PubliImage>().ToTable("PubliImage");

            // Configuración de las nuevas tablas
            modelBuilder.Entity<WeatherData>().ToTable("WeatherData");
            modelBuilder.Entity<LiveCamera>().ToTable("LiveCamera");
            modelBuilder.Entity<SocialPost>().ToTable("SocialPost");
            modelBuilder.Entity<TVConfig>().ToTable("TVConfig");
        }

    }
}