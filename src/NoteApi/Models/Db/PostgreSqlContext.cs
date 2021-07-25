using Microsoft.EntityFrameworkCore;
namespace NoteApi.Models.Db
{
    public partial class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext()
        {
        }
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options)
            : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });
            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasIndex(e => e.UserId);
            });
            modelBuilder.UseSerialColumns();
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
