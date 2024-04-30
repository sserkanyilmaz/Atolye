using System;
using Atolye.Domain.Common;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Application.Abstraction.Repository
{
	public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}

