using System;
using Atolye.Application.Abstraction.DTOs;
using Atolye.Application.Features.Persons.DTOs;
using Atolye.Application.Utilities.Common;
using MediatR;

namespace Atolye.Application.Features.Persons.Queries.GetAll
{
    public class GetAllPersonsQueryResponse : IRequest<IDataResult<GetAllPersonsDTO>>, IDTO
	{
        public List<GetAllPersonsDTO> PersonsDTOs { get; set; }
        public int TotalPersonCount { get; set; }
    }
}

