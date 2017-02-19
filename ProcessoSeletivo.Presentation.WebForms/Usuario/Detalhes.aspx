<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Detalhes.aspx.cs" Inherits="ProcessoSeletivo.Presentation.WebForms.Usuario.Detalhes" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <h2>Usuários</h2>
    <dl class="dl-horizontal">
        <dt>
            Login
        </dt>
        
        <dd>
            <asp:Label ID="LblLogin" runat="server"></asp:Label>
        </dd>              
                           
        <dt>               
            Nome           
        </dt>              
                           
        <dd>               
            <asp:Label ID="LblNome" runat="server"></asp:Label>
        </dd>              
                           
        <dt>               
            Email          
        </dt>              
                           
        <dd>               
            <asp:Label ID="LblEmail" runat="server"></asp:Label>
        </dd>              
                           
        <dt>               
            Senha          
        </dt>              
                           
        <dd>               
            <asp:Label ID="LblSenha" runat="server"></asp:Label>
        </dd>

        <dt>
            Ativo
        </dt>

        <dd>
            <asp:CheckBox ID="ChkAtivo" runat="server" Enabled="false"/>
        </dd>

        <dt>
            Data de Inclusão
        </dt>

        <dd>
            <asp:Label ID="LblDtInclusao" runat="server"></asp:Label>
        </dd>


        <dt>Perfis</dt>
        <dd>
            <asp:ListBox ID="ListPerfis" runat="server"></asp:ListBox></dd>

    </dl>

    <a class="btn btn-link" href="Index">Voltar</a>
</asp:Content>



