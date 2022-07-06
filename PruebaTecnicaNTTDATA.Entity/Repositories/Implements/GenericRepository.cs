using Microsoft.EntityFrameworkCore;
using PruebaTecnicaNTTDATA.Entity.Models;

namespace PruebaTecnicaNTTDATA.Entity.Repositories.Implements
{

    public abstract class GenericRepository<TEntity, TContext> : IGenericRepository <TEntity> where TEntity : class where TContext : DbContext
    {

        protected TContext context;


        protected DbSet<TEntity> dbset;

        public GenericRepository(TContext context)
        {
            this.context = context;
            dbset = context.Set<TEntity>();
        }

        public async Task<int> Delete(int prmId)
        {
            TEntity entity = await  GetById(prmId);
            if (entity == null) return -1;
            //@todo generar exception cuando no exista entidad
            dbset.Remove(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbset.ToListAsync();
        }

        public async Task<TEntity> GetById(int prmId) => await dbset.FindAsync(prmId);

        public async Task<TEntity> Insert(TEntity prmEntity)
        {
            dbset.Add(prmEntity);
            await context.SaveChangesAsync();
            return prmEntity;
        }

        public async Task<TEntity> Update(TEntity prmEntity)
        {
            context.Entry(prmEntity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return prmEntity;
        }
    }
}
