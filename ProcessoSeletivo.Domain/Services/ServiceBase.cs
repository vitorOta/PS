using ProcessoSeletivo.Domain.Interfaces.Repositories;
using ProcessoSeletivo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity>, IDisposable where TEntity : class
    {
        protected readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Add(TEntity obj)
        {
            repository.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return repository.GetById(id);
        }


        public void Update(TEntity obj)
        {
            repository.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            repository.Remove(obj);
        }


        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
