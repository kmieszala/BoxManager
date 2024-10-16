using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using BoxManager.Model;
using Microsoft.Extensions.Configuration;

namespace BoxManager.DbMigrator;

public class BoxManagerContextFactory : IDesignTimeDbContextFactory<BoxManagerContext>
{
    public BoxManagerContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        IConfigurationRoot configuration = builder.Build();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var optionsBuilder = new DbContextOptionsBuilder<BoxManagerContext>();

        optionsBuilder.UseSqlServer(connectionString, x => x.MigrationsAssembly(typeof(BoxManagerContextFactory).Assembly.FullName));

        return new BoxManagerContext(optionsBuilder.Options);
    }
}