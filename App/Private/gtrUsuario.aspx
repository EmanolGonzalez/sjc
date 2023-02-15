<%@ Page Title="Gestor de Usuario" Language="C#" MasterPageFile="~/Layouts/master/Admin.Master" AutoEventWireup="true" CodeBehind="gtrUsuario.aspx.cs" Inherits="sjc.App.Private.gtrUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- contenido --%>

    <section class=" container py-5">
        <div class="row">
            <div class="col">
                <nav aria-label="breadcrumb" class=" bg-white rounded-3 p-3 mb-4 shadow-sm">
                    <ol class="breadcrumb mb-0">
                        <li class="breadcrumb-item active"><a>Gestor de Usuarios</a></li>
                    </ol>
                </nav>
            </div>
        </div>

        <div class="row justify-content-around  p-3">

            <div class="col-md-6 col-12 mb-4">
                <div class="card border-top-0 border-bottom border-end-0 border-start-0 border-warning border-2 h-100 shadow-sm">
                    <div class="card-body">
                        <div class="d-flex align-items-center">
                            <div class="flex-grow-1">
                                <div class="lead fw-bold text-warning mb-1">Total de Colaboradores</div>
                                <div id="ncolaboradores" runat="server" class="h5"></div>
                            </div>
                            <div class="ms-2">
                                <i class="bi bi-person fs-1 text-gray"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%--<div class="col-xl-3 col-md-3 mb-4 ">
                <div class="card border-top-0 border-bottom-0 border-end-lg border-start-0 border-info h-100 shadow-sm">
                    <div class="card-body">
                        <div class="d-flex align-items-center">
                            <div class="flex-grow-1">
                                <div class="small fw-bold text-info mb-1">Total de Ciudanos</div>
                                <div id="nresidentes" runat="server" class="h5">500</div>
                            </div>
                            <div class="ms-2">
                                <i class="bi bi-person fs-1 text-gray"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>
        </div>

        <div class="row p-3">
            <div class="d-grid p-3 col-12 col-sm-12 col-md-3">
                <asp:LinkButton
                    ID="addColaborado"
                    runat="server"
                    CssClass="spin btn btn-outline-warning"
                    OnClick="addColaborador_Click"
                    data-bs-toggle="mensaje" title="Agregar Nuevo Colaborador"><i class="bi bi-person-plus"></i>Agregar Colaborador</asp:LinkButton>
            </div>
        </div>

        <div class="row p-3">
            <div class="col-12 col-sm-12 col-md-12">

                <div class="shadow bg-white rounded mb-3 overflow-hidden px-3 py-3 d-flex justify-content-between align-items-center">
                    <h5 class="mb-0 fw-bold fs-4">
                        <i class="bi bi-person-badge-fill" style="color: #ff8a65"></i>
                        Colaboradores
                    </h5>
                </div>

                <div class="card mb-4 shadow-sm ">
                    <div class="card-body p-3 border-0">
                        <asp:GridView ID="gridColab" runat="server" UseAccessibleHeader="true" AutoGenerateColumns="false" class="table table-hover" Style="width: 100%" BorderStyle="None">
                            <Columns>
                                <asp:BoundField HeaderText="#" DataField="idC" />
                                <asp:BoundField HeaderText="Identificacion Personal" DataField="ndoc" />
                                <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                                <asp:BoundField HeaderText="Apellido" DataField="apellido" />
                                <asp:BoundField HeaderText="Cargo" DataField="cargo" />
                                <asp:BoundField HeaderText="Departamento" DataField="departamento" />
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:LinkButton
                                            ID="editColaborador"
                                            runat="server"
                                            CssClass="btn btn-success btn-sm"
                                            OnClick="editColaborador_Click"
                                            data-bs-toggle="mensaje" title="Editar Usuario"><i class="bi bi-pencil-square"></i></asp:LinkButton>
                                        <asp:LinkButton
                                            ID="delColaborador"
                                            runat="server"
                                            CssClass="btn btn-danger btn-sm"
                                            OnClick="delColaborador_Click"
                                            data-bs-toggle="mensaje" title="Eliminar Usuario"><i class="bi bi-person-dash"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

        </div>

        <!-- Modal 1-->
        <div class="modal fade" id="addColaboradorModal" aria-hidden="true" aria-labelledby="addColaboradorModalLabel" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="addColaboradorModalLabel">Colaborador</h5>
                        <asp:Label ID="addColaboradorMessage" runat="server"></asp:Label>
                    </div>
                    <div class="modal-body">
                        <div class="row g-3">
                            <div class="col-md-12">
                                <label class="form-label">Control #</label>
                                <asp:Label ID="newColabId" CssClass="fw-bolder" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <label for="" class="form-label">Documento de Identificación</label>
                                <asp:DropDownList CssClass="form-select" ID="newColabDocu" runat="server">
                                    <asp:ListItem Text="Seleccione Documento"></asp:ListItem>
                                    <asp:ListItem Value="Cédula">Cédula</asp:ListItem>
                                    <asp:ListItem Value="Pasaporte">Pasaporte</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <label class="form-label">Número de Identificación</label>
                                <asp:TextBox ID="newColabNumero" CssClass="form-control" runat="server" placeholder="Agregar..."></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label class="form-label">Nombre</label>
                                <asp:TextBox ID="newColabNombre" CssClass="form-control" runat="server" placeholder="Agregar..."></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label class="form-label">Apellido</label>
                                <asp:TextBox ID="newColabApellido" CssClass="form-control" runat="server" placeholder="Agregar..."></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label class="form-label">Telefono</label>
                                <asp:TextBox ID="newColabTelefono" CssClass="form-control" runat="server" placeholder="Agregar..."></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="" class="form-label">Cargo</label>
                                <asp:DropDownList DataTextField="nombre" DataValueField="id" CssClass="form-select" ID="newColabCargo" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <label for="email" class="form-label">Correo Institucional</label>
                                <asp:TextBox ID="newColabCorreo" CssClass="form-control" TextMode="Email" runat="server" placeholder="colaborador@ejemplo.com"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="pass" class="form-label">Contraseña</label>
                                <asp:TextBox ID="colabContrasenaGen" CssClass="form-control text-danger fw-bolder" runat="server" placeholder="Agregue Contraseña"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="" class="form-label">Roles</label>
                                <asp:DropDownList DataTextField="nombre" DataValueField="id" CssClass="form-select" ID="newColabRol" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <label for="" class="form-label">Departamento</label>
                                <asp:DropDownList DataTextField="nombre" DataValueField="id" CssClass="form-select" ID="newColabDepart" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer justify-content-around">
                        <asp:LinkButton Visible="false"
                            ID="btnActaualizarColaborador"
                            runat="server"
                            CssClass="spin btn btn-success"
                            OnClick="btnActaualizarColaborador_Click"
                            data-bs-toggle="mensaje" title="Actualizar Información"><i class="bi bi-pencil-square"></i> Actualizar</asp:LinkButton>
                        <asp:LinkButton Visible="false"
                            ID="btnAddNewColaborador"
                            runat="server"
                            CssClass=" spin btn btn-primary px-5"
                            OnClick="btnAddNewColaborador_Click"
                            data-bs-toggle="mensaje" title="Agregar Usuario"><i class="bi bi-person-plus-fill"></i> Agregar</asp:LinkButton>
                        <asp:LinkButton ID="btnCancelarAddUpd"
                            runat="server"
                            CssClass=" spin btn btn-danger px-5"
                            OnClick="btnCancelarAddUpd_Click"
                            data-bs-toggle="mensaje" title="Cancelar"><i class="bi bi-x-circle"></i>Cerrar</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal 2-->
        <div class="modal fade" id="delConfirmacionModal" data-bs-backdrop="static" data-bs-keyboard="false" data-easein="bounceUpIn" tabindex="-1" aria-labelledby="delConfirmacionModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="staticBackdropLabel">Eliminar Colaborador</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body text-center">
                        ¿Está seguro que desea eliminar este registro?
                        <div class=" text-start">
                            Id #<asp:Label ID="delId" runat="server"></asp:Label>
                        </div>
                        <div class=" text-start">
                            Nombre:
                            <asp:Label ID="delNombre" runat="server"></asp:Label>,
                            <asp:Label ID="delApellido" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button Text="Eliminar" ID="aceptarDelColaborador" runat="server" CssClass="btn btn-primary" OnClick="aceptarDelColaborador_Click" />
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
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
    <script src="../../Scripts/_tooltip.js"></script>
    <script src="../../Scripts/ejemplo.js"></script>
</asp:Content>
