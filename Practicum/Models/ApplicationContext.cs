using Microsoft.EntityFrameworkCore;

namespace MVP.Models
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<FileData> Projects { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasMany(a => a.Projects)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
