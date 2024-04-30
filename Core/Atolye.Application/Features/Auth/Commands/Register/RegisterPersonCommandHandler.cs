using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Auth.Commands.Login;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;

namespace Atolye.Application.Features.Auth.Commands.Register
{
	public class RegisterPersonCommandHandler : IRequestHandler<RegisterPersonCommandRequest, IDataResult<RegisterPersonCommandResponse>>
    {
        ICommandRepository<Person> _personCommmandRepository;

        public RegisterPersonCommandHandler(ICommandRepository<Person> personCommmandRepository)
        {
            _personCommmandRepository = personCommmandRepository;
        }

        public async Task<IDataResult<RegisterPersonCommandResponse>> Handle(RegisterPersonCommandRequest request, CancellationToken cancellationToken)
        {
            Person person = request.Adapt<Person>();
            await _personCommmandRepository.AddAsync(person);
            await _personCommmandRepository.SaveAsync();
            return new DataResult<RegisterPersonCommandResponse>(true, person.Adapt<RegisterPersonCommandResponse>());
        }
    }
}

