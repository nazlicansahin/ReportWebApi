using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ReportWebApi.Persistence.Configurations;

namespace ReportWebApi.Persistence.Contexts
{
   public class ReportWebApiIdentityContextFactory : IDesignTimeDbContextFactory<ReportWebApiIdentityContext>
        {
            public ReportWebApiIdentityContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var optionsBuilder = new DbContextOptionsBuilder<ReportWebApiIdentityContext>();

            // var connectionString = ConfigurationsDb.GetString("ConnectionStrings:PostgreSQL");
            var macConnectionString = "Server=91.151.83.102;Port=5432;Database=Anil_Akpinar_Test1.3;User,Id=ahmetkokteam;Password=obXRMG*U6rJ4R0cbHszpgEuFd";

                optionsBuilder.UseNpgsql(macConnectionString); //mongodb yapilacak

                return new ReportWebApiIdentityContext(optionsBuilder.Options);
            }
        }

}
