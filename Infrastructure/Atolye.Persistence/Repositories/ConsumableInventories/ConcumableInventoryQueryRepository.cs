using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories.ConsumableInventories
{
	public class ConcumableInventoryQueryRepository : QueryRepository<ConsumableInventory> , IQueryRepository<ConsumableInventory>
	{
		public ConcumableInventoryQueryRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
		{
		}
	}
}

