using ProcessoSeletivo.Application.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProcessoSeletivo.Presentation.WebForms.Usuario
{
    public partial class Detalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var req = new RestRequest("{id}",Method.GET);
            req.AddParameter("id", Request.QueryString["Id"]);
            var resp = Index.client.Execute<UsuarioViewModel>(req);

            var usuario = resp.Data;

            if (usuario != null)
            {
                LblLogin.Text = usuario.Login;
                LblNome.Text = usuario.Nome;
                LblEmail.Text = usuario.Email;
                LblSenha.Text = usuario.Senha;
                LblDtInclusao.Text = usuario.DtInclusao.ToString("dd/MM/yyyy HH:mm");
                ChkAtivo.Checked = usuario.Ativo;
            }




        }
    }
}