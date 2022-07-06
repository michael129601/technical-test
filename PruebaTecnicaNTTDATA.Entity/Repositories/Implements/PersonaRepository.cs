using PruebaTecnicaNTTDATA.Entity.Connector;
using PruebaTecnicaNTTDATA.Entity.Models;


namespace PruebaTecnicaNTTDATA.Entity.Repositories.Implements
{
    public  class PersonaRepository : GenericRepository<Persona, ApplicationDBContext>
    {
        public PersonaRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
