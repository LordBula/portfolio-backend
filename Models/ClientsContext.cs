using Microsoft.EntityFrameworkCore;

namespace DotNetApi.Models
{
    public class ClientsContext: DbContext
    {
        public ClientsContext(DbContextOptions<ClientsContext> options)
        : base(options)
        {
        }

        public DbSet<ClientsItem> ClientsItems { get; set; } = null!;
    }
}
