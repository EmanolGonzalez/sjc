<%@ Page Title="Recuperar Contraseña" Language="C#" MasterPageFile="~/Layouts/master/Access.Master" AutoEventWireup="true" CodeBehind="Restaurar.aspx.cs" Inherits="sjc.App.Public.Restaurar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <%--boton regresar--%>
        <div class="container my-2">
            <asp:HyperLink CssClass="btn btn-secondary" runat="server" NavigateUrl="~/App/Public/Login.aspx"><i class="bi bi-arrow-bar-left"></i>Regresar</asp:HyperLink>
        </div>

        <%--contenido del card--%>
        <div class="card m-auto" style="width: 25rem;">
            <div class="card">
                <h5 class="card-header">Recuperacion de contraseña</h5>
                <div class="card-body">
                    <h6 class="card-subtitle mb-2 text-muted">Estimado Usuario: Por favor, ingrese su correo electrónico. El sistema le enviará a su correo electrónico un enlace para cambiar su contraseña.</h6>
                    <div class="row gap-2 ">
                        <div class=" text-center">
                            <asp:Label ID="recoveryMessage" CssClass="text-danger" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-12 gap-2  justify-content-center">
                            <label class="visually-hidden" for="autoSizingInputGroup">Correo</label>
                            <div class="input-group mb-2">
                                <div class="input-group-text">Correo</div>
                                <asp:TextBox ID="recoveryEmail" TextMode="Email" CssClass="form-control" runat="server" placeholder="ejemplo@ejemplo.com"></asp:TextBox>
                            </div>
                            <div class="container">
                                <div class="g-recaptcha  d-flex justify-content-center" data-sitekey="6LfaCBoiAAAAAABrqY5kO1kstk86aeLbQMcSfMtA"></div>
                            </div>
                        </div>
                        <div class="col-12 justify-content-center">
                            <div class="d-grid">
                                <asp:LinkButton ID="recoverySubmit"
                                    runat="server"
                                    OnClick="recoverySubmit_Click"
                                    CssClass="spin btn btn-primary shadow"
                                    Text="Enviar Solicitud"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="script">
    <script src="../../Scripts/_buttoms.js"></script>
</asp:Content>
