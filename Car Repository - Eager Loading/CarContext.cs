using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CarProject  //DO NOT Change the namespace name
{
    public class CarContext : DbContext //DO NOT Change the class name
    {
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             IConfigurationBuilder builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                 
             IConfigurationRoot configuration = builder.Build();
             string connectionString = configuration.GetConnectionString("DefaultConnection");
             
             optionsBuilder.UseSqlServer(connectionString);
         }
       
        public DbSet<Car> Cars { get; set; }
        public DbSet<Make> Makes { get; set; }
    }
}