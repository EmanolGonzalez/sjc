<%@ Page Title="Registro Completado" Language="C#" MasterPageFile="~/Layouts/master/Access.Master" AutoEventWireup="true" CodeBehind="registerComplet.aspx.cs" Inherits="sjc.App.Private.registerComplet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container m-auto text-center">
        <h1 class="display-1">Su Registro fue Satisfactorio</h1>
        <i class="bi bi-card-checklist display-1"></i>
        <div class="container">
        <asp:HyperLink CssClass="btn btn-secondary my-3" runat="server" NavigateUrl="~/App/Public/Login.aspx"><i class="bi bi-arrow-bar-left"></i>Regresar a Incio</asp:HyperLink>
        </div>
    </div>
</asp:Content>
