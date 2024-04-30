using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories.Inventories
{
	public class InventoryCommandRepository : CommandRepository<Inventory> , ICommandRepository<Inventory>
	{
		public InventoryCommandRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
		{
		}
	}
}

