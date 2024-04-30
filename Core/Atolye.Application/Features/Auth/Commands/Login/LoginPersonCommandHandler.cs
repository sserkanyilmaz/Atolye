using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Application.Features.Auth.Commands.Login
{
	public class LoginPersonCommandHandler : IRequestHandler<LoginPersonCommandRequest, IDataResult<LoginPersonCommandResponse>>
    {
        IQueryRepository<Person> _personQueryRepository;
        public LoginPersonCommandHandler(IQueryRepository<Person> personQueryRepository)
        {
            _personQueryRepository = personQueryRepository;
        }

        public async Task<IDataResult<LoginPersonCommandResponse>> Handle(LoginPersonCommandRequest request, CancellationToken cancellationToken)
        {
            Person? person =await _personQueryRepository.Table.FirstOrDefaultAsync(p => p.Email == request.mail && p.Password == request.password);
            
            if (person == null)
            {
                throw new Exception("Kullanıcı bulunmadı");
            }
            return new DataResult<LoginPersonCommandResponse>(true, person.Adapt<LoginPersonCommandResponse>());
        }

    }
}

