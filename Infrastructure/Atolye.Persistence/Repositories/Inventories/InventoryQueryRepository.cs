using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories.Inventories
{
	public class InventoryQueryRepository : QueryRepository<Inventory> , IQueryRepository<Inventory>
	{
		public InventoryQueryRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
		{
		}
	}
}

