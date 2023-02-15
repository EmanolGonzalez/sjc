<%@ Page Title="Formulario Servicio Comunitario" Language="C#" MasterPageFile="~/Layouts/master/User.Master" AutoEventWireup="true" CodeBehind="FormularioSerCom.aspx.cs" Inherits="sjc.App.Private.FormularioSerCom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" container py-5 gap-5">
        
        <div class="row text-center">
            <h1 class="display-2 mb-4 fw-semibold">Formulario de Servicio Comunitario</h1>
        </div>
                <asp:Label ID="error" runat="server" Text=""></asp:Label>
        <hr />
        <div class="row">
            <h1 class="display-5"><i class="bi bi-1-circle"></i>Datos del Solicitante</h1>
            <hr class=" border border-2 border-primary" />
            <div class="mb-3">
                <label class="form-label">1.1 Número de Identificación Cédula/Pasaporte</label>
                <asp:TextBox ID="formNumIdent" CssClass="form-control" Enabled="false" placeholder="Numero de Identificacion" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">1.2 Nombre Completo</label>
                <asp:TextBox ID="formNameComplet" CssClass="form-control" Enabled="false" placeholder="Nombre" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">1.3 Correo Electrónico</label>
                <asp:TextBox ID="formEmail" CssClass="form-control" Enabled="false" placeholder="Correo" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">1.4 Celular</label>
                <asp:TextBox ID="formCel" CssClass="form-control" Enabled="false" placeholder="Celular" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <h1 class="display-5"><i class="bi bi-2-circle"></i>Datos Generales de la Solicitud</h1>
            <hr class="border border-2 border-primary" />
            <div class="mb-3">
                <label class="form-label">2.1 Sector <span class="text-danger">*</span></label>
                <asp:DropDownList ID="formSectores" CssClass="form-select " runat="server">
                    <asp:ListItem Selected="true">Selecione un Sector</asp:ListItem>
                    <asp:ListItem Value="1 " Text="Altos De Betania"></asp:ListItem>
                    <asp:ListItem Value="2 " Text="Altos De Conrresa"></asp:ListItem>
                    <asp:ListItem Value="3 " Text="Altos De La Gloria"></asp:ListItem>
                    <asp:ListItem Value="4 " Text="Altos De Miraflores"></asp:ListItem>
                    <asp:ListItem Value="5 " Text="Altos Del Chase"></asp:ListItem>
                    <asp:ListItem Value="6 " Text="Altos Del Dorado"></asp:ListItem>
                    <asp:ListItem Value="7 " Text="Ave. La Paz"></asp:ListItem>
                    <asp:ListItem Value="8 " Text="Camino Real"></asp:ListItem>
                    <asp:ListItem Value="9 " Text="Club X"></asp:ListItem>
                    <asp:ListItem Value="10 " Text="Condado Del Rey"></asp:ListItem>
                    <asp:ListItem Value="11 " Text="Dos Mares"></asp:ListItem>
                    <asp:ListItem Value="12 " Text="El Avance"></asp:ListItem>
                    <asp:ListItem Value="13 " Text="El Dorado"></asp:ListItem>
                    <asp:ListItem Value="14 " Text="El Ingenio"></asp:ListItem>
                    <asp:ListItem Value="15 " Text="El Milagro"></asp:ListItem>
                    <asp:ListItem Value="16 " Text="La Alameda"></asp:ListItem>
                    <asp:ListItem Value="17 " Text="La Gloria"></asp:ListItem>
                    <asp:ListItem Value="18 " Text="La Loceria"></asp:ListItem>
                    <asp:ListItem Value="19 " Text="Las 100"></asp:ListItem>
                    <asp:ListItem Value="20 " Text="Las 200"></asp:ListItem>
                    <asp:ListItem Value="21 " Text="Las 300"></asp:ListItem>
                    <asp:ListItem Value="22 " Text="Las 400"></asp:ListItem>
                    <asp:ListItem Value="23 " Text="Las 500"></asp:ListItem>
                    <asp:ListItem Value="24 " Text="Las 600"></asp:ListItem>
                    <asp:ListItem Value="25 " Text="Las 700"></asp:ListItem>
                    <asp:ListItem Value="26 " Text="Las 800"></asp:ListItem>
                    <asp:ListItem Value="27 " Text="Las 900"></asp:ListItem>
                    <asp:ListItem Value="28 " Text="Las Mercedes"></asp:ListItem>
                    <asp:ListItem Value="29 " Text="Linda Vista"></asp:ListItem>
                    <asp:ListItem Value="30 " Text="Lomas Del Dorado"></asp:ListItem>
                    <asp:ListItem Value="31 " Text="Los Angeles"></asp:ListItem>
                    <asp:ListItem Value="32 " Text="Los Libertadores"></asp:ListItem>
                    <asp:ListItem Value="33 " Text="Miraflores"></asp:ListItem>
                    <asp:ListItem Value="34 " Text="Nuevo Paraiso"></asp:ListItem>
                    <asp:ListItem Value="35 " Text="Nuevos Altos De Miraflores"></asp:ListItem>
                    <asp:ListItem Value="36 " Text="Panacasa"></asp:ListItem>
                    <asp:ListItem Value="37 " Text="Plaza Edison"></asp:ListItem>
                    <asp:ListItem Value="38 " Text="Pribanco"></asp:ListItem>
                    <asp:ListItem Value="39 " Text="San Antonio"></asp:ListItem>
                    <asp:ListItem Value="40 " Text="San José"></asp:ListItem>
                    <asp:ListItem Value="41 " Text="Santa Maria"></asp:ListItem>
                    <asp:ListItem Value="42 " Text="Sara Sotillo"></asp:ListItem>
                    <asp:ListItem Value="43 " Text="Tuira Y Chucunaque"></asp:ListItem>
                    <asp:ListItem Value="44 " Text="Urb. Industrial Orillac"></asp:ListItem>
                    <asp:ListItem Value="45 " Text="Villa Caceres 1"></asp:ListItem>
                    <asp:ListItem Value="46 " Text="Villa Caceres 2"></asp:ListItem>
                    <asp:ListItem Value="47 " Text="Villa De Las Fuentes 1"></asp:ListItem>
                    <asp:ListItem Value="48 " Text="Villa De Las Fuentes 2"></asp:ListItem>
                    <asp:ListItem Value="49 " Text="Villa Soberania"></asp:ListItem>

                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label class="form-label">2.2 Dirección, Avenida o Calle del lugar en el cual se encuentra la afectación.<span class="text-danger">*</span></label>
                <asp:TextBox ID="formDireIncident" CssClass="form-control" placeholder="Direccion del Incidente" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">2.3 Tipo de Solicitud <span class="text-danger">*</span></label>
                <asp:DropDownList ID="FormTipoServ" CssClass="form-select " runat="server">
                    <asp:ListItem Selected="True">Seleccione Una Solicitud</asp:ListItem>
                    <asp:ListItem Value="1" Text="Poda"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Fumigacion"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Limpieza General"></asp:ListItem>
                    <asp:ListItem Value="4" Text="Recoleccion"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label class="form-label">2.4 Descripción de Solicitud <span class="text-danger">*</span></label>
                <asp:TextBox ID="formPorqueSol" CssClass="form-control" placeholder="Porque Hace La solicitud" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="adjuntomessage" runat="server" Text=""></asp:Label>
                <label class="form-label">2.5 Evidencias (no obligatoria) - Puede agregar tanto una foto o un documento - extensiones permitidas .jpeg .jpg .png .pfd, con un maximo de 25 Mb</label>
                <asp:FileUpload ID="formServComUploadPicture" CssClass="form-control" runat="server" />
            </div>
        </div>

        <div class="row">
            <h1 class="display-5"><i class="bi bi-3-circle"></i>Declaracion Jurada</h1>
            <hr class="border border-2 border-primary" />
            <div class="mb-3">
                <p>
                    <asp:CheckBox ID="formCheck" runat="server"/>
                    Declaro bajo juramento que la información suministrada a través de esta solicitud es correcta, que he leído y acepto la pena en caso de cometer perjurio en esta solicitud.
                </p>
            </div>
        </div>

        <div class="d-grid">
            <asp:LinkButton ID="formSubmitServCom" OnClick="EnviarSolicitud_Click"  CssClass="spin btn btn-primary form-control"  runat="server" Text="Enviar"></asp:LinkButton>
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="script" runat="server">
    <script src="../../Scripts/_buttoms.js"></script>
</asp:Content>
