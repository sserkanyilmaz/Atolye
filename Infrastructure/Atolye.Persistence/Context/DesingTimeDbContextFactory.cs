using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Atolye.Persistence.Configurations;

namespace Atolye.Persistence.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AtolyeDbContext>
    {
        public DesignTimeDbContextFactory()
        {
        }
        public AtolyeDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AtolyeDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new AtolyeDbContext(dbContextOptionsBuilder.Options);
        }

    }
}

