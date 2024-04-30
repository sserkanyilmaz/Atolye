using System;
namespace Atolye.Application.Utilities.Common
{
	public interface IResult
	{
        string Message { get; }
        bool IsSucceeded { get; }
    }
}

