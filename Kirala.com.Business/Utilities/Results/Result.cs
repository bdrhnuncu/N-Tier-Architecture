using Kirala.com.Business.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Utilities.Results
{
    public class Result : IResult
    {
        public string Message { get; }

        public bool IsSuccess { get; }
        public Result(string message, bool isSuccess) : this(isSuccess)
        {
            Message = message;
        }
        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}
