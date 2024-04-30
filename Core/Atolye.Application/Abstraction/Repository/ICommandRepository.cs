using System;
using Atolye.Domain.Common;

namespace Atolye.Application.Abstraction.Repository
{
    public interface ICommandRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<T> RemoveAsync(string id);
        Task<T> UpdateAsync(T entity);
        Task<int> SaveAsync();
    }

}