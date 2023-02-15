<%@ Page Title="Registro al Sistema" Language="C#" MasterPageFile="~/Layouts/master/Access.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="sjc.App.Public.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/mfreg.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--header--%>
    <div class=" bg-white container d-flex rounded py-2">
        <asp:HyperLink CssClass="btn btn-secondary me-auto m-0" runat="server" NavigateUrl="~/App/Public/Login.aspx"><i class="bi bi-arrow-bar-left"></i>Regresar</asp:HyperLink>
        <h1 class="me-auto m-0">Registro al Sistema</h1>
        <asp:HyperLink CssClass="btn " runat="server"></asp:HyperLink>
    </div>

    <%--register body--%>
    <div class="content__inner my-3">
        <div class="container">
            <div class="multisteps-form">
                <%-- botones --%>
                <div class="row">
                    <%-- barra de progreso --%>
                    <div class="col-12 col-lg-8 mx-auto mb-4">
                        <div class="multisteps-form__progress">
                            <spam class="multisteps-form__progress-btn js-active"><i class="bi bi-person-badge"></i>Identificación</spam>
                            <spam id="regValidaterviewHead" runat="server" class="multisteps-form__progress-btn"><i class="bi bi-check-circle"></i>validación</spam>
                            <spam id="regDataviewHead" runat="server" class="multisteps-form__progress-btn"><i class="bi bi-pencil-square"></i>Datos Generales</spam>
                            <spam id="regRegisterviewHead" runat="server" class="multisteps-form__progress-btn"><i class="bi bi-person-plus"></i>Registro</spam>
                        </div>
                    </div>
                </div>

                <%-- cuerpo form --%>
                <div class="row">
                    <div class="col-12 col-lg-8 m-auto">
                        <div class=" container text-center py-1">
                            <asp:Label ID="regMessagge" CssClass="fw-semibold" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="multisteps-form__form">

                            <div class="multisteps-form__panel shadow p-4 rounded bg-white js-active" data-animation="scaleIn">
                                <h3 class="multisteps-form__title">Identificación</h3>
                                <div class="multisteps-form__content">
                                    <%-- Identificacion y validacion  --%>
                                    <div class="row mt-4">
                                        <p>Para la identificación es necesario seleccionar un tipo de documento, y luego ingresar su número de identificación tal cual está en su documento elegido.</p>
                                        <%-- select documento --%>
                                        <div class="col-12 col-sm-6">
                                            <div class="form-floating ">
                                                <asp:DropDownList CssClass="form-select regDocumentType" ID="regDocumentType" runat="server">
                                                    <asp:ListItem Selected="true" Text="Seleccione documento"></asp:ListItem>
                                                    <asp:ListItem Value="Cédula">Cédula</asp:ListItem>
                                                    <asp:ListItem Value="Pasaporte">Pasaporte</asp:ListItem>
                                                </asp:DropDownList>
                                                <label for="documentType">Documento</label>
                                            </div>
                                        </div>
                                        <%-- ingreso de numero de identificacion --%>
                                        <div class="col-12 col-sm-6 mt-4 mt-sm-0">
                                            <div class="form-floating">
                                                <asp:TextBox ID="regIdentiNumber" CssClass="form-control regIdentiNumber" Text="" runat="server" Enabled="false"></asp:TextBox>
                                                <label for="regIdentiNumber">Número de Identificación *</label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="justify-content-between d-flex mt-4">


                                        <asp:LinkButton ID="regBtnVerify" CssClass="spin btn btn-warning" Visible="true" runat="server" OnClick="regBtnVerify_Click" ToolTip="Validar">
                                            <%--<p> Validar Documento</p>--%>
                                             Validar Documento
                                        </asp:LinkButton>



                                        <button id="btnIdenti" name="btnIdenti" runat="server" class="btnIdenti btn btn-primary ml-auto js-btn-next" type="button" title="Next" disabled>Siguiente</button>
                                    </div>
                                </div>
                            </div>

                            <div id="regValidateViu" runat="server" class="multisteps-form__panel shadow p-4 rounded bg-white" data-animation="scaleIn">
                                <h3 class="multisteps-form__title">Validacion de Identidad</h3>
                                <div class="multisteps-form__content">

                                    <%-- validacion Generales --%>

                                    <div class="row">
                                        <div class="col-6">
                                            <div class="card-header fw-semibold">¿Cuál es su fecha de nacimiento? *</div>
                                            <div class="card-body">
                                                <asp:RadioButtonList ID="RadioButtonListFechas" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Table" CellPadding="10">
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="card-header fw-semibold">¿Cuál es el apellido paterno de su Padre? *</div>
                                            <div class="card-body">
                                                <asp:RadioButtonList ID="RadioButtonListApellidoPadre" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Table" CellPadding="10">
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="card-header fw-semibold">¿En qué provincia queda su centro de votación? *</div>
                                            <div class="card-body">
                                                <asp:RadioButtonList ID="RadioButtonListProvinciaCentro" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Table" CellPadding="10">
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="card-header fw-semibold">¿Cuál es su centro de votacion? *</div>
                                            <div class="card-body">
                                                <asp:RadioButtonList ID="RadioButtonListApellidoMadre" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Table" CellPadding="10">
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="justify-content-between d-flex mt-4">
                                        <%--<button class="btn btn-primary js-btn-prev" type="button" title="Prev">Anterior</button>--%>
                                        <asp:LinkButton ID="verificarPersona" CssClass="spin btn btn-warning" Visible="true" runat="server" OnClick="verificarPersona_Click" ToolTip="Validar">
                                            Autenticar Persona
                                        </asp:LinkButton>
                                        <button id="btnVali" runat="server" visible="false" class="btn btnData btn-primary ml-auto js-btn-next" type="button" title="Next">Siguiente</button>
                                    </div>
                                </div>
                            </div>

                            <div id="regDataViu" runat="server" class="multisteps-form__panel shadow p-4 rounded bg-white" data-animation="scaleIn">
                                <h3 class="multisteps-form__title">Datos Generales</h3>
                                <div class="multisteps-form__content">

                                    <%-- Contacto info consumida--%>
                                    <div class="row mt-4">
                                        <div class="input-group">
                                            <span class="input-group-text fw-semibold">Nombres: </span>
                                            <asp:TextBox ID="regFname" placeholder="Primer Nombre *" CssClass="form-control text-capitalize regFname" runat="server" aria-label="First name"></asp:TextBox>
                                            <asp:TextBox ID="regSname" placeholder="Segundo Nombre" CssClass="form-control text-capitalize regSname" runat="server" aria-label="Second name"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mt-4">
                                        <div class="input-group">
                                            <span class="input-group-text fw-semibold">Apellidos: </span>
                                            <asp:TextBox ID="regFlname" placeholder="Apellido Paterno*" CssClass="form-control text-capitalize regFlname" runat="server" aria-label="First lastname"></asp:TextBox>
                                            <asp:TextBox ID="regSlname" placeholder="Apellino materno" CssClass="form-control text-capitalize regSlname" runat="server" aria-label="Second lastname"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mt-4">
                                        <div class="input-group">
                                            <span class="input-group-text fw-semibold">Fecha de Nacimiento *</span>
                                            <asp:TextBox ID="regUbirth" CssClass="form-control regUbirth" TextMode="Date" runat="server" aria-label="birth"></asp:TextBox>
                                        </div>
                                    </div>
                                    <hr />
                                    <%-- Contacto ingresada--%>

                                    <div class="row mt-4">
                                        <p class="mt-2">Debe ingresar una dirección con el siguiente formato: Provincia, Distrito, Corregimiento, Barrio de residencia, calle de residencia, # (casa o apartamento).</p>
                                        <div class="input-group">
                                            <span class="input-group-text fw-semibold">Dirección de residencia  *</span>
                                            <asp:TextBox ID="regDirect" CssClass="form-control regDirect" placeholder="Ingrese la dirección con el formato especificado, por favor." TextMode="MultiLine" runat="server" aria-label="dierection"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-12 mt-4">
                                            <p>Debe ingresar ya sea un número de teléfono (residencial o celular) sin guion, ejemplos:</p>
                                            <p>Residencial: 484####</p>
                                            <p>Celular: 6216####</p>

                                            <div class="input-group">
                                                <span class="input-group-text fw-semibold">Teléfono *</span>
                                                <asp:TextBox ID="regCel" CssClass="form-control regCel" runat="server" MaxLength="8" placeholder="telefono" aria-label="Celular"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-12 mt-4">
                                            <p>Debe ingresar un correo personal, válido para recibir las notificaciones del sistema, ejemplo:</p>
                                            <p>Correo: juanhernandez@ejemplo.com</p>
                                            <div class="input-group">
                                                <span class="input-group-text fw-semibold">Correo Electrónico *</span>
                                                <asp:TextBox ID="regEmail" CssClass="form-control regEmail" TextMode="Email" placeholder="user@ejemplo.com" aria-label="email" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="justify-content-between d-flex mt-4 col-12">
                                            <button class="btnContact btn btn-primary ml-auto js-btn-next" type="button" title="Next">Siguiente</button>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div id="regRegisterViu" runat="server" class="multisteps-form__panel shadow p-4 rounded bg-white" data-animation="scaleIn">
                                <h3 class="multisteps-form__title">Registro</h3>
                                <%-- Registro --%>
                                <div class="multisteps-form__content">
                                    <div class="alert alert-warning text-dark" role="alert">
                                        <span>La contraseña debe contar al menos como mínimo los siguientes requisitos:</span>
                                        <ul>
                                            <li class="list-inline passMin">Mínimo 8 Caracteres</li>
                                            <li class="list-inline  passLower">Letras Minúsculas</li>
                                            <li class="list-inline  passUpper">Al menos una letra Mayúscula</li>
                                            <li class="list-inline  passNumber ">Al menos un número</li>
                                            <li class="list-inline  passSpecial ">Al menos un caracter especial. Permitidos @ * _ -</li>
                                        </ul>
                                        <span>Ejemplos: Panam@22 Mundial*3 02Junta*</span>
                                    </div>
                                    <div class="row mt-4">
                                        <div class="col-12 ">
                                            <asp:TextBox ID="regPass" CssClass="form-control regPass" runat="server" placeholder="Contraseña *"></asp:TextBox>
                                        </div>
                                        <div class="col-12 mt-4">
                                            <asp:TextBox ID="regRPass" CssClass="form-control regRPass" runat="server" placeholder="Repetir Contraseña *"></asp:TextBox>
                                        </div>
                                        <div class="col-12 mt-4 form-check">
                                            <p class=" text-secondary">La declaración estará desactivada hasta que cumpla con los requerimientos mínimos de la contraseña</p>
                                            <div class="form-check-inline">
                                                <asp:Label ID="regCheckDecLabel" AssociatedControlID="regCheckDeclaration" CssClass="regDecLabel" runat="server"></asp:Label>
                                                <asp:CheckBox ID="regCheckDeclaration" CssClass="regCheckDeclaration" Checked="false" Enabled="false" runat="server" />
                                            </div>
                                            <asp:Label ID="CheckMessages" CssClass="col-form-label" runat="server" Text="Label">
                                                      <br/>Declaro bajo juramento que la información suministrada a través de esta solicitud es correcta, que he leído y acepto la pena en caso de cometer perjurio en esta solicitud.
                                            </asp:Label>
                                        </div>
                                    </div>
                                    <div class="justify-content-between d-flex mt-4">
                                        <button class="btn btn-primary js-btn-prev" type="button" title="Prev">Anterior</button>

                                        <asp:LinkButton ID="regBtnSubmit" CssClass="regBtnSubmit spin btn btn-success disabled" Visible="true" runat="server" OnClick="regBtnSubmit_Click" ToolTip="Registrar">
                                            <%--<p> Validar Documento</p>--%>
                                             Registrar
                                        </asp:LinkButton>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="../../Scripts/multiformcontrol.js"></script>
</asp:Content>
