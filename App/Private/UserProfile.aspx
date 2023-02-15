<%@ Page Title="Perfil de Usuario" Language="C#" MasterPageFile="~/Layouts/master/User.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="sjc.App.Private.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <section style="background-color: #eee;">
        <div class="container py-5">
            <div class="row">
                <div class="col">
                    <nav aria-label="breadcrumb" class=" bg-white rounded-3 p-3 mb-4 shadow-sm">
                        <ol class="breadcrumb mb-0">
                            <li class="breadcrumb-item"><a>Inicio</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Perfil de Usuario</li>
                        </ol>
                    </nav>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-4">
                    <div class="card mb-4 border-0 shadow">
                        <div class="card-body text-center">
                            <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-chat/ava6.webp" alt="avatar"
                                class="rounded-circle img-fluid" style="width: 150px;">
                            <h5 class="my-3">
                                <asp:Label ID="profileName1" runat="server" Text="{Nombre}"></asp:Label>
                            </h5>
                        </div>
                    </div>
                </div>
                <div class="col-lg-8">
                    <div class="card mb-4 border-0 shadow">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-3">
                                    <p class="mb-0">Nombre Completo</p>
                                </div>
                                <div class="col-sm-9">
                                    <p class="text-muted mb-0">
                                        <asp:Label ID="ProfileName2" runat="server" Text=""></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <p class="mb-0">
                                        <asp:Label ID="profileTypeDoc" runat="server" Text="{identificacion}"></asp:Label>
                                    </p>
                                </div>
                                <div class="col-sm-9">
                                    <p class="text-muted mb-0">
                                        <asp:Label ID="profileIndentNumber" runat="server" Text="{numero de indetificacion}"></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <p class="mb-0">Correo</p>
                                </div>
                                <div class="col-sm-9">
                                    <p class="text-muted mb-0">
                                        <asp:Label ID="profileEmail" runat="server" Text="{Correo}"></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <p class="mb-0">Fecha de Nacimiento</p>
                                </div>
                                <div class="col-sm-9">
                                    <p class="text-muted mb-0">
                                        <asp:Label ID="profileBirth" runat="server" Text="{nacimeinto}"></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <p class="mb-0">Teléfono</p>
                                </div>
                                <div class="col-sm-9">
                                    <p class="text-muted mb-0">
                                        <asp:Label ID="profileCel" runat="server" Text="{numero}"></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <p class="mb-0">Dirección</p>
                                </div>
                                <div class="col-sm-9">
                                    <p class="text-muted mb-0">
                                        <asp:Label ID="profileDirect" runat="server" Text="{Dirección}"></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <hr>
                            <div class="row justify-content-end">
                                <div class="col-sm-4">
                                    <asp:Button ID="profileChangeData" Visible="false" CssClass="btn btn-primary form-control " runat="server" Text="Guardar Cambio" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%-- actualizar contrasena desde perfil--%>
            <div class="row" runat="server" visible="false">
                <div class="col-lg-4"></div>
                <div class="col-lg-8">
                    <div class="card mb-4">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-3">
                                    <p class="mb-0">Contrasena Actual</p>
                                </div>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="TextBox1" CssClass=" form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <p class="mb-0">
                                        Nueva Contrasena
                                    </p>
                                </div>
                                <div class="col-sm-9">
                                    <p class="text-muted mb-0">
                                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                                    </p>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <p class="mb-0">Repetir Nueva Contrasena</p>
                                </div>
                                <div class="col-sm-9">
                                    <p class="text-muted mb-0">
                                        <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
                                    </p>
                                </div>
                            </div>
                            <hr>
                            <div class="row justify-content-end">
                                <div class="col-sm-4">                                    
                                     <asp:Button ID="profileChangePass" CssClass="btn btn-primary form-control" runat="server" Text="Guardar Cambio" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
