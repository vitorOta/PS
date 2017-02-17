using ProcessoSeletivo.Application.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ProcessoSeletivo.Presentation.WebForms.Perfil
{
    public partial class Index : System.Web.UI.Page
    {
        public static readonly RestClient client = new RestClient(ConfigurationManager.AppSettings["WebServiceUrl"] + "Perfil");
        private void FillGrid()
        {
            var req = new RestRequest("GetAll", Method.GET);
            var resp = client.Execute<List<UsuarioViewModel>>(req);
            GridView1.DataSource = resp.Data;
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        protected void Excluir(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var row = GridView1.Rows[e.RowIndex];

            var req = new RestRequest("{id}",Method.DELETE);

            req.AddParameter("id", row.Cells[0].Text);
            var resp = client.Execute(req);

            FillGrid();
        }

        protected void Detalhes(object sender, System.Web.UI.WebControls.GridViewSelectEventArgs e)
        {

            Response.Redirect("Detalhes.aspx?Id=" + GridView1.Rows[e.NewSelectedIndex].Cells[0].Text);
        }

        protected void Editar(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            Response.Redirect("CreateOrEdit.aspx?Id=" + GridView1.Rows[e.NewEditIndex].Cells[0].Text);
        }

        protected void Criar(object sender, EventArgs e)
        {
            Response.Redirect("CreateOrEdit.aspx");
        }
    }
}