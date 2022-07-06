using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNTTDATA.Entity.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(int prmId);

        Task<TEntity> Insert(TEntity prmEntity);

        Task<TEntity> Update(TEntity prmEntity);

        Task<int> Delete(int prmId);


    }
}
