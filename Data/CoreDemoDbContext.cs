using CoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreDemo.Data
{
    public class CoreDemoDbContext:DbContext
    {
        public CoreDemoDbContext(DbContextOptions<CoreDemoDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> employees { get; set; }

        public DbSet<Department> departments { get; set; }
    }
}
