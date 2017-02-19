using ProcessoSeletivo.Application.Util;
using ProcessoSeletivo.Application.ViewModel;
using System;
using System.Linq;

namespace ProcessoSeletivo.Presentation.WebForms.Usuario
{
    public partial class Detalhes : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            int id = int.Parse(Request.QueryString["Id"]);
            var usuario = Index.consumer.GetById(id);

            if (usuario != null)
            {
                LblLogin.Text = usuario.Login;
                LblNome.Text = usuario.Nome;
                LblEmail.Text = usuario.Email;
                LblSenha.Text = usuario.Senha;
                LblDtInclusao.Text = usuario.DtInclusao.ToString("dd/MM/yyyy HH:mm");
                ChkAtivo.Checked = usuario.Ativo;

                ListPerfis.DataSource = usuario.Perfis?.Select(up=>up.Perfil.Nome);
                ListPerfis.DataBind();
            }




        }
    }
}