using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Dados
{
  public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
  {

    public ApplicationDbContext CreateDbContext(string[] args)
        {
        // Build config
            IConfiguration configuration = new ConfigurationBuilder()
                  .SetBasePath(System.AppContext.BaseDirectory)
                  .AddJsonFile("appsettings.json")
                  .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DevelopConnection"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }

  }
}