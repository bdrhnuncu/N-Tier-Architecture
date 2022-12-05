using Kirala.com.Business.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Utilities.Results
{
    public class DataResult<T> : IDataResult<T>
    {
        public T Data { get; }

        public string Message { get; }

        public bool IsSuccess { get; }

        public DataResult(T data, string message, bool isSuccess) : this(data,isSuccess)
        {
            Message = message;
        }
        public DataResult(T data,bool isSuccess)
        {
            Data = data;
            IsSuccess = isSuccess;
        }

    }
}
