using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarProject  //DO NOT Change the namespace name
{
    public class CarContext : DbContext//DO NOT Change the class name
    {
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             // implement the code for configuring connection using connection string name mentioned in appsettings.json file
             
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder
                .UseLazyLoadingProxies() // Essential for the objective
                .UseSqlServer(config.GetConnectionString("DefaultConnection"));
         }
       
        //Declare 'Cars' and 'Makes' of type Dbset and add neccessary declaration code.
        
        public DbSet<Car> Cars { get; set; }
        public DbSet<Make> Makes { get; set; }
    }
}