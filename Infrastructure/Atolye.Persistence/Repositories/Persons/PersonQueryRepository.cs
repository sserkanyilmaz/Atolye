using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories
{
	public class PersonQueryRepository : QueryRepository<Person>, IQueryRepository<Person>
    {
        public PersonQueryRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
        {
        }
    }
}

