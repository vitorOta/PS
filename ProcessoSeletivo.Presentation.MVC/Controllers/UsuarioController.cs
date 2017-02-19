using System.Linq;
using System.Web.Mvc;
using ProcessoSeletivo.Application.ViewModel;
using System;
using System.Collections.Generic;
using ProcessoSeletivo.Application.Util;

namespace ProcessoSeletivo.Presentation.MVC.Controllers
{
    public class UsuarioController : ControllerBase<UsuarioViewModel>
    {
        public override ActionResult CreateOrEdit(int? id)
        {
            UsuarioViewModel obj = null;

            if (id != null && id > 0)
            {
                obj = consumer.GetById(id.Value);
            }
            else
            {
                obj = new UsuarioViewModel();
            }

            RestConsumer<PerfilViewModel> perfilConsumer = new RestConsumer<PerfilViewModel>();
            var perfis = perfilConsumer.GetAll();

            if (obj.Perfis != null)
            {
                perfis = perfis.Where(p => !obj.Perfis.Select(oP => oP.Perfil).Contains(p)).ToList();
            }

            ViewBag.OutrosPerfis = perfis;
            return View(obj);
        }


        [HttpPost]
        public  override ActionResult CreateOrEdit(UsuarioViewModel obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Ocorreu um erro !...");
                }

                List<int> perfisAdicionados = Request.Form.Get("perfisAdicionados")?.Split(',').Select(s => int.Parse(s)).ToList();

                obj.Perfis = new List<UsuarioPerfilViewModel>();

                if (perfisAdicionados != null && perfisAdicionados.Count > 0)
                {
                    perfisAdicionados.ForEach(pa =>
                      {
                          var up = new UsuarioPerfilViewModel();
                          up.PerfilId = pa;
                          up.UsuarioId = obj.Id;
                          up.Ativo = true;
                          obj.Perfis.Add(up);
                      });
                }

                if (obj.Id > 0)
                {
                    consumer.Update(obj);
                }
                else
                {
                    consumer.Add(obj);
                }

                AddAlert("Sucesso !", "success");
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                AddAlert("Ocorreu um erro: " + e.Message, "danger");
                return RedirectToAction("CreateOrEdit", new { obj.Id });
            }
        }

    }
}
