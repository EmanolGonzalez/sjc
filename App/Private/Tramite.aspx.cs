using System;
using System.Data;
using System.Web.UI;


namespace sjc.App.Private
{
    public partial class Tramite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifySessions();

            if (!IsPostBack)
            {
                string TramitePedido = Request.QueryString["idTramite"];
                string operacion = Request.QueryString["op"];
                Solicitud.Text = TramitePedido;
                verificarOpcion(operacion);
                verificarTramite(Convert.ToInt64(TramitePedido));
            }

        }
        protected void VerifySessions()
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/App/Private/AdminLog.aspx");
            }
        }


        // Regresar al gestor
        protected void regresarGestor_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/App/Private/gtrTramites.aspx");
        }

        //opcion de vista
        public void verificarOpcion(string sOpc)
        {
            if (sOpc != null)
            {
                switch (sOpc)
                {
                    case "R":
                        panelHistoria.Visible = true;
                        actualizar.Visible = false;
                        terminar.Visible = false;

                        break;
                    case "U":
                        panelHistoria.Visible = true;
                        panelCambioEstado.Visible = true;
                        actualizar.Visible = true;
                        terminar.Visible = true;
                        break;
                }
            }
        }


        //Seccion Tramite

        //barra de progreso del estado del tramite
        public void barraProgreso(string tipo, string est)
        {
            if (tipo == "Poda")
            {
                string valor = "";
                string progreso = "";
                switch (est)
                {
                    case "Entregado":
                        valor = "b20";
                        progreso = "10%";
                        break;
                    case "Iniciado":
                        valor = "b20";
                        progreso = "20%";
                        break;
                    case "En Inspeccion":
                        valor = "b40";
                        progreso = "40%";
                        break;
                    case "Aprobado":
                        valor = "b60";
                        progreso = "60%";
                        break;
                    case "En Progreso":
                        valor = "b80";
                        progreso = "80%";
                        break;
                    case "Terminado":
                        valor = "bc bg-success";
                        progreso = "100%";
                        break;

                    case "Rechazado":
                        valor = "bc bg-danger";
                        progreso = "100%";
                        break;
                    case "Cancelado":
                        valor = "bc bg-warning";
                        progreso = "100%";
                        break;
                }
                barraprogreso.Text = progreso;
                barra.Attributes.Add("class", barra.Attributes["class"] + " " + valor);
            }

            if (tipo == "Fumigación")
            {
                string valor = "";
                string progreso = "";

                switch (est)
                {
                    case "Entregado":
                        valor = "b25";
                        progreso = "25%";
                        break;
                    case "Iniciado":
                        valor = "b50";
                        progreso = "50%";
                        break;
                    case "En Progreso":
                        valor = "b75";
                        progreso = "75%";
                        break;
                    case "Terminado":
                        valor = "bc bg-success";
                        progreso = "100%";
                        break;
                    case "Cancelado":
                        valor = "bc bg-warning";
                        progreso = "100%";
                        break;
                }

                barraprogreso.Text = progreso;
                barra.Attributes.Add("class", barra.Attributes["class"] + " " + valor);
            }

            if (tipo == "Limpieza General")
            {
                string valor = "";
                string progreso = "";
                switch (est)
                {
                    case "Entregado":
                        valor = "b20";
                        progreso = "10%";
                        break;
                    case "Iniciado":
                        valor = "b20";
                        progreso = "20%";
                        break;
                    case "En Inspeccion":
                        valor = "b40";
                        progreso = "40%";
                        break;
                    case "Aprobado":
                        valor = "b60";
                        progreso = "60%";
                        break;
                    case "En Progreso":
                        valor = "b80";
                        progreso = "80%";
                        break;
                    case "Terminado":
                        valor = "bc bg-success";
                        progreso = "100%";
                        break;
                    case "Rechazado":
                        valor = "bc bg-warning";
                        progreso = "100%";
                        break;
                    case "Cancelado":
                        valor = "bc bg-warning";
                        progreso = "100%";
                        break;

                }
                barraprogreso.Text = progreso;
                barra.Attributes.Add("class", barra.Attributes["class"] + " " + valor);
            }

            if (tipo == "Recolección")
            {
                string valor = "";
                string progreso = "";
                switch (est)
                {
                    case "Entregado":
                        valor = "b25";
                        progreso = "25%";
                        break;
                    case "Iniciado":
                        valor = "b50";
                        progreso = "50%";
                        break;
                    case "En Progreso":
                        valor = "b75";
                        progreso = "75%";
                        break;
                    case "Terminado":
                        valor = "bc bg-success";
                        progreso = "100%";
                        break;
                    case "Cancelado":
                        valor = "bc bg-warning";
                        progreso = "100%";
                        break;
                }
                barraprogreso.Text = progreso;
                barra.Attributes.Add("class", barra.Attributes["class"] + " " + valor);
            }
        }

        //historia del tramite
        public void cargarHistoria(Int64 IdS)
        {
            cSolicitudes solicitud = new cSolicitudes();
            HistoriaSolicitud.DataSource = solicitud.gethistsoli(IdS);
            HistoriaSolicitud.DataBind();
        }

        //habilitar panel de estado segun tipo
        public void ordenarPanelEstado(string tipo)
        {
            if (tipo != null)
            {
                switch (tipo)
                {
                    case "Poda":
                        SClista1.Visible = true;
                        break;
                    case "Fumigación":
                        SClista2.Visible = true;
                        break;
                    case "Limpieza General":
                        SClista3.Visible = true;
                        break;
                    case "Recolección":
                        SClista4.Visible = true;
                        break;
                }
            }
            terminar.Visible = false;
        }

        //verificar categoria de tramite
        public void verificarTramite(Int64 IdT)
        {
            cSolicitudes solicitud = new cSolicitudes();

            FormCate.Text = solicitud.getCategoriaTramite(IdT).Tables[0].Rows[0]["nomcate"].ToString();
            string id = solicitud.getCategoriaTramite(IdT).Tables[0].Rows[0]["idcate"].ToString();

            switch (id)
            {
                case "1":
                    traerTramiteServCom(IdT);
                    break;
            }
        }

        //traer informacion del tramite
        public void traerTramiteServCom(Int64 IdT)
        {
            cSolicitudes solicitud = new cSolicitudes();
            DataSet data = solicitud.getTramite(IdT);
            NombreUsuario.Text = data.Tables[0].Rows[0]["nombre"].ToString();
            DocUser.Text = data.Tables[0].Rows[0]["Documentacion"].ToString();
            IdentificacionUSer.Text = data.Tables[0].Rows[0]["identificacion"].ToString();
            EmailUser.Text = data.Tables[0].Rows[0]["email"].ToString();
            CelularUser.Text = data.Tables[0].Rows[0]["celular"].ToString();
            FechaSolicitud.Text = data.Tables[0].Rows[0]["fecha"].ToString();
            TipoSolicitud.Text = data.Tables[0].Rows[0]["tipo"].ToString();
            DireccionSolicitud.Text = data.Tables[0].Rows[0]["direccion"].ToString();
            DescSolicitud.Text = data.Tables[0].Rows[0]["descricion"].ToString();
            EstadoSolicitud.Text = data.Tables[0].Rows[0]["estado"].ToString();

            cargarHistoria(IdT);
            barraProgreso(data.Tables[0].Rows[0]["tipo"].ToString(), data.Tables[0].Rows[0]["estado"].ToString());
            mostrarAdjunto(data.Tables[0].Rows[0]["adjuntoUser"].ToString(), data.Tables[0].Rows[0]["adjuntoJC"].ToString());

            flujoTramite(data.Tables[0].Rows[0]["estado"].ToString(), 
                        data.Tables[0].Rows[0]["tipo"].ToString(),
                        data.Tables[0].Rows[0]["adjuntoUser"].ToString(),
                        data.Tables[0].Rows[0]["adjuntoJC"].ToString());

        }

        public void  flujoTramite(string status, string tipo, string adjresi, string adjjunta)
        {
            switch (status)
            {
                case "Iniciado":
                    ordenarPanelEstado(tipo);
                    break;
                case "En Inspección":
                    verificarAprobadoRechazo(status,tipo);
                    break;                
                case "En Progreso":
                    verificarTerminacion(status,adjjunta);
                    verificaRealizacion(adjjunta);
                    break;
                case "Aprobado":
                    ordenarPanelEstado(tipo);
                    break;
                case "Rechazado":
                    panelCambioEstado.Visible = false;
                    actualizar.Visible = false;
                    terminar.Visible = false;
                    break;                               
                case "Terminado":
                    panelCambioEstado.Visible = false;
                    actualizar.Visible = false;
                    terminar.Visible = false;
                    break;

            }
        }
        public  dynamic traerEstado(string tipo)
        {
            dynamic[] respuesta = null;
             
            switch (tipo)
            {
                case "Poda":
                    respuesta = new dynamic[] {SClista1.SelectedItem.Text, SClista1.SelectedValue };
                    break;
                case "Fumigación":
                     respuesta = new dynamic[] { SClista2.SelectedItem.Text, SClista2.SelectedValue };
                    break;
                case "Limpieza General":
                    respuesta =  new dynamic[] { SClista3.SelectedItem.Text, SClista3.SelectedValue };
                    break;
                case "Recolección":
                    respuesta = new dynamic[] { SClista4.SelectedItem.Text, SClista4.SelectedValue };
                    break;
            }
            return respuesta;
        }

        // actualizacion de estados tramite
        protected void actualizar_Click(object sender, EventArgs e)
        {

            var tipoS = traerEstado( TipoSolicitud.Text);



            if (!(tipoS[0] != "Seleccione un Estado"))
            {
                tramitemessage.Text = "Selecionar un estado";
            }
            else if (!(EstadoSolicitud.Text != tipoS[0]))
            {
                tramitemessage.Text = "No Puedes Elegir el estado actual!";
            }
            else
            {
                Int64 TramitePedido = Convert.ToInt64(Request.QueryString["idTramite"]);
                cSolicitudes solicitud = new cSolicitudes();
                string estadoaAnt = EstadoSolicitud.Text;
                solicitud.ChangeStatusSoli(TramitePedido, tipoS[1]);
                solicitud.sethistSoli(TramitePedido, Session["ColaboradorName"].ToString() + " cambio de " + estadoaAnt + " a " + tipoS[0] + " el tramite #" + Request.QueryString["idTramite"]);
                correoCambio(estadoaAnt, tipoS[0]);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }


        //finaliacion de tramite
        public void verificarTerminacion(string estado, string adjuntoJC)
        {
            if (estado == "En Progreso" && adjuntoJC == "" && Request.QueryString["op"] == "U")
            {
                panelEvidenciaJC.Visible = true;
                panelCambioEstado.Visible = false;
                actualizar.Visible=false;
                terminar.Visible = false;

            }
            if(estado == "Terminado" && adjuntoJC != "")
            {
                terminar.Visible = false;
            }
        }
        protected void terminar_Click(object sender, EventArgs e)
        {
            Int64 TramitePedido = Convert.ToInt64(Request.QueryString["idTramite"]);
            cSolicitudes solicitud = new cSolicitudes();
            string estadoaAnt = EstadoSolicitud.Text;
            solicitud.ChangeStatusSoli(TramitePedido, "7");
            solicitud.sethistSoli(TramitePedido, Session["ColaboradorName"].ToString() + " cambio de " + estadoaAnt + " a Finalizado el tramite #" + Request.QueryString["idTramite"]);

            correoCambio(estadoaAnt,"Finalizado");

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }


        private void correoCambio(string anterio, string nuevo)
        {
            //correo para notificar que la solicitud ha sido toma
            string email = EmailUser.Text;
            string usuarionombre = NombreUsuario.Text;

            cCorreo correo = new cCorreo();
            DateTime theDate = DateTime.Now;
            string asunto = "<html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\"><head><meta charset=\"UTF-8\"> <meta content=\"\\\\&quot;width=device-width,initial-scale=1\\\\&quot;name=viewport\"> <meta name=\"x-apple-disable-message-reformatting\"> <meta content=\"\\\\&quot;IE=edge\\\\&quot;http-equiv=X-UA-Compatible\"> <meta content=\"\\\\&quot;telephone=no\\\\&quot;name=format-detection\"> <title>New email template 2022-10-08</title><!--[if (mso 16)]><style>a{text-decoration:none}</style><![endif]--><!--[if gte mso 9]><style>sup{font-size:100%!important}</style><![endif]--><!--[if gte mso 9]><xml><o:officedocumentsettings><o:allowpng></o:allowpng><o:pixelsperinch>96</o:pixelsperinch></o:officedocumentsettings></xml><![endif]--><!--[if !mso]><!----> <link href=\"\\\\&quot;https://fonts.googleapis.com/css?family=Roboto:400,400i,700,700i\\\\&quot;rel=stylesheet\"><!--<![endif]--> <style>.rollover:hover .rollover-first{max-height:0 !important;display:none !important}.rollover:hover .rollover-second{max-height:none !important;display:block !important}#outlook a{padding:0}.es-button{mso-style-priority:100 !important;text-decoration:none !important}a[x-apple-data-detectors]{color:inherit !important;text-decoration:none !important;font-size:inherit !important;font-family:inherit !important;font-weight:inherit !important;line-height:inherit !important}.es-desk-hidden{display:none;float:left;overflow:hidden;width:0;max-height:0;line-height:0;mso-hide:all}.es-button-border:hover{border-style:solid !important;background:#0b317e !important;border-color:#42d159 !important}.es-button-border:hover a.es-button,.es-button-border:hover button.es-button{background:#0b317e !important;border-color:#0b317e !important}[data-ogsb] .es-button{border-width:0 !important;padding:10px 20px !important}@media only screen and (max-width:600px){a,ol li,p,ul li{line-height:150% !important}h1,h1 a,h2,h2 a,h3,h3 a{line-height:120% !important}h1{font-size:30px !important;text-align:center}h2{font-size:26px !important;text-align:center}h3{font-size:20px !important;text-align:center}.st-br{padding-left:10px !important;padding-right:10px !important}h1 a{text-align:center}.es-content-body h1 a,.es-footer-body h1 a,.es-header-body h1 a{font-size:30px !important}h2 a{text-align:center}.es-content-body h2 a,.es-footer-body h2 a,.es-header-body h2 a{font-size:26px !important}h3 a{text-align:center}.es-content-body h3 a,.es-footer-body h3 a,.es-header-body h3 a{font-size:20px !important}.es-menu td a{font-size:14px !important}.es-header-body a,.es-header-body ol li,.es-header-body p,.es-header-body ul li{font-size:16px !important}.es-content-body a,.es-content-body ol li,.es-content-body p,.es-content-body ul li{font-size:16px !important}.es-footer-body a,.es-footer-body ol li,.es-footer-body p,.es-footer-body ul li{font-size:14px !important}.es-infoblock a,.es-infoblock ol li,.es-infoblock p,.es-infoblock ul li{font-size:12px !important}[class=gmail-fix]{display:none !important}.es-m-txt-c,.es-m-txt-c h1,.es-m-txt-c h2,.es-m-txt-c h3{text-align:center !important}.es-m-txt-r,.es-m-txt-r h1,.es-m-txt-r h2,.es-m-txt-r h3{text-align:right !important}.es-m-txt-l,.es-m-txt-l h1,.es-m-txt-l h2,.es-m-txt-l h3{text-align:left !important}.es-m-txt-c img,.es-m-txt-l img,.es-m-txt-r img{display:inline !important}.es-button-border{display:block !important}a.es-button,button.es-button{font-size:16px !important;display:block !important;border-left-width:0 !important;border-right-width:0 !important}.es-adaptive table,.es-left,.es-right{width:100% !important}.es-content,.es-content table,.es-footer,.es-footer table,.es-header,.es-header table{width:100% !important;max-width:600px !important}.es-adapt-td{display:block !important;width:100% !important}.adapt-img{width:100% !important;height:auto !important}.es-m-p0{padding:0 !important}.es-m-p0r{padding-right:0 !important}.es-m-p0l{padding-left:0 !important}.es-m-p0t{padding-top:0 !important}.es-m-p0b{padding-bottom:0 !important}.es-m-p20b{padding-bottom:20px !important}.es-hidden,.es-mobile-hidden{display:none !important}table.es-desk-hidden,td.es-desk-hidden,tr.es-desk-hidden{width:auto !important;overflow:visible !important;float:none !important;max-height:inherit !important;line-height:inherit !important}tr.es-desk-hidden{display:table-row !important}table.es-desk-hidden{display:table !important}td.es-desk-menu-hidden{display:table-cell !important}.esd-block-html table,table.es-table-not-adapt{width:auto !important}table.es-social{display:inline-block !important}table.es-social td{display:inline-block !important}.es-m-p5{padding:5px !important}.es-m-p5t{padding-top:5px !important}.es-m-p5b{padding-bottom:5px !important}.es-m-p5r{padding-right:5px !important}.es-m-p5l{padding-left:5px !important}.es-m-p10{padding:10px !important}.es-m-p10t{padding-top:10px !important}.es-m-p10b{padding-bottom:10px !important}.es-m-p10r{padding-right:10px !important}.es-m-p10l{padding-left:10px !important}.es-m-p15{padding:15px !important}.es-m-p15t{padding-top:15px !important}.es-m-p15b{padding-bottom:15px !important}.es-m-p15r{padding-right:15px !important}.es-m-p15l{padding-left:15px !important}.es-m-p20{padding:20px !important}.es-m-p20t{padding-top:20px !important}.es-m-p20r{padding-right:20px !important}.es-m-p20l{padding-left:20px !important}.es-m-p25{padding:25px !important}.es-m-p25t{padding-top:25px !important}.es-m-p25b{padding-bottom:25px !important}.es-m-p25r{padding-right:25px !important}.es-m-p25l{padding-left:25px !important}.es-m-p30{padding:30px !important}.es-m-p30t{padding-top:30px !important}.es-m-p30b{padding-bottom:30px !important}.es-m-p30r{padding-right:30px !important}.es-m-p30l{padding-left:30px !important}.es-m-p35{padding:35px !important}.es-m-p35t{padding-top:35px !important}.es-m-p35b{padding-bottom:35px !important}.es-m-p35r{padding-right:35px !important}.es-m-p35l{padding-left:35px !important}.es-m-p40{padding:40px !important}.es-m-p40t{padding-top:40px !important}.es-m-p40b{padding-bottom:40px !important}.es-m-p40r{padding-right:40px !important}.es-m-p40l{padding-left:40px !important}.es-desk-hidden{display:table-row !important;width:auto !important;overflow:visible !important;max-height:inherit !important}.h-auto{height:auto !important}}</style> </head><body neue=\"\" style=\"\\\\&quot;width:100%;font-family:roboto,'helvetica\"><div class=\"es-wrapper-color\" style=\"background-color: #FAFAFA\"> <!--[if gte mso 9]><v:background xmlns:v=\"urn:schemas-microsoft-com:vml\" fill=\"t\"><v:fill type=\"tile\" color=\"#fafafa\"></v:fill></v:background><![endif]--> <table class=\"es-wrapper\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top;background-color:#FAFAFA\"><tbody><tr><td valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-content\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0\"><table bgcolor=\"#ffffff\" class=\"es-content-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0;padding-top:15px;padding-left:20px;padding-right:20px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;padding-top:10px;padding-bottom:10px;font-size:0px\"><img src=\"https://zpxohn.stripocdn.email/content/guids/CABINET_54100624d621728c49155116bef5e07d/images/84141618400759579.png\" alt=\"\" style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\" width=\"100\"></td></tr><tr><td align=\"center\" class=\"es-m-txt-c\" style=\"padding:0;Margin:0;padding-bottom:10px\"><h1 style=\"Margin:0;line-height:40px;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;font-size:40px;font-style:normal;font-weight:bold;color:#333333\"><b>Sistema de Junta Comunal</b><br></h1></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-content\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0\"><table bgcolor=\"#ffffff\" class=\"es-content-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px\"><tbody><tr><td align=\"left\" style=\"Margin:0;padding-bottom:5px;padding-top:20px;padding-left:20px;padding-right:20px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" class=\"es-m-p0r es-m-p0l\" style=\"Margin:0;padding-top:5px;padding-bottom:15px;padding-left:40px;padding-right:40px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#0a2b6e;font-size:14px\"><span style=\"font-size:26px;font-family:'lucida sans unicode', 'lucida grande', sans-serif\"><strong>" + usuarionombre + "</strong></span><br><span style=\"color:#696969\">¡El estado de su solicitud ha cambiado!</span></p></td></tr><tr><td align=\"center\" class=\"es-m-txt-c\" style=\"padding:0;Margin:0\"><h2 style=\"Margin:0;line-height:28px;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;font-size:23px;font-style:normal;font-weight:bold;color:#333333\">Solicitud&nbsp;<a target=\"_blank\" href=\"\" style=\"-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:underline;color:#5C68E2;font-size:23px\">#" + Request.QueryString["idTramite"] + "</a></h2></td></tr><tr><td align=\"center\" class=\"es-m-p0r es-m-p0l\" style=\"Margin:0;padding-top:5px;padding-bottom:5px;padding-left:40px;padding-right:40px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px\">" + theDate.ToString("MMMM dd, yyyy H:mm:ss") + "</p></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td class=\"esdev-adapt-off\" align=\"left\" style=\"Margin:0;padding-top:10px;padding-bottom:10px;padding-left:20px;padding-right:20px\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"esdev-mso-table\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:560px\"><tbody><tr><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;width:70px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px\"><strong>Estado Anterio:</strong></p></td></tr></tbody></table></td></tr></tbody></table></td><td style=\"padding:0;Margin:0;width:20px\"></td><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;width:265px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;display:none\"></td></tr></tbody></table></td></tr></tbody></table></td><td style=\"padding:0;Margin:0;width:20px\"></td><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0;width:80px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;display:none\"></td></tr></tbody></table></td></tr></tbody></table></td><td style=\"padding:0;Margin:0;width:20px\"></td><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-right\" align=\"right\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:right\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0;width:85px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"right\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px\">" + anterio + "</p></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td class=\"esdev-adapt-off\" align=\"left\" style=\"Margin:0;padding-top:10px;padding-bottom:10px;padding-left:20px;padding-right:20px\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"esdev-mso-table\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:560px\"><tbody><tr><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;width:70px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px\"><strong>Estado Nuevo:</strong></p></td></tr></tbody></table></td></tr></tbody></table></td><td style=\"padding:0;Margin:0;width:20px\"></td><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;width:265px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;display:none\"></td></tr></tbody></table></td></tr></tbody></table></td><td style=\"padding:0;Margin:0;width:20px\"></td><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0;width:80px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;display:none\"></td></tr></tbody></table></td></tr></tbody></table></td><td style=\"padding:0;Margin:0;width:20px\"></td><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-right\" align=\"right\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:right\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0;width:85px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"right\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px\">" + nuevo + "</p></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td align=\"left\" style=\"Margin:0;padding-bottom:10px;padding-top:15px;padding-left:20px;padding-right:20px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0;width:560px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;padding-top:10px;padding-bottom:10px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px\">¿Tienes alguna pregunta? Llámenos al +(507) 229-1166, Ext. 1166.</p></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td align=\"left\" bgcolor=\"#0a2b6e\" style=\"Margin:0;padding-bottom:15px;padding-top:20px;padding-left:20px;padding-right:20px;background-color:#0a2b6e\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" bgcolor=\"#0a2b6e\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#ffffff;font-size:14px\">Usted está recibiendo este correo electrónico porque su tramite cambio de estado. Asegúrese de que nuestros mensajes lleguen a su bandeja de entrada (y no a sus carpetas masivas o de correo no deseado).</p></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></div></body></html>";
            correo.Main(email, asunto, "Notificacion de Tramite");
        }


        // Rechazo o Aprobacion de tramites especiales
        public void verificarAprobadoRechazo(string estado, string tipo)
        {
            if (estado == "En Inspección" && (tipo == "Poda" || tipo == "Limpieza General"))
            {
                actualizar.Visible = false;
                terminar.Visible = false;
                panelCambioEstado.Visible = false;
                AprobacionSolicitud.Visible = true;
            }

        }

        protected void aprobar_Click(object sender, EventArgs e)
        {
            AprobRejectTramites("4", "Aprobado");

        }

        protected void rechazar_Click(object sender, EventArgs e)
        {
            AprobRejectTramites("5", "Rechazado");

        }

        protected void AprobRejectTramites(string estado, string caso)
        {

            if (aprobComentario.Text.Length > 0)
            {
                aprobar.Enabled = false;
                rechazar.Enabled = false;
                
                Int64 TramitePedido = Convert.ToInt64(Request.QueryString["idTramite"]);
                cSolicitudes solicitud = new cSolicitudes();
                solicitud.AprobRechSoli(TramitePedido, estado, aprobComentario.Text);
                solicitud.sethistSoli(TramitePedido, Session["ColaboradorName"].ToString() + " " + caso + " el tramite #" + Request.QueryString["idTramite"]);

                //correo para notificar que la solicitud ha sido toma
                string email = EmailUser.Text;
                string usuarionombre = NombreUsuario.Text;

                cCorreo correo = new cCorreo();
                DateTime theDate = DateTime.Now;
                string asunto = "<html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\"><head><meta charset=\"UTF-8\"> <meta content=\"\\\\&quot;width=device-width,initial-scale=1\\\\&quot;name=viewport\"> <meta name=\"x-apple-disable-message-reformatting\"> <meta content=\"\\\\&quot;IE=edge\\\\&quot;http-equiv=X-UA-Compatible\"> <meta content=\"\\\\&quot;telephone=no\\\\&quot;name=format-detection\"> <title>New email template 2022-10-08</title><!--[if (mso 16)]><style>a{text-decoration:none}</style><![endif]--><!--[if gte mso 9]><style>sup{font-size:100%!important}</style><![endif]--><!--[if gte mso 9]><xml><o:officedocumentsettings><o:allowpng></o:allowpng><o:pixelsperinch>96</o:pixelsperinch></o:officedocumentsettings></xml><![endif]--><!--[if !mso]><!----> <link href=\"\\\\&quot;https://fonts.googleapis.com/css?family=Roboto:400,400i,700,700i\\\\&quot;rel=stylesheet\"><!--<![endif]--> <style>.rollover:hover .rollover-first{max-height:0 !important;display:none !important}.rollover:hover .rollover-second{max-height:none !important;display:block !important}#outlook a{padding:0}.es-button{mso-style-priority:100 !important;text-decoration:none !important}a[x-apple-data-detectors]{color:inherit !important;text-decoration:none !important;font-size:inherit !important;font-family:inherit !important;font-weight:inherit !important;line-height:inherit !important}.es-desk-hidden{display:none;float:left;overflow:hidden;width:0;max-height:0;line-height:0;mso-hide:all}.es-button-border:hover{border-style:solid !important;background:#0b317e !important;border-color:#42d159 !important}.es-button-border:hover a.es-button,.es-button-border:hover button.es-button{background:#0b317e !important;border-color:#0b317e !important}[data-ogsb] .es-button{border-width:0 !important;padding:10px 20px !important}@media only screen and (max-width:600px){a,ol li,p,ul li{line-height:150% !important}h1,h1 a,h2,h2 a,h3,h3 a{line-height:120% !important}h1{font-size:30px !important;text-align:center}h2{font-size:26px !important;text-align:center}h3{font-size:20px !important;text-align:center}.st-br{padding-left:10px !important;padding-right:10px !important}h1 a{text-align:center}.es-content-body h1 a,.es-footer-body h1 a,.es-header-body h1 a{font-size:30px !important}h2 a{text-align:center}.es-content-body h2 a,.es-footer-body h2 a,.es-header-body h2 a{font-size:26px !important}h3 a{text-align:center}.es-content-body h3 a,.es-footer-body h3 a,.es-header-body h3 a{font-size:20px !important}.es-menu td a{font-size:14px !important}.es-header-body a,.es-header-body ol li,.es-header-body p,.es-header-body ul li{font-size:16px !important}.es-content-body a,.es-content-body ol li,.es-content-body p,.es-content-body ul li{font-size:16px !important}.es-footer-body a,.es-footer-body ol li,.es-footer-body p,.es-footer-body ul li{font-size:14px !important}.es-infoblock a,.es-infoblock ol li,.es-infoblock p,.es-infoblock ul li{font-size:12px !important}[class=gmail-fix]{display:none !important}.es-m-txt-c,.es-m-txt-c h1,.es-m-txt-c h2,.es-m-txt-c h3{text-align:center !important}.es-m-txt-r,.es-m-txt-r h1,.es-m-txt-r h2,.es-m-txt-r h3{text-align:right !important}.es-m-txt-l,.es-m-txt-l h1,.es-m-txt-l h2,.es-m-txt-l h3{text-align:left !important}.es-m-txt-c img,.es-m-txt-l img,.es-m-txt-r img{display:inline !important}.es-button-border{display:block !important}a.es-button,button.es-button{font-size:16px !important;display:block !important;border-left-width:0 !important;border-right-width:0 !important}.es-adaptive table,.es-left,.es-right{width:100% !important}.es-content,.es-content table,.es-footer,.es-footer table,.es-header,.es-header table{width:100% !important;max-width:600px !important}.es-adapt-td{display:block !important;width:100% !important}.adapt-img{width:100% !important;height:auto !important}.es-m-p0{padding:0 !important}.es-m-p0r{padding-right:0 !important}.es-m-p0l{padding-left:0 !important}.es-m-p0t{padding-top:0 !important}.es-m-p0b{padding-bottom:0 !important}.es-m-p20b{padding-bottom:20px !important}.es-hidden,.es-mobile-hidden{display:none !important}table.es-desk-hidden,td.es-desk-hidden,tr.es-desk-hidden{width:auto !important;overflow:visible !important;float:none !important;max-height:inherit !important;line-height:inherit !important}tr.es-desk-hidden{display:table-row !important}table.es-desk-hidden{display:table !important}td.es-desk-menu-hidden{display:table-cell !important}.esd-block-html table,table.es-table-not-adapt{width:auto !important}table.es-social{display:inline-block !important}table.es-social td{display:inline-block !important}.es-m-p5{padding:5px !important}.es-m-p5t{padding-top:5px !important}.es-m-p5b{padding-bottom:5px !important}.es-m-p5r{padding-right:5px !important}.es-m-p5l{padding-left:5px !important}.es-m-p10{padding:10px !important}.es-m-p10t{padding-top:10px !important}.es-m-p10b{padding-bottom:10px !important}.es-m-p10r{padding-right:10px !important}.es-m-p10l{padding-left:10px !important}.es-m-p15{padding:15px !important}.es-m-p15t{padding-top:15px !important}.es-m-p15b{padding-bottom:15px !important}.es-m-p15r{padding-right:15px !important}.es-m-p15l{padding-left:15px !important}.es-m-p20{padding:20px !important}.es-m-p20t{padding-top:20px !important}.es-m-p20r{padding-right:20px !important}.es-m-p20l{padding-left:20px !important}.es-m-p25{padding:25px !important}.es-m-p25t{padding-top:25px !important}.es-m-p25b{padding-bottom:25px !important}.es-m-p25r{padding-right:25px !important}.es-m-p25l{padding-left:25px !important}.es-m-p30{padding:30px !important}.es-m-p30t{padding-top:30px !important}.es-m-p30b{padding-bottom:30px !important}.es-m-p30r{padding-right:30px !important}.es-m-p30l{padding-left:30px !important}.es-m-p35{padding:35px !important}.es-m-p35t{padding-top:35px !important}.es-m-p35b{padding-bottom:35px !important}.es-m-p35r{padding-right:35px !important}.es-m-p35l{padding-left:35px !important}.es-m-p40{padding:40px !important}.es-m-p40t{padding-top:40px !important}.es-m-p40b{padding-bottom:40px !important}.es-m-p40r{padding-right:40px !important}.es-m-p40l{padding-left:40px !important}.es-desk-hidden{display:table-row !important;width:auto !important;overflow:visible !important;max-height:inherit !important}.h-auto{height:auto !important}}</style> </head><body neue=\"\" style=\"\\\\&quot;width:100%;font-family:roboto,'helvetica\"><div class=\"es-wrapper-color\" style=\"background-color: #FAFAFA\"> <!--[if gte mso 9]><v:background xmlns:v=\"urn:schemas-microsoft-com:vml\" fill=\"t\"><v:fill type=\"tile\" color=\"#fafafa\"></v:fill></v:background><![endif]--> <table class=\"es-wrapper\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top;background-color:#FAFAFA\"><tbody><tr><td valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-content\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0\"><table bgcolor=\"#ffffff\" class=\"es-content-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0;padding-top:15px;padding-left:20px;padding-right:20px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;padding-top:10px;padding-bottom:10px;font-size:0px\"><img src=\"https://zpxohn.stripocdn.email/content/guids/CABINET_54100624d621728c49155116bef5e07d/images/84141618400759579.png\" alt=\"\" style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\" width=\"100\"></td></tr><tr><td align=\"center\" class=\"es-m-txt-c\" style=\"padding:0;Margin:0;padding-bottom:10px\"><h1 style=\"Margin:0;line-height:40px;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;font-size:40px;font-style:normal;font-weight:bold;color:#333333\"><b>Sistema de Junta Comunal</b><br></h1></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-content\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0\"><table bgcolor=\"#ffffff\" class=\"es-content-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px\"><tbody><tr><td align=\"left\" style=\"Margin:0;padding-bottom:5px;padding-top:20px;padding-left:20px;padding-right:20px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" class=\"es-m-p0r es-m-p0l\" style=\"Margin:0;padding-top:5px;padding-bottom:15px;padding-left:40px;padding-right:40px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#0a2b6e;font-size:14px\"><span style=\"font-size:26px;font-family:'lucida sans unicode', 'lucida grande', sans-serif\"><strong>" + usuarionombre + "</strong></span><br><span style=\"color:#696969\">¡El estado de su solicitud ha cambiado!</span></p></td></tr><tr><td align=\"center\" class=\"es-m-txt-c\" style=\"padding:0;Margin:0\"><h2 style=\"Margin:0;line-height:28px;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;font-size:23px;font-style:normal;font-weight:bold;color:#333333\">Solicitud&nbsp;<a target=\"_blank\" href=\"\" style=\"-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:underline;color:#5C68E2;font-size:23px\">#" + Request.QueryString["idTramite"] + "</a></h2></td></tr><tr><td align=\"center\" class=\"es-m-p0r es-m-p0l\" style=\"Margin:0;padding-top:5px;padding-bottom:5px;padding-left:40px;padding-right:40px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px\">" + theDate.ToString("MMMM dd, yyyy H:mm:ss") + "</p></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td class=\"esdev-adapt-off\" align=\"left\" style=\"Margin:0;padding-top:10px;padding-bottom:10px;padding-left:20px;padding-right:20px\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"esdev-mso-table\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:560px\"><tbody><tr><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;width:70px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px\"><strong>Estado :</strong></p></td></tr></tbody></table></td></tr></tbody></table></td><td style=\"padding:0;Margin:0;width:20px\"></td><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;width:265px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;display:none\"></td></tr></tbody></table></td></tr></tbody></table></td><td style=\"padding:0;Margin:0;width:20px\"></td><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0;width:80px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;display:none\"></td></tr></tbody></table></td></tr></tbody></table></td><td style=\"padding:0;Margin:0;width:20px\"></td><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-right\" align=\"right\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:right\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0;width:85px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"right\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px\">" + caso + "</p></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td class=\"esdev-adapt-off\" align=\"left\" style=\"Margin:0;padding-top:10px;padding-bottom:10px;padding-left:20px;padding-right:20px\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"esdev-mso-table\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:560px\"><tbody><tr><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;width:70px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px\"><strong>Motivo:</strong></p></td></tr></tbody></table></td></tr></tbody></table></td><td style=\"padding:0;Margin:0;width:20px\"></td><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;width:265px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;display:none\"></td></tr></tbody></table></td></tr></tbody></table></td><td style=\"padding:0;Margin:0;width:20px\"></td><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0;width:80px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;display:none\"></td></tr></tbody></table></td></tr></tbody></table></td><td style=\"padding:0;Margin:0;width:20px\"></td><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-right\" align=\"right\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:right\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0;width:85px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"right\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px\">" + aprobComentario.Text + "</p></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td align=\"left\" style=\"Margin:0;padding-bottom:10px;padding-top:15px;padding-left:20px;padding-right:20px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0;width:560px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;padding-top:10px;padding-bottom:10px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px\">¿Tienes alguna pregunta? Llámenos al +(507) 229-1166, Ext. 1166.</p></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td align=\"left\" bgcolor=\"#0a2b6e\" style=\"Margin:0;padding-bottom:15px;padding-top:20px;padding-left:20px;padding-right:20px;background-color:#0a2b6e\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" bgcolor=\"#0a2b6e\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#ffffff;font-size:14px\">Usted está recibiendo este correo electrónico porque su tramite cambio de estado. Asegúrese de que nuestros mensajes lleguen a su bandeja de entrada (y no a sus carpetas masivas o de correo no deseado).</p></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></div></body></html>";


                correo.Main(email, asunto, "Notificacion de Tramite");

                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                aprobmessage.Text = "Necesita incluir un comentario para el rechazo o aprobacion de una solicitud.";
            }

        }



        //Adjuntos 

        public void mostrarAdjunto(string adjuntoUser, string adjuntoJC)
        {

            if (adjuntoUser != "")
            {
                evadjunto.Visible = true;
            }
            if (adjuntoJC != "")
            {
                evadjuntoJC.Visible = true;
            }
        }        
        public void verificaRealizacion( string adjuntoJC)
        {
            if (adjuntoJC != "" && Request.QueryString["op"] =="U")
            {
                panelCambioEstado.Visible = false;
                panelEvidenciaJC.Visible = false;
                actualizar.Visible= false;
                terminar.Visible = true;
                
            }
        }

        protected void evadjunto_Click(object sender, EventArgs e)
        {
            cSolicitudes solicitud = new cSolicitudes();
            DataSet data = solicitud.getTramite(Convert.ToInt64(Request.QueryString["idTramite"]));
            string adjunto = data.Tables[0].Rows[0]["adjuntoUser"].ToString();
            Response.Write("<script>window.open('../../Document/adj_SerCom/" + adjunto + "','_blank');</script>");
        }

        protected void evadjuntoJC_Click(object sender, EventArgs e)
        {
            cSolicitudes solicitud = new cSolicitudes();
            DataSet data = solicitud.getTramite(Convert.ToInt64(Request.QueryString["idTramite"]));
            string adjunto = data.Tables[0].Rows[0]["adjuntoJC"].ToString();
            Response.Write("<script>window.open('../../Document/ev_SerCom/" + adjunto + "','_blank');</script>");

        }

        protected void btnJCEvidencia_Click(object sender, EventArgs e)
        {
            cSolicitudes solicitud = new cSolicitudes();
            string extension = System.IO.Path.GetExtension(JCEvidencia.FileName);


            if (!JCEvidencia.HasFile)
            {
                evidenciaJCBerror.Text = "<b class=\"text-danger \">No ha ingresado ningun documento.</b>";
            }
            else if (!(extension == ".jpeg" || extension == ".jpg" || extension == ".png" || extension == ".pdf"))
            {
                evidenciaJCBerror.Text = "<b class=\"text-danger \">El documento que esta tratando de adjuntar no cumple con los tipo de extenciones que aceptamos.</b>";
            }
            else if (!(JCEvidencia.PostedFile.ContentLength < 25000000))
            {
                evidenciaJCBerror.Text = "<b class=\"text-danger \">El tamaño de la foto o archivo que quiere adjuntar supera el limite permitido.</b>";
            }
            else
            {
                Random rdn = new Random();
                int longitud = 100;
                string adjunto = "--";
                adjunto = "SERVCOM_EVDJC" + rdn.Next(longitud) + rdn.Next(longitud) + "--" + JCEvidencia.FileName;

                JCEvidencia.SaveAs(Server.MapPath("~/Document/ev_SerCom/" + adjunto));

                solicitud.setAdjJc(Convert.ToInt64(Request.QueryString["idTramite"]), adjunto);

                solicitud.sethistSoli(Convert.ToInt64(Request.QueryString["idTramite"]), Session["ColaboradorName"].ToString() + " ha adjuntado la evidencia de finalizacion para el tramite #" + Request.QueryString["idTramite"]);
               
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }

        }

        
    }
}