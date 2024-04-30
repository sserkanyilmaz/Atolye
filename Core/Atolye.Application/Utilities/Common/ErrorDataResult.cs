using System;
using Atolye.Application.Abstraction.DTOs;

namespace Atolye.Application.Utilities.Common
{
    public class ErrorDataResult<T> : DataResult<T> where T : class, IDTO, new()
    {
        public ErrorDataResult(string message, T data) : base(message, false, data) { }
        public ErrorDataResult(T data) : base(false, data) { }
        public ErrorDataResult(string message) : base(message, false, default) { }
        public ErrorDataResult() : base(false, default) { }
    }
}

