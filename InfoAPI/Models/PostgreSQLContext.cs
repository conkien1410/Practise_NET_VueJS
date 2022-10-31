using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace InfoAPI.Models {
    public class PostgresSQLContext : DbContext {

           
        protected readonly IConfiguration Configuration;


        public PostgresSQLContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase")).UseSnakeCaseNamingConvention();
        }

        protected void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Person>();
    
        }


        public DbSet<Person> Person { get; set; } = null!;
    }
}