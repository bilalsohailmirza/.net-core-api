using finshark.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

// using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace finshark.Data
{
    public class ApplicationDBContext: IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }
        
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}