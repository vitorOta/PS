using ProcessoSeletivo.Application.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace ProcessoSeletivo.Presentation.MVC.Controllers
{
    public class ControllerBase<TViewModel> : Controller
        where TViewModel : ViewModelBase, new()
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
            var req = new RestRequest("{id}", Method.GET);
            req.AddParameter("id", id);
            var resp = client.Execute<TViewModel>(req);
            return View(resp.Data);
        }


        public ActionResult CreateOrEdit(int? id)
        {
            TViewModel obj=null;

            if (id != null && id > 0)
            {
                var req = new RestRequest("{id}", Method.GET);
                req.AddParameter("id", id);
                var resp = client.Execute<TViewModel>(req);
                if (resp.ErrorException != null)
                {
                    AddAlert("Ocorreu um erro:" + resp.ErrorException.Message,"danger");
                    return RedirectToAction("Index");
                }

                obj = resp.Data;
            }else
            {
                obj = new TViewModel();
            }
            

            return View(obj);
        }


        [HttpPost]
        public ActionResult CreateOrEdit(TViewModel obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Algo deu errado...");
                }
                Method m;
                if (obj.Id > 0)
                {
                    m = Method.PUT;
                }
                else
                {
                    m=Method.POST;
                }

                var req = new RestRequest(m);
                req.AddJsonBody(obj);
                var resp = client.Execute(req);

                if (resp.ErrorException != null)
                {
                    throw resp.ErrorException;
                }

                AddAlert("Sucesso !","success");
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                AddAlert("Ocorreu um erro: " + e.Message,"danger");
                return View(obj);
            }
        }

        private void AddAlert(string message,string type)
        {
            TempData.Add("alert", message);
            TempData.Add("alertType", type);
        }

    }
}
