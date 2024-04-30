using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories.EngineerOfTheMonths
{
	public class EngineerOfTheMonthQueryRepository : QueryRepository<EngineerOfTheMonth> , IQueryRepository<EngineerOfTheMonth>
	{
		public EngineerOfTheMonthQueryRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
		{
		}
	}
}

