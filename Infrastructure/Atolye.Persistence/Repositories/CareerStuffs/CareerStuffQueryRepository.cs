using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories.CareerStuffs
{
	public class CareerStuffQueryRepository: QueryRepository<CareerStuff> , IQueryRepository<CareerStuff>
	{
		public CareerStuffQueryRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
		{
		}
	}
}

