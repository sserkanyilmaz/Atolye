using System;
using Atolye.Application.Abstraction.DTOs;
using Atolye.Application.Features.Auth.DTOs;
using Atolye.Application.Utilities.Common;
using MediatR;

namespace Atolye.Application.Features.Auth.Commands.Login
{
	public class LoginPersonCommandRequest : IRequest<IDataResult<LoginPersonCommandResponse>>
	{
        public string mail { get; set; }
        public string password { get; set; }
    }
}

