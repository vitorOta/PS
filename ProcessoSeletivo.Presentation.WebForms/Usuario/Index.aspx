<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" MasterPageFile="~/Site.Master" Inherits="ProcessoSeletivo.Presentation.WebForms.Usuario.Index" %>


<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <h2>Usuários</h2>

    <asp:Button ID="Button1" runat="server" Text="Novo" CssClass="btn btn-success" OnClick="Criar"/>
    <br />
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" OnRowDeleting="Excluir" OnRowEditing="Editar" OnSelectedIndexChanging="Detalhes">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Login" HeaderText="Login" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:CheckBoxField DataField="Ativo" HeaderText="Ativo" />
            <asp:BoundField DataField="DtInclusao" HeaderText="Data Inclusão" />
            <asp:CommandField ButtonType="Button" EditText="Editar" ShowEditButton="True" ControlStyle-CssClass="btn btn-default" >
<ControlStyle CssClass="btn btn-default"></ControlStyle>
            </asp:CommandField>
            <asp:CommandField ButtonType="Button" SelectText="Detalhes" ShowSelectButton="True" ControlStyle-CssClass="btn btn-info">
<ControlStyle CssClass="btn btn-info"></ControlStyle>
            </asp:CommandField>
            <asp:CommandField ButtonType="Button" DeleteText="Excluir" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger">
<ControlStyle CssClass="btn btn-danger"></ControlStyle>
            </asp:CommandField>
        </Columns>
    </asp:GridView>
</asp:Content>