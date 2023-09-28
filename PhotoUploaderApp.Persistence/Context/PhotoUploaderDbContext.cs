using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhotoUploaderApp.Domain.Entities;

namespace PhotoUploaderApp.Persistence.Context
{
    public partial class PhotoUploaderDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public PhotoUploaderDbContext(DbContextOptions<PhotoUploaderDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Photo> Photos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("Photo");

                entity.Property(e => e.AddedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
                entity.Property(e => e.Url)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("URL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}