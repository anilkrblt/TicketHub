using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TicketService.Repository;


namespace TicketService.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

            var builder = new DbContextOptionsBuilder<RepositoryContext>()

           .UseSqlite(configuration.GetConnectionString("sqliteConnection"), b => b.MigrationsAssembly("TicketService"));
            return new RepositoryContext(builder.Options);
        }
    }
}