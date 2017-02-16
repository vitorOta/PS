using ProcessoSeletivo.Application.ViewModel.Abstract;
using RestSharp;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace ProcessoSeletivo.Presentation.MVC.Controllers
{
    public class ControllerBase<TViewModel> : Controller
        where TViewModel : IViewModel
    {


        protected readonly string urlBase;
        protected readonly RestClient client;

        public ControllerBase()
        {
            
             urlBase = ConfigurationManager.AppSettings["WebServiceUrl"] + typeof(TViewModel).Name.Replace("ViewModel","");

            client = new RestClient(urlBase);
        }

        public ActionResult Index()
        {
            var req = new RestRequest("GetAll", Method.GET);
            var resp = client.Execute<List<TViewModel>>(req);


            ViewBag.UrlDelete = urlBase;
            return View(resp.Data);
        }


        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPut]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var req = new RestRequest("{id}",Method.DELETE);
            req.AddUrlSegment("id", id + "");
            var resp = client.Execute(req);

            if (resp.ErrorException != null)
            {
                return HttpNotFound(resp.ErrorMessage);
            }

            return View();
        }
    }
}
