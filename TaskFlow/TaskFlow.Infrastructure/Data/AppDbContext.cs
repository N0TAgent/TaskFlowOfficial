using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Core.Models;

namespace TaskFlow.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
