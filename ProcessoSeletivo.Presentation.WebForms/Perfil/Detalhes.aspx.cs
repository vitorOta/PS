using ProcessoSeletivo.Application.ViewModel;
using System;

namespace ProcessoSeletivo.Presentation.WebForms.Perfil
{
    public partial class Detalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int id = int.Parse (Request.QueryString["Id"]);

            var perfil = Index.consumer.GetById(id);

            if (perfil != null)
            {
                LblNome.Text = perfil.Nome;
                ChkAtivo.Checked = perfil.Ativo;
            }

        }
    }
}