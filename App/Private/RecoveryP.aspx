<%@ Page Title="Reestablecer Contraseña" Language="C#" MasterPageFile="~/Layouts/master/Access.Master" AutoEventWireup="true" CodeBehind="RecoveryP.aspx.cs" Inherits="sjc.App.Private.RecoveryP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container my-2">
        <div class="card m-auto" style="width: 30rem;">
            <div class="card">
                <h5 class="card-header">Recuperacion de contraseña</h5>
                <asp:Label ID="errorTimeRequest" runat="server" Text=""></asp:Label>
                <div id="requestBody" class="card-body" runat="server" visible="false">
                    <h6 class="card-subtitle mb-2 text-muted">Estimado Usuario: Por favor ingrese su nueva contrasena. El sistema le enviará a su correo electrónico una notificacion del cambio su contraseña.</h6>
                    <div class="row gap-2 text-center">
                            <asp:Label ID="recoveryMessageError" CssClass="text-danger" runat="server" Text=""></asp:Label>
                            <asp:Label ID="recoveryMessageSuccess" CssClass=" text-success" runat="server" Text=""></asp:Label>
                        <div class="col-12 gap-2  justify-content-center">
                            <label class="visually-hidden" for="autoSizingInputGroup">Contraseña</label>
                            <div class="input-group mb-2">
                                <div class="input-group-text">Nueva Contraseña</div>
                                <asp:TextBox ID="recoveryNewPass" CssClass="form-control" runat="server" ></asp:TextBox>
                            </div>
                            <div class="input-group mb-2">
                                <div class="input-group-text">Repita La Nueva Contrseña</div>
                                <asp:TextBox ID="recoveryNewPassRep" CssClass="form-control" runat="server" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-12 justify-content-center"> 
                            <asp:Button ID="recoverySubmit" OnClick="recoverySubmit_Click" CssClass="btn btn-primary" runat="server" Text="Enviar Peticion" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
