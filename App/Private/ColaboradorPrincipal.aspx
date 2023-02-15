<%@ Page Title="Colaborador Principal" Language="C#" MasterPageFile="~/Layouts/master/Admin.Master" AutoEventWireup="true" CodeBehind="ColaboradorPrincipal.aspx.cs" Inherits="sjc.App.Private.ColaboradorPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container my-5">

        <div class="row">
            <div class="col">
                <nav aria-label="breadcrumb" class=" bg-white rounded-3 p-3 mb-4 shadow-sm">
                    <ol class="breadcrumb mb-0">
                        <li class="breadcrumb-item active"><a>Sistema de Junta Comunal</a></li>
                        <li class="breadcrumb-item"><a>
                            <asp:Label ID="departameto" runat="server"></asp:Label></a></li>
                    </ol>
                </nav>
            </div>
        </div>


        <div class="row gap-3">
            <div class="col-sm-12 col-lg-4">

                <div class=" bg-white container rounded shadow py-3">
                    <%--titulo--%>
                    <div class="alert-heading text-center">
                        <h1>Visualizador de Trámites</h1>
                    </div>

                    <%--contadores--%>
                    <div class="row gap-2 justify-content-center">

                        <div class=" col-5 col-lg-12">
                            <div class="rounded-0 card border-top-0 border-start-0 border-end-0 border-bottom border-3 border-primary">
                                <div class="card-body">
                                    <div class="d-flex flex-md-column flex-xl-row flex-wrap justify-content-between align-items-md-center justify-content-xl-between">
                                        <div class="float-left text-primary"><i class="bi bi-folder-plus fs-2"></i></div>
                                        <div class="float-right">
                                            <p class="mb-0 text-right">Total de Nuevo Tramites</p>
                                            <div class="fluid-container">
                                                <h3 class="font-weight-medium text-end mb-0">
                                                    <asp:Label ID="totalNuevoTramites" runat="server" Text=""></asp:Label>
                                                </h3>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-5 col-lg-12">
                            <div class="rounded-0 card border-top-0 border-start-0 border-end-0 border-bottom border-3 border-warning">
                                <div class="card-body">
                                    <div class="d-flex flex-md-column flex-xl-row flex-wrap justify-content-between align-items-md-center justify-content-xl-between">
                                        <div class="float-left text-warning"><i class="bi bi-hourglass-split fs-2"></i></div>
                                        <div class="float-right">
                                            <p class="mb-0 text-right">Total Tramites en Proceso</p>
                                            <div class="fluid-container">
                                                <h3 class="font-weight-medium text-end mb-0">
                                                    <asp:Label ID="totalNuevoProceso" runat="server" Text=""></asp:Label>
                                                </h3>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-5 col-lg-12">
                            <div class="rounded-0 card border-top-0 border-start-0 border-end-0 border-bottom border-3 border-success">
                                <div class="card-body">
                                    <div class="d-flex flex-md-column flex-xl-row flex-wrap justify-content-between align-items-md-center justify-content-xl-between">
                                        <div class="float-left text-success"><i class="bi bi-check2-circle  fs-2"></i></div>
                                        <div class="float-right">
                                            <p class="mb-0 text-right">Total Tramistes Finalizados</p>
                                            <div class="fluid-container">
                                                <h3 class="font-weight-medium text-end mb-0">
                                                    <asp:Label ID="totalNuevoFinalizado" runat="server" Text=""></asp:Label>
                                                </h3>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>

            </div>
            <div class="col-sm-12 col-lg-7 rounded shadow bg-white">
                <div class="container my-3">
                    <h3>
                        <small><asp:Label ID="colabCargo" runat="server" Text=""></asp:Label></small>
                    </h3>

                    <div class="row">

                        <div class="col-12 col-sm-12 col-md-6 my-2">
                            <div class="card text-center">
                                <div class="card-header"><span class="badge text-bg-success">Habilitado</span></div>
                                <div class="card-body">
                                    <h5 class="card-title">Gestor de Solicitudes</h5>
                                    <asp:HyperLink ID="goFormSerCom" CssClass=" spinC btn btn-primary" NavigateUrl="~/App/Private/gtrTramites.aspx" runat="server"><i class="bi bi-pin-angle-fill"></i>Ir Gestionar</asp:HyperLink>
                                </div>
                            </div>
                        </div>

                        <div class="col-12 col-sm-12 col-md-6 my-2" id="PanelGestorUsuario" runat="server">
                            <div class="card text-center ">
                                <div class="card-header"><span class="badge text-bg-success">Habilitado</span></div>
                                <div class="card-body">
                                    <h5 class="card-title">Gestor de Colaboradores</h5>
                                    <asp:HyperLink ID="HyperLink1" CssClass=" spinC btn btn-primary" NavigateUrl="~/App/Private/gtrUsuario.aspx" runat="server"><i class="bi bi-pin-angle-fill"></i>Ir Gestionar</asp:HyperLink>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="../../Scripts/_buttoms.js"></script>
</asp:Content>
