using CsharpAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CsharpAPI.Data
{
    public class examDb : DbContext
    {
        private readonly DbContextOptions _options;
        public examDb(DbContextOptions options) : base(options)
        {
            _options = options;
        }
        public DbSet<Exam> Criticals => Set<Exam>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Exam>().
                HasKey(x => x.Id);
        }
    }
}
