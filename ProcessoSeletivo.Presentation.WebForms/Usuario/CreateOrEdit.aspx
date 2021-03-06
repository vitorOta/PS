﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateOrEdit.aspx.cs" Inherits="ProcessoSeletivo.Presentation.WebForms.Usuario.CreateOrEdit" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:Label ID="LblAcao" runat="server" Text=""></asp:Label></h2>


    <div class="form-group">
        <label>Login</label>
        <asp:TextBox ID="TxtLogin" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <label>Nome</label>
        <asp:TextBox ID="TxtNome" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <label>Email</label>
        <asp:TextBox ID="TxtEmail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <label>Senha</label>
        <asp:TextBox ID="TxtSenha" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:CheckBox ID="ChkAtivo" runat="server" Text="Ativo" CssClass="checkbox" />
    </div>

    <div class="form-group form-inline">
        <label class="control-label">Perfis</label>
         <asp:ListBox CssClass="form-control" ID="ListPerfis" runat="server" DataTextField="Nome" DataValueField="Id" SelectionMode="Multiple" Width="150px"></asp:ListBox>

            <asp:Button ID="Button2" runat="server" Text="Retirar" CssClass="btn btn-warning" OnClick="RetirarPerfil" />
            <asp:Button ID="Button3" runat="server" Text="Adicionar" CssClass="btn btn-info" OnClick="AdicionarPerfil" />

            <asp:ListBox ID="ListOutros" CssClass="form-control" runat="server" DataTextField="Nome" DataValueField="Id" SelectionMode="Multiple" Width="150px"></asp:ListBox>

        </div>
    </div>

    <a class="btn btn-link" href="Index">Voltar</a>
    <asp:Button ID="Button1" runat="server" Text="Salvar" CssClass="btn btn-success" OnClick="Salvar" />
</asp:Content>

