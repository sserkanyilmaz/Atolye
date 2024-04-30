using System;
using Atolye.Application.Utilities.Common;
using MediatR;

namespace Atolye.Application.Features.Persons.Queries.GetAll
{
	public class GetAllPersonsQueryRequest :IRequest<IDataResult<GetAllPersonsQueryResponse>>
	{
    }
}

