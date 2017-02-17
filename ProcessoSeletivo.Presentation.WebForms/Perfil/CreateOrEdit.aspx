﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateOrEdit.aspx.cs" Inherits="ProcessoSeletivo.Presentation.WebForms.Perfil.CreateOrEdit" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:Label ID="LblAcao" runat="server" Text=""></asp:Label></h2>

    <div class="form-group">
        <label>Nome</label>
        <asp:TextBox ID="TxtNome" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:CheckBox ID="ChkAtivo" runat="server" Text="Ativo" CssClass="checkbox" />
    </div>

    <a class="btn btn-link" href="Index">Voltar</a>
    <asp:Button ID="Button1" runat="server" Text="Salvar" CssClass="btn btn-success" OnClick="Salvar" />
</asp:Content>

