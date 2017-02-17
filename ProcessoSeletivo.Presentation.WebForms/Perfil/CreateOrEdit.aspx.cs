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
                var ativo = false;

                if (!string.IsNullOrWhiteSpace(id))
                {
                    //Sono tá muito e o tempo tá pouco, senão criava uma classe/método pra reaproveitar melhor
                    var req = new RestRequest("{id}", Method.GET);
                    req.AddParameter("id", Request.QueryString["Id"]);
                    var resp = Index.client.Execute<PerfilViewModel>(req);

                    var perfil = resp.Data;
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
            if (!string.IsNullOrWhiteSpace(id))
            {
                var sReq = new RestRequest("{id}", Method.GET);
                sReq.AddParameter("id", Request.QueryString["Id"]);
                var sResp = Index.client.Execute<PerfilViewModel>(sReq);

                perfil = sResp.Data;
                novo = perfil == null;
            }
            perfil.Ativo = ChkAtivo.Checked;
            perfil.Nome = TxtNome.Text;

            var req = new RestRequest(novo ? Method.POST : Method.PUT);
            req.AddJsonBody(perfil);
            var resp = Index.client.Execute(req);

            Response.Redirect("Index");

        }
    }
}