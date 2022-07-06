using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNTTDATA.Core.ExceptionHandle
{
    public abstract class GenericExceptionBase : Exception
    {
        public int StatusHttpCode { get; set; }

        public string? Message { get; set; }

        public GenericExceptionBase(int statusHttpCode, string? message)
        {
            StatusHttpCode = statusHttpCode;
            Message = message;
        }
    }
}
