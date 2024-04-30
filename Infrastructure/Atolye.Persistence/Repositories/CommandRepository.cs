using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Common;
using Atolye.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Persistence.Repositories
{
    public class CommandRepository<T> : ICommandRepository<T> where T : BaseEntity
    {
        private readonly AtolyeDbContext _context;

        public CommandRepository(AtolyeDbContext context) => _context = context;

        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> AddAsync(T entity)
            => Table.AddAsync(entity).Result.Entity;

        public async Task<T> RemoveAsync(string id)
        {
            T entity = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            entity.IsActive = false;
            await UpdateAsync(entity);
            await SaveAsync();
            return entity;
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public async Task<T> UpdateAsync(T entity)
        {
            T ent = Table.Update(entity).Entity;
            await SaveAsync();
            return ent;

        }
    }
}

