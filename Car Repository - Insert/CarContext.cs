using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarProject  //DO NOT Change the namespace name
{
    public class CarContext : DbContext //DO NOT Change the class name
    {
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             // implement the code for configuring connection using connection string name mentioned in appsettings.json file
             IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                
            IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            
            optionsBuilder.UseSqlServer(connectionString);
         }
       
        //Declare 'Cars' of type Dbset and add neccessary declaration code.
        public DbSet<Car> Cars { get; set; }
    }
}