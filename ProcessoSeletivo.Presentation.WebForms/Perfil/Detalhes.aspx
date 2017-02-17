<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Detalhes.aspx.cs" Inherits="ProcessoSeletivo.Presentation.WebForms.Perfil.Detalhes" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <h2>Usuários</h2>
    <dl class="dl-horizontal">               
        <dt>               
            Nome           
        </dt>              
                           
        <dd>               
            <asp:Label ID="LblNome" runat="server"></asp:Label>
        </dd>              

        <dt>
            Ativo
        </dt>

        <dd>
            <asp:CheckBox ID="ChkAtivo" runat="server" Enabled="false"/>
        </dd>

    </dl>

    <a class="btn btn-link" href="Index">Voltar</a>
</asp:Content>



