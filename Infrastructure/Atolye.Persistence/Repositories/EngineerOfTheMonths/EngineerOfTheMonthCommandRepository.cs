using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories.EngineerOfTheMonths
{
	public class EngineerOfTheMonthCommandRepository : CommandRepository<EngineerOfTheMonth> , ICommandRepository<EngineerOfTheMonth>
	{
		public EngineerOfTheMonthCommandRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
		{
		}
	}
}

