using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Common;
using Atolye.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Persistence.Repositories
{
	public class QueryRepository<T> : IQueryRepository<T> where T : BaseEntity
    {
        private readonly AtolyeDbContext _context;
        public QueryRepository(AtolyeDbContext atolyeDbContext) => _context = atolyeDbContext;

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll() => Table.Where(t=>t.IsActive == true).AsQueryable();

        public async Task<T> GetByIdAsync(string id) => await Table.AsQueryable().FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
    }
}

