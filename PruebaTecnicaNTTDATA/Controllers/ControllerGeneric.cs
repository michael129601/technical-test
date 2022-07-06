using PruebaTecnicaNTTDATA.Entity.Connector;

namespace PruebaTecnicaNTTDATA.Controllers
{
    abstract public class ControllerGeneric : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        
        protected  ApplicationDBContext _context;

        
        public ControllerGeneric(ApplicationDBContext prmContext)
        {
            _context = prmContext;
        }

        protected object GetMessage(string message = "")
        {
            return new
            {
                message = message,
            };
        }
    }
}
