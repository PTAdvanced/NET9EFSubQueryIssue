using Microsoft.EntityFrameworkCore;

namespace EFSampleCode
{
    public class Blog
    {
        public int BlogId { get; set; }
        public List<Post> Posts { get; } = new();
        public string Url { get; set; }
    }

    public class BloggingContext : DbContext
    {
        public BloggingContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "blogging.db");
        }

        public DbSet<Blog> Blogs { get; set; }
        public string DbPath { get; }
        public DbSet<Post> Posts { get; set; }

        // The following configures EF to create a Sqlite database file in the special "local"
        // folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class Post
    {
        public Blog Blog { get; set; }
        public int BlogId { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; }
    }
}