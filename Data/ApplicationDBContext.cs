using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finshark.Models;
using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace finshark.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions) // passing parameter to base constructor
        {

        }

        public DbSet<Stock> Stock { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}