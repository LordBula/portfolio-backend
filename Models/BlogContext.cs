using Microsoft.EntityFrameworkCore;

namespace DotNetApi.Models
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
        {
        }

        public DbSet<BlogItem> BlogItems { get; set; } = null!;
    }
}
