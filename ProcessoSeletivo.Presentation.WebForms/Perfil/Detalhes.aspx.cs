using ProcessoSeletivo.Application.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProcessoSeletivo.Presentation.WebForms.Perfil
{
    public partial class Detalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var req = new RestRequest("{id}",Method.GET);
            req.AddParameter("id", Request.QueryString["Id"]);
            var resp = Index.client.Execute<PerfilViewModel>(req);

            var perfil = resp.Data;

            if (perfil != null)
            {
                LblNome.Text = perfil.Nome;
                ChkAtivo.Checked = perfil.Ativo;
            }

        }
    }
}