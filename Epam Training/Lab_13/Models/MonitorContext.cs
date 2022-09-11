using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Lab_13.Models
{
    public class MonitorContext : DbContext
    {
        public DbSet<Monitor> Monitors { get; set; }

        public MonitorContext(DbContextOptions<MonitorContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
