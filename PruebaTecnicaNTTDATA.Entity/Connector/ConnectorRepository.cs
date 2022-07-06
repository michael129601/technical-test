using PruebaTecnicaNTTDATA.Entity.Repositories.Implements;

namespace PruebaTecnicaNTTDATA.Entity.Connector
{
    public class ConnectorRepository : IDisposable
    {

        private readonly ApplicationDBContext context;


        private ClientesRepository objClientesRepository;


        private CuentasRepository objCuentasRepository;


        private MovimientosRepository objMovimientosRepository;


        public ConnectorRepository(ApplicationDBContext prmContext)
        {
            context = prmContext;
        }


        public ClientesRepository ClientesRepository()
        {
            if (objClientesRepository == null)
                objClientesRepository = new ClientesRepository(context);
            return objClientesRepository;
        }


        public CuentasRepository CuentasRepository()
        {
            if (objCuentasRepository == null)
                objCuentasRepository = new CuentasRepository(context);
            return objCuentasRepository;
        }

        public MovimientosRepository MovimientosRepository()
        {
            if (objMovimientosRepository == null)
                objMovimientosRepository = new MovimientosRepository(context);
            return objMovimientosRepository;
        }


        /// <summary>
        /// Makes this disponsable
        /// </summary>
        public void Dispose()
        {
            context.Dispose();
        }
    }
}