using Microsoft.EntityFrameworkCore;
using Zavod.Data;

namespace Zavod.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>()
                .Property(t => t.Tags)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}