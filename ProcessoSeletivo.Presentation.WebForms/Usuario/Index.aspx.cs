﻿using ProcessoSeletivo.Application.Util;
using ProcessoSeletivo.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace ProcessoSeletivo.Presentation.WebForms.Usuario
{
    public partial class Index : System.Web.UI.Page
    {
        public static readonly RestConsumer<UsuarioViewModel> consumer = new RestConsumer<UsuarioViewModel>();
        private void FillGrid()
        {
            GridView1.DataSource = consumer.GetAll();
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        protected void Excluir(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var row = GridView1.Rows[e.RowIndex];

            consumer.Remove(int.Parse(row.Cells[0].Text));
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