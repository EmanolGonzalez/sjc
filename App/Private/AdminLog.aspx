<%@ Page Title="Acceso Administrativo" Language="C#" MasterPageFile="~/Layouts/master/Access.Master" AutoEventWireup="true" CodeBehind="AdminLog.aspx.cs" Inherits="sjc.App.Private.AdminLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="col-lg-4 col-sm-12 m-auto p-3 bg-white shadow-sm">

            <div class="row">
                <spam class=" fw-bolder display-3  text-center">Sistema de</spam>
                <spam class=" fw-bolder display-3  text-center">Junta Comunal</spam>
            </div>

            <%-- acceso al sistema--%>
            <div class="row gap-2 mb-3">
                <%-- label de mensaje --%>

                <div class=" container text-center py-1">
                    <asp:Label ID="loginMessage" CssClass=" text-danger fw-semibold" runat="server" Text=""></asp:Label>
                    <asp:Label ID="loginMessage2" CssClass="text-success fw-semibold" runat="server" Text=""></asp:Label>
                </div>

                <%-- input correo institucional --%>
                <div class="form-floating ">
                    <asp:TextBox ID="loginUser" CssClass="form-control" placeholder=" " runat="server"></asp:TextBox>
                    <label class=" text-secondary" for="loginUser"><i class="bi bi-person-badge ms-3"></i>Correo Institucional</label>
                </div>
                <%-- Input contrasena --%>
                <div class="form-floating">
                    <asp:TextBox ID="loginPassword" CssClass="form-control" TextMode="Password" placeholder=" " runat="server"></asp:TextBox>
                    <label class=" text-secondary" for="loginPassword"><i class=" bi bi-key ms-3"></i>Contraseña</label>
                </div>
                <%-- Captcha --%>
                <div class="form text-center">
                    <label class="fw-bold">Para ingresar al sistema debe realizar el captcha</label>
                    <div class="g-recaptcha d-flex justify-content-center" data-sitekey="6LfaCBoiAAAAAABrqY5kO1kstk86aeLbQMcSfMtA"></div>
                </div>
                <%-- boton login --%>
                <div class="d-grid">
                    <asp:LinkButton ID="BtnLogin" runat="server" CssClass="spin btn btn-primary" OnClick="BtnLogin_Click" Text="Ingresar"></asp:LinkButton>
                </div>
            </div>

        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="../../Scripts/_buttoms.js"></script>
</asp:Content>
