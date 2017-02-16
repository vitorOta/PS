using AutoMapper;
using ProcessoSeletivo.Application.Interfaces;
using ProcessoSeletivo.Application.ViewModel.Interface;
using ProcessoSeletivo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Application.AppServices
{
    public class AppServiceBase<TViewModel,TEntity> : IAppServiceBase<TViewModel>
        where TViewModel:IViewModel
        where TEntity : class
    {
        protected readonly IServiceBase<TEntity> service;

        public AppServiceBase(IServiceBase<TEntity> service)
        {
            this.service = service;
        }

        public void Add(TViewModel model)
        {
            service.Add(Mapper.Map<TViewModel,TEntity>(model));
        }

        public IEnumerable<TViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<TEntity>, IEnumerable<TViewModel>>(service.GetAll());
        }

        public TViewModel GetById(int id)
        {
            return Mapper.Map<TEntity, TViewModel>(service.GetById(id));
        }

        public void Remove(TViewModel model)
        {
            service.Remove(Mapper.Map<TViewModel, TEntity>(model));
        }

        public void Update(TViewModel model)
        {
            service.Update(Mapper.Map<TViewModel, TEntity>(model));
        }

        public void Dispose()
        {
            service.Dispose();
        }
    }
}
