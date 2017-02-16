using ProcessoSeletivo.Application.Interfaces;
using ProcessoSeletivo.Application.ViewModel.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ProcessoSeletivo.Application.WebApi
{
    public class ApiControllerBase<TViewModel> : ApiController where TViewModel: IViewModel
    {
        protected readonly IAppServiceBase<TViewModel> appService;

        public ApiControllerBase(IAppServiceBase<TViewModel> appService)
        {
            this.appService = appService;
        }


        public IEnumerable<TViewModel> GetAll()

        {
            var list =  appService.GetAll().ToList<TViewModel>();
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