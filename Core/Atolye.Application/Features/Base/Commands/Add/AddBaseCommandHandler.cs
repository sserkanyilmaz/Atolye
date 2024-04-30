using System;
using Atolye.Application.Features.Base.DTOs;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using MediatR;

namespace Atolye.Application.Features.Base.Commands.Add
{
	public record AddBaseCommandRequest(string BaseName) : IRequest<IDataResult<BaseDTO>>;
    public class AddBaseCommandHandler
	{
		public AddBaseCommandHandler()
		{
		}
	}
}

