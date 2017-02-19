using ProcessoSeletivo.Application.ViewModel;
using System;

namespace ProcessoSeletivo.Presentation.WebForms.Perfil
{
    public partial class CreateOrEdit : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var acao = "Novo";

                int id = 0;
                int.TryParse(Request.QueryString["Id"],out id);

                var nome = string.Empty;
                var ativo = false;

                if (id>0)
                {
                    var perfil = Index.consumer.GetById(id);
                    if (perfil != null)
                    {
                        acao = "Editar";

                        nome = perfil.Nome;
                        ativo = perfil.Ativo;
                    }
                }

                LblAcao.Text = acao;

                TxtNome.Text = nome;
                ChkAtivo.Checked = ativo;
            }
        }

        protected void Salvar(object sender, EventArgs e)
        {
            var perfil = new PerfilViewModel();
            bool novo = true;

            int id = 0;
            int.TryParse(Request.QueryString["Id"], out id);

            if (id>0)
            {
                perfil = Index.consumer.GetById(id);
                novo = perfil == null;
            }
            perfil.Ativo = ChkAtivo.Checked;
            perfil.Nome = TxtNome.Text;


            if (novo)
            {
                Index.consumer.Add(perfil);
            }else
            {
                Index.consumer.Update(perfil);
            }

            Response.Redirect("Index");

        }
    }
}