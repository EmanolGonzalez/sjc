<%@ Page Title="Gestor de Tramites" Language="C#" MasterPageFile="~/Layouts/master/Admin.Master" AutoEventWireup="true" CodeBehind="gtrTramites.aspx.cs" Inherits="sjc.App.Private.gestorTramites" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/site.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="prueba" runat="server"></asp:Label>
    <section class=" container py-5">

        <section>
            <div class="row">
                <div class="col">
                    <nav aria-label="breadcrumb" class=" bg-white rounded-3 p-3 mb-4 shadow-sm">
                        <ol class="breadcrumb mb-0">
                            <li class="breadcrumb-item active"><a>Gestor de Trámite Junta Comunal</a></li>
                        </ol>
                    </nav>
                </div>
            </div>
        </section>

        <%--paneles de tramites--%>
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
                    <div class="col-12 py-3">
                        <div class="shadow bg-white rounded mb-3 overflow-hidden px-3 py-3 d-flex justify-content-between align-items-center">
                            <h5 class="mb-0 fw-bold fs-4">
                                <i class="bi bi-box2" style="color: #d7e37c"></i>
                                Nuevos Tramites
                            </h5>
                        </div>
                        <div class="card mb-4 shadow-sm border-0">
                            <div class="card-body p-3 ">
                                <asp:Label ID="gridnuevovacio" CssClass="display-4 text-center fw-bold text-dark" runat="server" Text=""></asp:Label>

                                <asp:GridView ID="panelNuevoTramite" runat="server" UseAccessibleHeader="true" AutoGenerateColumns="false" CssClass="table table-striped nowrap dataTable no-footer dtr-inline collapsed" Style="width: 100%" BorderStyle="None">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Acciones">
                                            <ItemTemplate>
                                                <div class="mx-4 d-grid gap-1">
                                                    <asp:LinkButton Text="Ver" runat="server" CssClass="spinC btn form-control btn-info" ID="BtnLeer1" OnClick="BtnLeer_Click"></asp:LinkButton>

                                                    <asp:LinkButton Text="Tomar" runat="server" CssClass="spinC btn form-control btn-warning" ID="Btn1" Visible='<%#BtnVisibility(getRol(),"Btn1")%>' OnClick="BtnTomar_Click"></asp:LinkButton>

                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="No.Tramite" DataField="No.Tramite" />
                                        <asp:BoundField HeaderText="Estado" DataField="Estado" />
                                        <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                                        <asp:BoundField HeaderText="Identificacion" DataField="Identificacion" />
                                        <asp:BoundField HeaderText="Residente" DataField="Residente" />
                                        <asp:BoundField HeaderText="Tipo Solicitud" DataField="Tipo Solicitud" />
                                        <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="tab-pane fade " id="ContentPanel2" role="tabpanel" aria-labelledby="panel2-tab">
                    <div class="col-12 py-3">
                        <div class="shadow bg-white rounded mb-3 overflow-hidden px-3 py-3 d-flex justify-content-between align-items-center">
                            <h5 class="mb-0 fw-bold fs-4">
                                <i class="bi bi-arrow-clockwise" style="color: #111d4a"></i>
                                Tramites en Proceso
                            </h5>
                        </div>
                        <div class="card mb-4 shadow-sm border-0">
                            <div class="card-body p-3 ">
                                <asp:Label ID="gridprocesovacio" CssClass="display-4 text-center fw-bold text-dark" runat="server" Text=""></asp:Label>

                                <asp:GridView ID="panelEnProceso" runat="server" UseAccessibleHeader="true" AutoGenerateColumns="false" class="table table-hover" Style="width: 100%" BorderStyle="None">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Acciones">
                                            <ItemTemplate>
                                                <div class="mx-4 d-grid gap-1">
                                                    <asp:LinkButton runat="server" Text="Ver" CssClass="spinC btn form-control btn-info" ID="BtnLeer2" OnClick="BtnLeer_Click"></asp:LinkButton>
                                                    <asp:LinkButton runat="server" Text="Actualizar" CssClass="spinC btn form-control btn-secondary" ID="Btn2" Visible='<%#BtnVisibility(getRol(),"Btn2")%>' OnClick="BtnActualizar_Click"></asp:LinkButton>

                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="No.Tramite" DataField="No.Tramite" />
                                        <asp:BoundField HeaderText="Estado" DataField="Estado" />
                                        <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                                        <asp:BoundField HeaderText="Identificacion" DataField="Identificacion" />
                                        <asp:BoundField HeaderText="Residente" DataField="Residente" />
                                        <asp:BoundField HeaderText="Tipo Solicitud" DataField="Tipo Solicitud" />
                                        <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
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
                                <i class="bi bi-folder-check" style="color: #fb3640"></i>
                                Historial de Tramites 
                            </h5>
                        </div>
                        <div class="card mb-4 shadow-sm border-0">
                            <div class="card-body p-3">
                                <asp:Label ID="gridfinalizadosvacio" CssClass="display-4 text-center fw-bold text-dark" runat="server" Text=""></asp:Label>

                                <asp:GridView ID="paneHistorial" runat="server" UseAccessibleHeader="true" AutoGenerateColumns="false" CssClass="table table-striped nowrap dataTable no-footer dtr-inline collapsed" Style="width: 100%" BorderStyle="None">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Acciones">
                                            <ItemTemplate>
                                                <div class="mx-4 d-grid gap-1">
                                                    <asp:LinkButton runat="server" Text="Ver" CssClass=" spinC btn form-control btn-info" ID="BtnLeer3" OnClick="BtnLeer_Click"></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="No.Tramite" DataField="No.Tramite" />
                                        <asp:BoundField HeaderText="Estado" DataField="Estado" />
                                        <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                                        <asp:BoundField HeaderText="Identificacion" DataField="Identificacion" />
                                        <asp:BoundField HeaderText="Residente" DataField="Residente" />
                                        <asp:BoundField HeaderText="Tipo Solicitud" DataField="Tipo Solicitud" />
                                        <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </section>

    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/v/bs5/jq-3.6.0/dt-1.13.1/r-2.4.0/rr-1.3.1/datatables.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/v/bs5/jq-3.6.0/dt-1.13.1/r-2.4.0/rr-1.3.1/datatables.min.js"></script>

    <script src="../../Scripts/_buttoms.js"></script>
    <script src="../../Scripts/_modals.js"></script>
    <script src="../../Scripts/ejemplo.js"></script>
</asp:Content>
