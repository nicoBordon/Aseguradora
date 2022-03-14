using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Aseguradora.BL.Data;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Aseguradora.BL.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AseguradoraContext aseguradoraContext;

        public GenericRepository(AseguradoraContext aseguradoraContext)
        {
            this.aseguradoraContext = aseguradoraContext;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("La entidad es null");

            aseguradoraContext.Set<TEntity>().Remove(entity);
            await aseguradoraContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await aseguradoraContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
           
            return await aseguradoraContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            aseguradoraContext.Set<TEntity>().Add(entity);
            await aseguradoraContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
           // aseguradoraContext.Entry(entity).State = EntityState.Modified;
            aseguradoraContext.Set<TEntity>().AddOrUpdate(entity);
            await aseguradoraContext.SaveChangesAsync();
            return entity;
        }
        
    }
}
