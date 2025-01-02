using finshark.Models;
// using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace finshark.Data
{
    public class ApplicationDBContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}