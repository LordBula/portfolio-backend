using Microsoft.EntityFrameworkCore;

namespace DotNetApi.Models
{
    public class aboutMeContext: DbContext
    {
        public aboutMeContext(DbContextOptions<aboutMeContext> options)
        : base(options)
        {
        }

        public DbSet<aboutMeItem> aboutMeItems { get; set; } = null!;
    }
}
