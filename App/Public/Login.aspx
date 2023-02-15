<%@ Page Title="Acceso al Sistema" Language="C#" MasterPageFile="~/Layouts/master/Access.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="sjc.App.Public.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row flex-wrap-reverse justify-content-sm-center my-2">
        <%--formulario--%>
        <div class="col-lg-4 col-sm-8 m-auto p-3">
            <%-- acceso al sistema--%>
            <div class="row gap-2 mb-3">
                <%-- label de mensaje --%>

                <div class=" container text-center py-1">
                    <asp:Label ID="loginMessage" CssClass=" text-danger fw-semibold" runat="server" Text=""></asp:Label>
                    <asp:Label ID="loginMessage2" CssClass="text-success fw-semibold" runat="server" Text=""></asp:Label>
                </div>

                <div class="text-center">
                    <h1>Acceso</h1>
                </div>

                <%-- input cedula o pasaporte --%>
                <div class="form-floating ">
                    <asp:TextBox ID="loginUser" CssClass="form-control shadow-sm " placeholder=" " runat="server"></asp:TextBox>
                    <label class=" text-secondary" for="loginUser "><i class="bi bi-person-badge ms-3"></i>Correo Electrónico, Cédula o Pasaporte</label>
                </div>
                <%-- Input contrasena --%>
                <div class="form-floating">
                    <asp:TextBox ID="loginPassword" CssClass="form-control shadow-sm" TextMode="Password" placeholder=" " runat="server"></asp:TextBox>
                    <label class=" text-secondary" for="loginPassword"><i class=" bi bi-key ms-3"></i>Contraseña</label>
                </div>
                <%-- Captcha --%>
                <div class="text-center fw-bolder">
                    <label>Para ingresar al sistema debe realizar el captcha</label>
                    <div class="g-recaptcha d-flex justify-content-center" data-sitekey="6LfaCBoiAAAAAABrqY5kO1kstk86aeLbQMcSfMtA"></div>
                </div>
                <%-- boton login --%>
                <div class="d-grid">
                    <asp:LinkButton ID="btnLogin" OnClick="btnLogin_Click" CssClass="spin btn btn-primary shadow" runat="server" Text="Ingresar"></asp:LinkButton>
                </div>
            </div>
            <%-- botones de restaurar y crear cuenta --%>
            <div class="d-grid gap-1">
                <asp:HyperLink ID="btnRestaurar" CssClass="btn btn-outline-primary  w-100" runat="server" NavigateUrl="~/App/Public/Restaurar.aspx">Restaurar Contraseña</asp:HyperLink>
                <asp:HyperLink ID="btnRegister" CssClass="btn btn-outline-primary  w-100" runat="server" NavigateUrl="~/App/Public/Register.aspx">¿No Tienes Cuenta? ¡Regístrate Aquí!</asp:HyperLink>
            </div>
        </div>
        <%-- imagen banner --%>
        <div class="col-lg-8 col-sm-6 rounded">
            <div id="myCarousel" class="carousel slide shadow rounded" data-bs-ride="carousel">
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img src="../../Content/img/LRSBanner.jpeg" class="d-block rounded  w-100" alt="...">
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="script">
    <script src="../../Scripts/_buttoms.js"></script>
</asp:Content>
