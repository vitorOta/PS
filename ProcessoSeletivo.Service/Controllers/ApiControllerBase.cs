using ProcessoSeletivo.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ProcessoSeletivo.Service.Controllers
{
    public class ApiControllerBase<TEntity> : ApiController where TEntity:class
    {
        protected readonly IAppServiceBase<TEntity> appService;

        public ApiControllerBase(IAppServiceBase<TEntity> appService)
        {
            this.appService = appService;
        }


        public IEnumerable<TEntity> GetAll()
        {
            return appService.GetAll();
        }

        [HttpGet]
        public TEntity GetById(int id)
        {
            return appService.GetById(id);
        }

        [HttpPost]
        public void Add(TEntity entity)
        {
            appService.Add(entity);
        }

        [HttpPut]
        public void Update(TEntity entity)
        {
            appService.Update(entity);
        }

        [HttpDelete]
        public void Remove(TEntity entity)
        {
            appService.Remove(entity);
        }


    }
}