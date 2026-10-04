using CriticalConsumer.Models;
using Microsoft.EntityFrameworkCore;

namespace CriticalConsumer.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Exam> Criticals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Environment.GetEnvironmentVariable("MYSQL_CONNECTION_STRING")
                ?? "Server=localhost;Port=3306;Database=exam_db;Uid=root;Pwd=root;";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
