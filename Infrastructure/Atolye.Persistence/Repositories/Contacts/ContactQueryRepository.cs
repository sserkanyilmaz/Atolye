using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories.Contacts
{
	public class ContactQueryRepository : QueryRepository<Contact> , IQueryRepository<Contact>
	{
		public ContactQueryRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
		{
		}
	}
}

