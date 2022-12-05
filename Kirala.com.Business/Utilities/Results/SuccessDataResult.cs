using Kirala.com.Business.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>, IDataResult<T>
    {
        public SuccessDataResult(T data) : base(data,true)
        {
        }

        public SuccessDataResult(T data, string message) : base(data, message, true)
        {
        }
    }
}
