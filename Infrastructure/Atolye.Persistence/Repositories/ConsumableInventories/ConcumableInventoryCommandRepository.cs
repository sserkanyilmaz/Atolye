using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories.ConsumableInventories
{
	public class ConcumableInventoryCommandRepository : CommandRepository<ConsumableInventory> , ICommandRepository<ConsumableInventory>
	{
		public ConcumableInventoryCommandRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
		{
		}
	}
}

