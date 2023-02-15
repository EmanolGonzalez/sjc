<%@ Page Title="Pagina Inicio Ciudadano" Language="C#" MasterPageFile="~/Layouts/master/User.Master" AutoEventWireup="true" CodeBehind="UserPrincipal.aspx.cs" Inherits="sjc.App.Private.UserPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class=" container py-5">

        <%-- alerta --%>
        <div class="bg-white shadow-sm rounded border-bottom-0 border-top-0 border-start-0 border-end border-3 border-success p-3 mb-4" style="color: #1F232C" role="alert">
            <h4 class="alert-heading fw-bold fs-4">¡Bienvenido al Sistema de Junta Comunal!</h4>
            <hr>
            <p class="mb-0">
                A continuación puedes ver el manual de usuario para petición de solicitudes. 
                <asp:HyperLink ID="HyperLink1" NavigateUrl="#" runat="server">Manual de Usuario</asp:HyperLink>
            </p>
        </div>

        <div class="row mb-3">
            <div class="col">
                <nav aria-label="breadcrumb" class=" bg-white rounded-3 p-3 shadow-sm">
                    <ol class="breadcrumb mb-0">
                        <li class="breadcrumb-item active"><a>Inicio</a></li>
                    </ol>
                </nav>
            </div>
        </div>


        <section class="container">

            <ul class="nav nav-pills" id="myTab" role="tablist">
                <li class="nav-item" role="presentation">
                    <button class="nav-link active" id="ContentPanel1-tab" data-bs-toggle="tab" data-bs-target="#ContentPanel1" type="button" role="tab" aria-controls="panel1" aria-selected="true">Panel 1</button>
                </li>
                <li class="nav-item" role="presentation">
                    <button class="nav-link" id="ContentPanel2-tab" data-bs-toggle="tab" data-bs-target="#ContentPanel2" type="button" role="tab" aria-controls="panel2" aria-selected="false">Panel 2</button>
                </li>
                <li class="nav-item" role="presentation">
                    <button class="nav-link" id="ContentPanel3-tab" data-bs-toggle="tab" data-bs-target="#ContentPanel3" type="button" role="tab" aria-controls="panel3" aria-selected="false">Panel 3</button>
                </li>
            </ul>

            <div class="tab-content" id="myTabContent">

                <div class="tab-pane fade show active" id="ContentPanel1" role="tabpanel" aria-labelledby="panel1-tab">

                    <div class="accordion py-3 border-0" id="AcordeonServicios">
                        <div class="accordion-item shadow">
                            <h2 class="accordion-header" id="headingOne">
                                <button class="accordion-button fw-bold fs-4" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                    <i class="bi bi-award-fill" style="color: #d3af37"></i>Servicios Habilitados
                                </button>
                            </h2>
                            <div id="collapseOne" class=" accordion-collapse collapse show" aria-labelledby="headingOne" data-bs-parent="#AcordeonServicios">
                                <div class="accordion-body ">
                                    <div class="row g-1">
                                        <div class="col-lg-3  col-sm-8 ">
                                            <div class="card text-center border-success border-2">
                                                <div class="card-header bg-white"><span class="badge text-bg-success">Habilitado</span></div>
                                                <div class="card-body">
                                                    <h5 class="card-title">Servicio Comunitario</h5>
                                                    <asp:HyperLink ID="goFormSerCom" CssClass="spinC btn btn-primary" NavigateUrl="~/App/Private/FormularioSerCom.aspx" runat="server"><i class="bi bi-clipboard-plus"></i>Solicitar</asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-lg-3  col-sm-8 d-none">
                                            <div class="card text-center border-0">
                                                <div class="card-header bg-white"><span class="badge text-bg-warning">Proximamente</span></div>
                                                <div class="card-body">
                                                    <h5 class="card-title">Apoyo Social</h5>
                                                    <button type="button" class="btn btn-primary" disabled><i class="bi bi-clipboard-plus"></i>Solicitar</button>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-lg-3  col-sm-8 d-none">
                                            <div class="card text-center border-0">
                                                <div class="card-header bg-white"><span class="badge text-bg-warning">Proximamente</span></div>
                                                <div class="card-body">
                                                    <h5 class="card-title">Apoyo deEvento</h5>
                                                    <button type="button" class="btn btn-primary" disabled><i class="bi bi-clipboard-plus"></i>Solicitar</button>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-sm-8 d-none">
                                            <div class="card text-center border-0">
                                                <div class="card-header bg-white"><span class="badge text-bg-warning">Proximamente</span></div>
                                                <div class="card-body">
                                                    <h5 class="card-title">Asistencia Legal</h5>
                                                    <button type="button" class="btn btn-primary" disabled><i class="bi bi-clipboard-plus"></i>Solicitar</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="tab-pane fade " id="ContentPanel2" role="tabpanel" aria-labelledby="panel2-tab">
                    <div class="col-12 py-3">
                        <div class="shadow bg-white rounded mb-3 overflow-hidden px-3 py-3 d-flex justify-content-between align-items-center">
                            <h5 class="mb-0 fw-bold fs-4">
                                <i class="bi bi-clipboard-check-fill" style="color: #4db6ac"></i>
                                Tus Tramites Realizados
                            </h5>
                        </div>
                        <div class="row mb-5">
                            <div class="col-12">
                                <asp:Label ID="MisSolicitudesMessages" runat="server" CssClass="display-4 text-center fw-bold text-dark"></asp:Label>
                                <asp:GridView ID="MisSolicitudes" runat="server" OnLoad="MisSolicitudes_Load" UseAccessibleHeader="true" AutoGenerateColumns="false" CssClass="table table-hover" Style="width: 100%" BorderStyle="None">
                                    <Columns>
                                        <asp:BoundField HeaderText="Tramite #" DataField="Numero de Tramite" ItemStyle-CssClass="p-5"/>
                                        <asp:BoundField HeaderText="Estado" DataField="Estado" />
                                        <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                                        <asp:BoundField HeaderText="Fecha De Solicitud" DataField="Fecha De Solicitud" />
                                        <asp:TemplateField HeaderText="Acciones">
                                            <ItemTemplate>
                                                <div class="d-grid">
                                                    <asp:LinkButton ID="Cancelar" Text="Cancelar" runat="server" CssClass="spin mt-1 btn btn-warning" OnClick="cancelar_boton_Click"></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="tab-pane fade" id="ContentPanel3" role="tabpanel" aria-labelledby="panel3-tab">
                    <div class="col-12 py-3">
                        <div class="shadow bg-white rounded mb-3 overflow-hidden px-3 py-3 d-flex justify-content-between align-items-center">
                            <h5 class="mb-0 fw-bold fs-4">
                                <i class="bi bi-telephone-forward-fill" style="color: #fb3640"></i>
                                Contacto de Ayuda
                            </h5>
                        </div>

                        <div class="row">
                            <div class="container text-center">
                                <address>
                                    <strong>Junta Comunal de Betania</strong><br>
                                    Camino Real de Betania<br>
                                    <abbr title="Telefonos">T:</abbr>
                                    (507) 229-1166, Ext. 116
                                </address>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </section>


        <div class="modal fade" id="cancelarTramiteModal" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticmodal" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content px-4">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Confirmación de Eliminación de Solicitud</h5>
                    </div>
                    <asp:Label runat="server" CssClass="fw-bolder text-center" Text="¿Está seguro de Eliminar esta solicitud?"></asp:Label>
                    <span>N. Control: 
                        <asp:Label ID="EliminarTramiteId" runat="server" class="modal-body"></asp:Label>
                    </span>
                    <span>Estado: 
                        <asp:Label ID="EliminarTramiteEstado" runat="server" class="modal-body"></asp:Label>
                    </span>
                    <span>Categoría: 
                        <asp:Label ID="EliminarTramiteCategoria" runat="server" class="modal-body"></asp:Label>
                    </span>
                    <span>Fecha: 
                        <asp:Label ID="EliminarTramiteFecha" runat="server" class="modal-body"></asp:Label>
                    </span>

                    <div class="modal-footer">
                        <asp:LinkButton ID="aceptar" CssClass="spin btn btn-danger" runat="server" OnClick="aceptar_Click">Si</asp:LinkButton>
                        <asp:LinkButton ID="negar" CssClass="spin btn btn-primary" runat="server" OnClick="negar_Click">No</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>

    </section>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/v/bs5/jq-3.6.0/dt-1.13.1/r-2.4.0/rr-1.3.1/datatables.min.css" />

    <script type="text/javascript" src="https://cdn.datatables.net/v/bs5/jq-3.6.0/dt-1.13.1/r-2.4.0/rr-1.3.1/datatables.min.js"></script>

    <script src="../../Scripts/_buttoms.js"></script>
    <script src="../../Scripts/_modals.js"></script>
    <script src="../../Scripts/ejemplo.js"></script>
</asp:Content>
