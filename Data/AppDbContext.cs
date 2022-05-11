using Microsoft.EntityFrameworkCore;
using novaAPI.Models;

namespace novaAPI.Data
{
    // Classe que representa o banco de dados
    public class AppDbContext : DbContext
    {
        public DbSet<Api> Apis { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(
                connectionString: "DataSource=app.db;Cache=Shared"); 
    }
}