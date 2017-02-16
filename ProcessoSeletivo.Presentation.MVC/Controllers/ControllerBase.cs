using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace ProcessoSeletivo.Presentation.MVC.Controllers
{
    public class ControllerBase<TEntity> : Controller where TEntity : class
    {
        protected string urlBase = ConfigurationManager.AppSettings["WebServiceUrl"] + typeof(TEntity).Name;
        protected readonly RestClient client;

        public ControllerBase()
        {
            client = new RestClient(urlBase);
        }

        public ActionResult Index()
        {
            var req = new RestRequest("GetAll", Method.GET);
            var resp = client.Execute<List<TEntity>>(req);
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

        [HttpPost]
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


        [HttpPost]//[HttpDelete] //config do IIS não reconhece HttpDelete, como não sei como será na hora da avaliação, coloquei como Post
        public ActionResult Delete(int id)
        {
            var req = new RestRequest(Method.DELETE);
            var resp = client.Execute(req);

            if (resp.ErrorException != null)
            {
                return HttpNotFound(resp.ErrorMessage);
            }

            return RedirectToAction("Index");
        }
    }
}
