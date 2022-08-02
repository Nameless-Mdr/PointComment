using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Point> Points { get; set; }

        public DbSet<Note> Notes { get; set; }
    }
}