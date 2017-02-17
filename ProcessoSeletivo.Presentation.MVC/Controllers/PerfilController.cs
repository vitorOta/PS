using System.Web.Mvc;
using ProcessoSeletivo.Application.ViewModel;

namespace ProcessoSeletivo.Presentation.MVC.Controllers
{
    public class PerfilController : ControllerBase<PerfilViewModel>
    {
        public override ActionResult Details(int id)
        {
            return base.Details(id);
        }
    }
}