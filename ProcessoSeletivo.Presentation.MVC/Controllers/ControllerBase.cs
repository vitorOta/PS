using ProcessoSeletivo.Application.ViewModel;
using ProcessoSeletivo.Application.Util;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace ProcessoSeletivo.Presentation.MVC.Controllers
{
    public class ControllerBase<TViewModel> : Controller
        where TViewModel : ViewModelBase, new()
    {


        
        protected readonly RestConsumer<TViewModel> consumer = new RestConsumer<TViewModel>();

        public ControllerBase()
        {
            
        }

        public ActionResult Index()
        {
            ViewBag.UrlDelete = consumer.baseUrl;
            return View(consumer.GetAll());
        }


        public ActionResult Details(int id)
        {
            return View(consumer.GetById(id));
        }


        public virtual ActionResult CreateOrEdit(int? id)
        {
            TViewModel obj=null;
            try
            {
                //ver id.HasValue
                if (id != null && id > 0)
                {
                    obj = consumer.GetById(id.Value);
                }
                else
                {
                    obj = new TViewModel();
                }
            }catch(Exception e)
            {
                AddAlert("Ocorreu um erro:" + e.Message, "danger");
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpPost]
        public virtual ActionResult CreateOrEdit(TViewModel obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Algo não está certo...");
                }
                
                if (obj.Id > 0)
                {
                    consumer.Update(obj);
                }
                else
                {
                    consumer.Add(obj);
                }

                AddAlert("Sucesso !","success");
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                AddAlert("Ocorreu um erro: " + e.Message,"danger");
                return RedirectToAction("CreateOrEdit",new {obj.Id });
            }
        }

        protected void AddAlert(string message,string type)
        {
            TempData.Add("alert", message);
            TempData.Add("alertType", type);
        }



        /*------ métodos para consumir o webservice ---------*/

    }
}
