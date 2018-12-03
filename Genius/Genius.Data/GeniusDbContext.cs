namespace Genius.Data
{
    using Genius.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class GeniusDbContext : IdentityDbContext
    {
        public GeniusDbContext(DbContextOptions<GeniusDbContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Annotation> Annotations { get; set; }

        public DbSet<UserAnnotationVote> UserAnnotationVotes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Keys

            builder.Entity<UserAnnotationVote>()
                .HasKey(table => new { table.UserId, table.AnnotationId });

            // Relationships

            builder
                .Entity<Artist>()
                .HasMany(a => a.Albums)
                .WithOne(a => a.Artist)
                .HasForeignKey(a => a.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Album>()
                .HasMany(a => a.Songs)
                .WithOne(s => s.Album)
                .HasForeignKey(s => s.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Song>()
                .HasMany(s => s.Annotations)
                .WithOne(a => a.Song)
                .HasForeignKey(a => a.SongId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<User>()
                .HasMany(u => u.AnnotationVotes)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Annotation>()
                .HasMany(a => a.Votes)
                .WithOne(a => a.Annotation)
                .HasForeignKey(a => a.AnnotationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed

            builder
                .Entity<IdentityRole>()
                .HasData(new IdentityRole() { Name = "Admin", NormalizedName = "Admin" });
        }
    }
}
