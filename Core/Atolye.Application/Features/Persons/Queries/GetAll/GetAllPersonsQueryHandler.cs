using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Persons.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Application.Features.Persons.Queries.GetAll
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQueryRequest, IDataResult<GetAllPersonsQueryResponse>>
    {
        IQueryRepository<Person> _personQueryRepository;

        public GetAllPersonsQueryHandler(IQueryRepository<Person> personQueryRepository)
        {
            _personQueryRepository = personQueryRepository;
        }

        public async Task<IDataResult<GetAllPersonsQueryResponse>> Handle(GetAllPersonsQueryRequest request, CancellationToken cancellationToken)
        {
            List<Person> persons =await  _personQueryRepository.Table.Include(p=>p.Team).ToListAsync();
            return new SuccessDataResult<GetAllPersonsQueryResponse>("Veriler Listelendi.", new()
            {
                PersonsDTOs = persons.Select(p => p.Adapt<GetAllPersonsDTO>()).ToList(),
                TotalPersonCount = persons.Count()
            }); 
        }
    }
}

