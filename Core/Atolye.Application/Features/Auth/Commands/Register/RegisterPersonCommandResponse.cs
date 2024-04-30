using System;
using Atolye.Application.Abstraction.DTOs;
using Atolye.Application.Features.Auth.DTOs;
using Atolye.Application.Utilities.Common;
using MediatR;

namespace Atolye.Application.Features.Auth.Commands.Register
{
	public class RegisterPersonCommandResponse : IRequest<IDataResult<TokenDTO>>, IDTO
    {

        public TokenDTO TokenDTO { get; set; }
    }
}

