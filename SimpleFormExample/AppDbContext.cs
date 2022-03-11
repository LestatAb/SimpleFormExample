using SimpleFormExample.Entities;
using System.Data.Entity;

namespace SimpleFormExample
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        {
        }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}