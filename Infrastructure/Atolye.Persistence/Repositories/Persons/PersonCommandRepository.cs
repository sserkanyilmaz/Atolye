using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Persistence.Repositories
{
	public class PersonCommandRepository : CommandRepository<Atolye.Domain.Entities.Person>, ICommandRepository<Person>
    {
        public PersonCommandRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
        {
        }
    }
}

