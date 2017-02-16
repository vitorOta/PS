using ProcessoSeletivo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ProcessoSeletivo.Infrastructure.DbContext;
using System.Data.Entity;

namespace ProcessoSeletivo.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ProcessoSeletivoContext Db = new ProcessoSeletivoContext();

        public virtual void Add(TEntity entity)
        {
            Db.Set<TEntity>().Add(entity);
            Db.SaveChanges();
        }


        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);

        }

        public void Remove(TEntity entity)
        {
            Db.Set<TEntity>().Remove(entity);

            Db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}
