using Microsoft.EntityFrameworkCore;

namespace UserLibrary
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public User User { get; set; }

    }

    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class NoteDbContext : DbContext
    {

        /// 数据库文件的路径
        public string DbFilePath { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // 设置数据库文件的路径
            optionsBuilder.UseSqlite($"Data Source={DbFilePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 必填
            modelBuilder.Entity<User>().Property(m => m.UserName).IsRequired();
            modelBuilder.Entity<Note>().Property(m => m.Title).IsRequired();
        }
    }
}

