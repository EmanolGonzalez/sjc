<%@ Page Title="Solicitud Completada" Language="C#" MasterPageFile="~/Layouts/master/Access.Master" AutoEventWireup="true" CodeBehind="solicitudComplete.aspx.cs" Inherits="sjc.App.Private.solicitudComplete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container m-auto text-center">
        <h1 class="display-1">Su Solicitud fue Enviada Satifactoriamente</h1>
        <i class="bi bi-card-checklist display-1"></i>
        <div class="container">
            <asp:HyperLink CssClass="btn btn-secondary my-3" runat="server" NavigateUrl="~/App/Private/UserPrincipal.aspx"><i class="bi bi-arrow-bar-left"></i>Regresar a Inicio</asp:HyperLink>
        </div>
    </div>
</asp:Content>
