using System;
using Atolye.Application.Abstraction.DTOs;

namespace Atolye.Application.Utilities.Common
{
	public interface IDataResult<T> : IResult where T : class, IDTO, new()
    {
        T Data { get; }
    }
}

