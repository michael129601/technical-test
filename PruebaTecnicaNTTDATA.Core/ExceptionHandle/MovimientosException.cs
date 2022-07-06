using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNTTDATA.Core.ExceptionHandle
{
    public class MovimientosException : GenericExceptionBase
    {
        public MovimientosException(int statusHttpCode, string? message) : base(statusHttpCode, message)
        {
        }
    }
}
