using System;
using Atolye.Domain.Common;

namespace Atolye.Application.Abstraction.Repository
{
	public interface IQueryRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(string id);
    }
}

