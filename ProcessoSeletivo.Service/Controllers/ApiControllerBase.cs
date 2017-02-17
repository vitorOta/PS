using ProcessoSeletivo.Application.Interfaces;
using ProcessoSeletivo.Application.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ProcessoSeletivo.Application.WebApi
{
    public class ApiControllerBase<TViewModel> : ApiController where TViewModel: ViewModelBase
    {
        protected readonly IAppServiceBase<TViewModel> appService;

        public ApiControllerBase(IAppServiceBase<TViewModel> appService)
        {
            this.appService = appService;
        }


        public IEnumerable<TViewModel> GetAll()

        {
            var list =  appService.GetAll().ToList();
            return list;
        }

        [HttpGet]
        public TViewModel GetById(int id)
        {
            return appService.GetById(id);
        }

        [HttpPost]
        public void Add(TViewModel entity)
        {
            appService.Add(entity);
        }

        [HttpPut]
        public void Update(TViewModel entity)
        {
            appService.Update(entity);
        }

        //[HttpDelete]
        //public void Remove(TEntity entity)
        //{
        //    appService.Remove(entity);
        //}

        [HttpDelete]
        public void Remove(int id)
        {
            var e = appService.GetById(id);
            if (e == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            appService.Remove(e);
        }


    }
}