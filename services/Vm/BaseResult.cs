using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace services.Vm
{
    public class BaseResult
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
     public class BaseResult<TData>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public TData Data { get; set; }
    }
}