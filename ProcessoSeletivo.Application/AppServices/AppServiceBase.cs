using ProcessoSeletivo.Application.Interfaces;
using ProcessoSeletivo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Application.AppServices
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
    {
        protected readonly IServiceBase<TEntity> service;

        public AppServiceBase(IServiceBase<TEntity> service)
        {
            this.service = service;
        }

        public void Add(TEntity entity)
        {
            service.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return service.GetAll();
        }

        public TEntity GetById(int id)
        {
            return service.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            service.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            service.Update(entity);
        }

        public void Dispose()
        {
            service.Dispose();
        }
    }
}
