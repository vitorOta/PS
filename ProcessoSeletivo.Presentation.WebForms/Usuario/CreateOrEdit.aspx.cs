using ProcessoSeletivo.Application.Util;
using ProcessoSeletivo.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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


                RestConsumer<PerfilViewModel> perfilConsumer = new RestConsumer<PerfilViewModel>();

                var perfis = new List<PerfilViewModel>();
                var outrosPerfis = perfilConsumer.GetAll();

                if (!string.IsNullOrWhiteSpace(id))
                {


                    int id = int.Parse(Request.QueryString["Id"]);

                    var usuario = Index.consumer.GetById(id);
                    if (usuario != null)
                    {
                        acao = "Editar";

                        nome = usuario.Nome;
                        email = usuario.Email;
                        login = usuario.Login;
                        senha = usuario.Senha;
                        ativo = usuario.Ativo;

                        perfis = usuario.Perfis?.Select(up => up.Perfil).ToList();
                        outrosPerfis = outrosPerfis.Where(p=>!perfis.Contains(p)).ToList();
                    }
                }

                LblAcao.Text = acao;

                TxtLogin.Text = login;
                TxtNome.Text = nome;
                TxtEmail.Text = email;
                TxtSenha.Text = senha;
                ChkAtivo.Checked = ativo;

                ListPerfis.DataSource = perfis;
                ListOutros.DataSource = outrosPerfis;

                ListPerfis.DataBind();
                ListOutros.DataBind();
            }
        }

        protected void Salvar(object sender, EventArgs e)
        {
            var usuario = new UsuarioViewModel();
            bool novo = true;
            if (!string.IsNullOrWhiteSpace(id))
            {

                int id = int.Parse(Request.QueryString["Id"]);
                usuario = Index.consumer.GetById(id);
                novo = usuario == null;
            }
            usuario.Ativo = ChkAtivo.Checked;
            usuario.Login = TxtLogin.Text;
            usuario.Nome = TxtNome.Text;
            usuario.Email = TxtEmail.Text;
            usuario.Senha = TxtSenha.Text;


            
            /*Perfis*/
            List<UsuarioPerfilViewModel> perfisAdicionados= new List<UsuarioPerfilViewModel>();
            for (int i = 0; i < ListPerfis.Items.Count; i++)
            {
                perfisAdicionados.Add(new UsuarioPerfilViewModel
                {
                    Ativo = true,
                    PerfilId = int.Parse(ListPerfis.Items[i].Value),
                    UsuarioId = usuario.Id
                });
            }            
            usuario.Perfis = perfisAdicionados;
            /*---------*/


            if (novo)
            {
                Index.consumer.Add(usuario);
            }
            else
            {
                Index.consumer.Update(usuario);
            }

            Response.Redirect("Index");

        }

        protected void RetirarPerfil(object sender, EventArgs e)
        {
            var indices = ListPerfis.GetSelectedIndices();

            List<ListItem> selecionados = new List<ListItem>();
            foreach(var i in indices)
            {
                var s = ListPerfis.Items[i];
                selecionados.Add(s);
            }

            foreach (var s in selecionados)
            {
                ListPerfis.Items.Remove(s);
                ListOutros.Items.Add(s);
            }


            
        }

        protected void AdicionarPerfil(object sender, EventArgs e)
        {
            var indices = ListOutros.GetSelectedIndices();
            List<ListItem> selecionados = new List<ListItem>();

            foreach (var i in indices)
            {
                var s = ListOutros.Items[i];
                selecionados.Add(s);
            }

            foreach (var s in selecionados)
            {
                ListOutros.Items.Remove(s);
                ListPerfis.Items.Add(s);
            }

            


        }
    }
}