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
    public partial class CreateOrEdit : System.Web.UI.Page
    {

        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["Id"];

            if (!IsPostBack)
            {
                var acao = "Novo";


                var nome = string.Empty;
                var login = string.Empty;
                var email = string.Empty;
                var senha = string.Empty;
                var ativo = false;

                if (!string.IsNullOrWhiteSpace(id))
                {
                    //Sono tá muito e o tempo tá pouco, senão criava uma classe/método pra reaproveitar melhor
                    var req = new RestRequest("{id}", Method.GET);
                    req.AddParameter("id", Request.QueryString["Id"]);
                    var resp = Index.client.Execute<UsuarioViewModel>(req);

                    var usuario = resp.Data;
                    if (usuario != null)
                    {
                        acao = "Editar";

                        nome = usuario.Nome;
                        email = usuario.Email;
                        login = usuario.Login;
                        senha = usuario.Senha;
                        ativo = usuario.Ativo;
                    }
                }

                LblAcao.Text = acao;

                TxtLogin.Text = login;
                TxtNome.Text = nome;
                TxtEmail.Text = email;
                TxtSenha.Text = senha;
                ChkAtivo.Checked = ativo;
            }
        }

        protected void Salvar(object sender, EventArgs e)
        {
            var usuario = new UsuarioViewModel();
            bool novo = true;
            if (!string.IsNullOrWhiteSpace(id))
            {
                var sReq = new RestRequest("{id}", Method.GET);
                sReq.AddParameter("id", Request.QueryString["Id"]);
                var sResp = Index.client.Execute<UsuarioViewModel>(sReq);

                usuario = sResp.Data;
            }
            usuario.Ativo = ChkAtivo.Checked;
            usuario.Login = TxtLogin.Text;
            usuario.Nome = TxtNome.Text;
            usuario.Email = TxtEmail.Text;
            usuario.Senha = TxtSenha.Text;

            var req = new RestRequest(novo ? Method.POST : Method.PUT);
            req.AddJsonBody(usuario);
            var resp = Index.client.Execute(req);

            Response.Redirect("Index");

        }
    }
}