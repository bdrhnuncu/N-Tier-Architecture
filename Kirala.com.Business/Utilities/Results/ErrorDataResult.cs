using Kirala.com.Business.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>, IDataResult<T>
    {
        public ErrorDataResult(T data) : base(data, false)
        {
        }

        public ErrorDataResult(T data, string message) : base(data, message, false)
        {
        }
    }
}
