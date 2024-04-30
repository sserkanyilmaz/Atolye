using System;
using Atolye.Application.Abstraction.DTOs;
using Atolye.Application.Utilities.Common;

namespace Atolye.Application.Utilities.Common
{
    public class DataResult<T> : Result, IDataResult<T> where T : class, IDTO, new()
    {
        public DataResult(string message, bool isSucceeded, T data) : base(message, isSucceeded) => this.Data = data;

        public DataResult(bool isSucceeded, T data) : base(isSucceeded) => this.Data = data;

        public T Data { get; }
    }
}

