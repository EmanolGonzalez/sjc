<%@ Page Title="Tramite" Language="C#" MasterPageFile="~/Layouts/master/Access.Master" AutoEventWireup="true" CodeBehind="Tramite.aspx.cs" Inherits="sjc.App.Private.Tramite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/site.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section style="background-color: #eee;">

        <div class="container py-5">
            <div class="row">
                <h1 class=" display-4 text-center">
                    <asp:Label ID="FormCate" runat="server" Text=""></asp:Label>
                </h1>
            </div>
            <%--encabezado--%>
            <div class="row">
                <h2 class=" display-4 text-center">Solicitud #<asp:Label ID="Solicitud" runat="server" Text=""></asp:Label></h2>
            </div>

            <%--mensajes de error--%>
            <div class="container text-center text-danger fw-bold">
                <asp:Label ID="tramitemessage" runat="server" Text=""></asp:Label>
            </div>

            <%--aside de acciones--%>
            <div class="row">

                <div class="col-lg-4 gap-4">
                    <%-- generales del tramite --%>
                    <div class="card my-4 border-0 shadow">
                        <div class="card-body ">

                            <div class="row justify-content-lg-center bg-white p-2 gap-2 rounded-3">

                                <%-- estado --%>
                                <div class="text-start d-inline">
                                    <h4>Estado:
                                        <asp:Label ID="EstadoSolicitud" CssClass="estado text-muted " runat="server" Text=""></asp:Label>
                                    </h4>
                                </div>

                                <%-- nivel del estado --%>
                                <div id="barra" runat="server" class=" rounded text-center text-white" style="background: #0d6efd; height: 20px;">
                                    <asp:Label ID="barraprogreso" runat="server" CssClass="progress-bar progress-bar-striped" Text=""></asp:Label>
                                </div>

                            </div>

                        </div>
                    </div>

                    <%-- historico --%>
                    <div id="panelHistoria" runat="server" visible="false" class="card justify-content-lg-center bg-white my-4 p-2 gap-2 rounded-3 border-0 shadow">
                        <div class="card-body p-0">
                            <div class="row">
                                <asp:GridView ID="HistoriaSolicitud" AutoGenerateColumns="false" BorderStyle="None" CssClass="table table-borderless " runat="server">
                                    <Columns>
                                        <asp:BoundField HeaderText="Histórico" DataField="Historico"  />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                    <%--aprobavion de solicitudes--%>
                    <div id="AprobacionSolicitud" runat="server" visible="false" class="card justify-content-lg-center bg-white my-4 p-2 gap-2 rounded-3 border-0 shadow">
                        <div class="card-body">

                            <div class="row gap-2">
                                <div class="col-12">
                                    <h4>Aprobación de solicitud</h4>
                                </div>
                                <div class="container text-center text-danger fw-bold">
                                    <asp:Label ID="aprobmessage" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-lg-12 d-flex justify-content-center">
                                    <asp:TextBox ID="aprobComentario" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="Ingresar Comentario para el tramite"></asp:TextBox>
                                </div>
                                <div class="col  d-flex  justify-content-center ">
                                    <asp:Button Text="Aceptar" ID="aprobar" runat="server"  CssClass="spinC btn btn-lg btn-outline-success w-100" OnClick="aprobar_Click" />
                                </div>
                                <div class="col  d-flex  justify-content-center">
                                    <asp:Button Text="Rechazar" ID="rechazar" runat="server"  CssClass="spinC btn btn-lg btn-outline-danger w-100" OnClick="rechazar_Click" />
                                </div>
                            </div>

                        </div>
                    </div>

                    <%-- evidencias de realizacion de tramite --%>
                    <div id="panelEvidenciaJC" runat="server" visible="false" class="card p-2 my-4 border-0 shadow">
                        <div class="card-body">

                            <div class="row gap-2">
                                <div class="col-12 text-start">
                                    <h4>Evidencia de realización</h4>
                                </div>

                                <div class="col-12 text-start">
                                    <label class="form-label">(obligatoria) - extensiones .jpeg .jpg .png .pdf, con un maximo de 25 Mb</label>
                                    <asp:Label ID="evidenciaJCBerror" runat="server"></asp:Label>
                                    <asp:FileUpload ID="JCEvidencia" CssClass="form-control" runat="server" />
                                </div>

                                <div class="col-12 text-center">
                                    <asp:Button ID="btnJCEvidencia" runat="server" CssClass="spinC btn btn-primary" Text="Cargar Evidencia" OnClick="btnJCEvidencia_Click" />
                                </div>

                            </div>

                        </div>
                    </div>

                    <%-- estados de tramites --%>
                    <div id="panelCambioEstado" runat="server" visible="false" class="card my-4 border-0 shadow">
                        <div class="card-body ">

                            <div class="row mt-2">
                                <div class="col-12 text-start">
                                    <h4>Cambiar Estado</h4>
                                </div>
                            </div>

                            <div class="row gap-2">
                                <div class="col-sm-12">
                                    <asp:DropDownList ID="SClista1" Visible="false"  CssClass=" form-select" runat="server">
                                        <asp:ListItem Selected="True">Seleccione un Estado</asp:ListItem>

                                        <asp:ListItem Selected="False" class="text-center fw-bolder disabled" Text="PODA" disabled="true"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="En Inspeccion"></asp:ListItem>
                                        <asp:ListItem Value="6" Text="En Progreso"></asp:ListItem>

                                    </asp:DropDownList>
                                </div>

                                <div class="col-sm-12">
                                    <asp:DropDownList ID="SClista2" Visible="false" CssClass=" form-select" runat="server">
                                        <asp:ListItem Selected="True">Seleccione un Estado</asp:ListItem>

                                        <asp:ListItem Selected="False" class="text-center fw-bolder " Text="FUMIGACION" disabled="true"></asp:ListItem>
                                        <asp:ListItem Value="6" Text="En Progreso"></asp:ListItem>

                                    </asp:DropDownList>
                                </div>

                                <div class="col-sm-12">
                                    <asp:DropDownList ID="SClista3" Visible="false"  CssClass=" form-select" runat="server">
                                        <asp:ListItem Selected="True">Seleccione un Estado</asp:ListItem>

                                        <asp:ListItem Selected="False" class="text-center fw-bolder" Text="LIMPIEZA GENERAL" disabled="true"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="En Inspeccion"></asp:ListItem>
                                        <asp:ListItem Value="6" Text="En Progreso"></asp:ListItem>

                                    </asp:DropDownList>
                                </div>

                                <div class="col-sm-12">
                                    <asp:DropDownList ID="SClista4" Visible="false" CssClass=" form-select" runat="server">
                                        <asp:ListItem Selected="True">Seleccione un Estado</asp:ListItem>

                                        <asp:ListItem Selected="False" class="text-center fw-bolder " Text="RECOLECCION" disabled="true"></asp:ListItem>
                                        <asp:ListItem Value="6" Text="En Progreso"></asp:ListItem>

                                    </asp:DropDownList>
                                </div>

                            </div>

                        </div>
                    </div>

                </div>

                <%-- informacion --%>
                <div class="col-lg-8">
                    <div class="card my-4 border-0 shadow-sm">
                        <div class="card-body ">

                            <div class="row">
                                <div class="col-12 text-start">
                                    <h2>Residente</h2>
                                </div>
                            </div>

                            <div class="card mb-4">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <p class="mb-0">Nombre</p>
                                        </div>
                                        <div class="col-sm-9">
                                            <p class="text-muted mb-0">
                                                <asp:Label ID="NombreUsuario" runat="server" Text=""></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <p class="mb-0">
                                                <asp:Label ID="DocUser" runat="server" Text=""></asp:Label>
                                            </p>
                                        </div>
                                        <div class="col-sm-9">
                                            <p class="text-muted mb-0">
                                                <asp:Label ID="IdentificacionUSer" runat="server" Text=""></asp:Label>
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
                                                <asp:Label ID="EmailUser" runat="server" Text=""></asp:Label>
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
                                                <asp:Label ID="CelularUser" runat="server" Text=""></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-12 text-start">
                                    <h2>Solicita</h2>
                                </div>
                            </div>

                            <div class="card mb-4">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <p class="mb-0">Fecha de Solicitud</p>
                                        </div>
                                        <div class="col-sm-9">
                                            <p class="text-muted mb-0">
                                                <asp:Label ID="FechaSolicitud" runat="server" Text=""></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <hr>
                                        <div class="col-sm-3">
                                            <p class="mb-0">Tipo de Solicitud</p>
                                        </div>
                                        <div class="col-sm-9">
                                            <p class=" fw-bolder mb-0">
                                                <asp:Label ID="TipoSolicitud" runat="server" Text=""></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <hr>
                                        <div class="col-sm-3">
                                            <p class="mb-0">Dirección de La Solicitud</p>
                                        </div>
                                        <div class="col-sm-9">
                                            <p class="text-muted mb-0">
                                                <asp:Label ID="DireccionSolicitud" runat="server" Text=""></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <hr>
                                        <div class="col-sm-3">
                                            <p class="mb-0">Descripción de solicitud</p>
                                        </div>
                                        <div class="col-sm-9">
                                            <p class="text-muted mb-0">
                                                <asp:Label ID="DescSolicitud" runat="server" Text=""></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <%--adjuntos--%>
                                    <div id="panelAdjuntos" runat="server" class="row">
                                        <hr>
                                        <div class="col-sm-3">
                                            <p class="mb-0">Adjunto</p>
                                        </div>
                                        <div class="col-sm-9">
                                            <p class="text-muted mb-0">
                                                <asp:LinkButton ID="evadjunto"  CssClass=" spinC btn btn-outline-warning" runat="server" Visible="false" OnClick="evadjunto_Click">Evidencia del Solicicitante</asp:LinkButton>
                                                <asp:LinkButton ID="evadjuntoJC"  CssClass="spinC btn btn-outline-info" runat="server" Visible="false" OnClick="evadjuntoJC_Click">Evidencia de Trabajo Realizado</asp:LinkButton>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <%--botones--%>
            <div class="row mt-4 justify-content-center bg-white p-3 gap-2 rounded-3 shadow-sm">
                <div class="col-lg-3 d-flex justify-content-center">
                    <asp:LinkButton Text="Regresar al Gestor" ID="regresarGestor" runat="server" CssClass="spinC btn btn-lg btn-primary w-100" OnClick="regresarGestor_Click"></asp:LinkButton>
                </div>
                <div class="col-lg-3  d-flex  justify-content-center">
                    <asp:LinkButton Text="Actualizar Tramite" ID="actualizar" runat="server" Visible="false" CssClass=" spinC btn btn-lg btn-success w-100" OnClick="actualizar_Click" ></asp:LinkButton>
                </div>
                <div class="col-lg-3  d-flex  justify-content-center">
                    <asp:LinkButton Text="Terminar Tramite" ID="terminar" runat="server" Visible="false" CssClass="spinC btn btn-lg btn-danger w-100" OnClick="terminar_Click" ></asp:LinkButton>
                </div>
            </div>

        </div>
    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="../../Scripts/_buttoms.js"></script>
    <script src="../../Scripts/_modals.js"></script>
</asp:Content>
