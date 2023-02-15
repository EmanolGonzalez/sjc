using sjc.Layouts.master;
using System;
using System.Web.UI.WebControls;

namespace sjc.App.Private
{
    public partial class gestorTramites : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            VerifySessions();

            if (!IsPostBack)
            {
                traerColab();
                CargarTablas();
            }
        }
        protected void VerifySessions()
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/App/Private/AdminLog.aspx");
            }
        }

        public void traerColab()
        {

            ((Admin)Master).colabLoglabel.Text = new _Session().getNombreCompletoColaborador();

        }
        void CargarTablas()
        {
            _GestorTramites solicitud = new _GestorTramites();

            int dep = new _Session().getDepartamentoColaborador();

            if (dep == 2 || dep == 3 || dep == 7)
            {
                if (solicitud.getAllSolicitudesNuevas().Tables[0].Rows.Count == 0)
                {
                    this.gridnuevovacio.Text = "<div class=\"text-center\">No hay solicitudes</div>";
                }
                if (solicitud.getAllSolicitudesEnProgreso().Tables[0].Rows.Count == 0)
                {
                    this.gridprocesovacio.Text = "<div class=\"text-center\">No hay solicitudes</div>";
                }
                if (solicitud.getAllSolicitudesHistorial().Tables[0].Rows.Count == 0)
                {
                    this.gridfinalizadosvacio.Text = "<div class=\"text-center\">No hay solicitudes</div>";
                }

                    panelNuevoTramite.DataSource = solicitud.getAllSolicitudesNuevas();
                    panelNuevoTramite.DataBind();
                if (panelNuevoTramite.Rows.Count > 0)
                {
                    panelNuevoTramite.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                
                    panelEnProceso.DataSource = solicitud.getAllSolicitudesEnProgreso();
                    panelEnProceso.DataBind();
                if (panelEnProceso.Rows.Count > 0)
                {
                    panelEnProceso.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                
                    paneHistorial.DataSource = solicitud.getAllSolicitudesHistorial();
                    paneHistorial.DataBind();
                if (paneHistorial.Rows.Count > 0)
                {
                    paneHistorial.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

            }
            else if (dep == 7)
            {

                if (solicitud.getOASolicitudesNuevas().Tables[0].Rows.Count == 0)
                {
                    this.gridnuevovacio.Text = "<div class=\"text-center\">No hay solicitudes</div>";
                }
                if (solicitud.getOASolicitudesEnProceso().Tables[0].Rows.Count == 0)
                { 
                    this.gridprocesovacio.Text = "<div class=\"text-center\">No hay solicitudes</div>";
                }
                if (solicitud.getOASolicitudesHistorial().Tables[0].Rows.Count == 0)
                {
                    this.gridfinalizadosvacio.Text = "<div class=\"text-center\">No hay solicitudes</div>";
                }
 
                    panelNuevoTramite.DataSource = solicitud.getOASolicitudesNuevas();
                    panelNuevoTramite.DataBind();
                if (panelNuevoTramite.Rows.Count > 0)
                {
                    panelNuevoTramite.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                    
                    panelEnProceso.DataSource = solicitud.getOASolicitudesEnProceso();
                    panelEnProceso.DataBind();
                if (panelEnProceso.Rows.Count > 0)
                {
                    panelEnProceso.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                    paneHistorial.DataSource = solicitud.getOASolicitudesHistorial();
                    paneHistorial.DataBind();
                if (paneHistorial.Rows.Count > 0)
                {
                    paneHistorial.HeaderRow.TableSection = TableRowSection.TableHeader;
                }


            }

        }
        protected string getRol()
        {
            return new _InfJuntaComunal().ColaboradorRol(new _Session().getRolColaborador() - 1); 
        }

        //BOTONES

        protected void BtnLeer_Click(object sender, EventArgs e)
        {
            string id;
            LinkButton BtnConsultar = (LinkButton)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;

            Response.Redirect("~/App/Private/Tramite.aspx?idTramite=" + id + "&op=R");
        }

        protected void BtnTomar_Click(object sender, EventArgs e)
        {

            string id;
            LinkButton BtnConsultar = (LinkButton)sender;
            BtnConsultar.Enabled = false;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;


            // buscar solicitud y cambiar de entregado a iniciado
            cSolicitudes solicitud = new cSolicitudes();
            solicitud.StatusStartSoli(Convert.ToInt64(id));

            //correo para notificar que la solicitud ha sido toma
            string email = solicitud.getTramite(Convert.ToInt64(id)).Tables[0].Rows[0]["email"].ToString();
            string usuarionombre = solicitud.getTramite(Convert.ToInt64(id)).Tables[0].Rows[0]["nombre"].ToString();

            cCorreo correo = new cCorreo();
            DateTime theDate = DateTime.Now;
            string asunto = "<html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\"><head><meta charset=\"UTF-8\"> <meta content=\"\\\\&quot;width=device-width,initial-scale=1\\\\&quot;name=viewport\"> <meta name=\"x-apple-disable-message-reformatting\"> <meta content=\"\\\\&quot;IE=edge\\\\&quot;http-equiv=X-UA-Compatible\"> <meta content=\"\\\\&quot;telephone=no\\\\&quot;name=format-detection\"> <title>New email template 2022-10-08</title><!--[if (mso 16)]><style>a{text-decoration:none}</style><![endif]--><!--[if gte mso 9]><style>sup{font-size:100%!important}</style><![endif]--><!--[if gte mso 9]><xml><o:officedocumentsettings><o:allowpng></o:allowpng><o:pixelsperinch>96</o:pixelsperinch></o:officedocumentsettings></xml><![endif]--><!--[if !mso]><!----> <link href=\"\\\\&quot;https://fonts.googleapis.com/css?family=Roboto:400,400i,700,700i\\\\&quot;rel=stylesheet\"><!--<![endif]--> <style>.rollover:hover .rollover-first{max-height:0 !important;display:none !important}.rollover:hover .rollover-second{max-height:none !important;display:block !important}#outlook a{padding:0}.es-button{mso-style-priority:100 !important;text-decoration:none !important}a[x-apple-data-detectors]{color:inherit !important;text-decoration:none !important;font-size:inherit !important;font-family:inherit !important;font-weight:inherit !important;line-height:inherit !important}.es-desk-hidden{display:none;float:left;overflow:hidden;width:0;max-height:0;line-height:0;mso-hide:all}.es-button-border:hover{border-style:solid !important;background:#0b317e !important;border-color:#42d159 !important}.es-button-border:hover a.es-button,.es-button-border:hover button.es-button{background:#0b317e !important;border-color:#0b317e !important}[data-ogsb] .es-button{border-width:0 !important;padding:10px 20px !important}@media only screen and (max-width:600px){a,ol li,p,ul li{line-height:150% !important}h1,h1 a,h2,h2 a,h3,h3 a{line-height:120% !important}h1{font-size:30px !important;text-align:center}h2{font-size:26px !important;text-align:center}h3{font-size:20px !important;text-align:center}.st-br{padding-left:10px !important;padding-right:10px !important}h1 a{text-align:center}.es-content-body h1 a,.es-footer-body h1 a,.es-header-body h1 a{font-size:30px !important}h2 a{text-align:center}.es-content-body h2 a,.es-footer-body h2 a,.es-header-body h2 a{font-size:26px !important}h3 a{text-align:center}.es-content-body h3 a,.es-footer-body h3 a,.es-header-body h3 a{font-size:20px !important}.es-menu td a{font-size:14px !important}.es-header-body a,.es-header-body ol li,.es-header-body p,.es-header-body ul li{font-size:16px !important}.es-content-body a,.es-content-body ol li,.es-content-body p,.es-content-body ul li{font-size:16px !important}.es-footer-body a,.es-footer-body ol li,.es-footer-body p,.es-footer-body ul li{font-size:14px !important}.es-infoblock a,.es-infoblock ol li,.es-infoblock p,.es-infoblock ul li{font-size:12px !important}[class=gmail-fix]{display:none !important}.es-m-txt-c,.es-m-txt-c h1,.es-m-txt-c h2,.es-m-txt-c h3{text-align:center !important}.es-m-txt-r,.es-m-txt-r h1,.es-m-txt-r h2,.es-m-txt-r h3{text-align:right !important}.es-m-txt-l,.es-m-txt-l h1,.es-m-txt-l h2,.es-m-txt-l h3{text-align:left !important}.es-m-txt-c img,.es-m-txt-l img,.es-m-txt-r img{display:inline !important}.es-button-border{display:block !important}a.es-button,button.es-button{font-size:16px !important;display:block !important;border-left-width:0 !important;border-right-width:0 !important}.es-adaptive table,.es-left,.es-right{width:100% !important}.es-content,.es-content table,.es-footer,.es-footer table,.es-header,.es-header table{width:100% !important;max-width:600px !important}.es-adapt-td{display:block !important;width:100% !important}.adapt-img{width:100% !important;height:auto !important}.es-m-p0{padding:0 !important}.es-m-p0r{padding-right:0 !important}.es-m-p0l{padding-left:0 !important}.es-m-p0t{padding-top:0 !important}.es-m-p0b{padding-bottom:0 !important}.es-m-p20b{padding-bottom:20px !important}.es-hidden,.es-mobile-hidden{display:none !important}table.es-desk-hidden,td.es-desk-hidden,tr.es-desk-hidden{width:auto !important;overflow:visible !important;float:none !important;max-height:inherit !important;line-height:inherit !important}tr.es-desk-hidden{display:table-row !important}table.es-desk-hidden{display:table !important}td.es-desk-menu-hidden{display:table-cell !important}.esd-block-html table,table.es-table-not-adapt{width:auto !important}table.es-social{display:inline-block !important}table.es-social td{display:inline-block !important}.es-m-p5{padding:5px !important}.es-m-p5t{padding-top:5px !important}.es-m-p5b{padding-bottom:5px !important}.es-m-p5r{padding-right:5px !important}.es-m-p5l{padding-left:5px !important}.es-m-p10{padding:10px !important}.es-m-p10t{padding-top:10px !important}.es-m-p10b{padding-bottom:10px !important}.es-m-p10r{padding-right:10px !important}.es-m-p10l{padding-left:10px !important}.es-m-p15{padding:15px !important}.es-m-p15t{padding-top:15px !important}.es-m-p15b{padding-bottom:15px !important}.es-m-p15r{padding-right:15px !important}.es-m-p15l{padding-left:15px !important}.es-m-p20{padding:20px !important}.es-m-p20t{padding-top:20px !important}.es-m-p20r{padding-right:20px !important}.es-m-p20l{padding-left:20px !important}.es-m-p25{padding:25px !important}.es-m-p25t{padding-top:25px !important}.es-m-p25b{padding-bottom:25px !important}.es-m-p25r{padding-right:25px !important}.es-m-p25l{padding-left:25px !important}.es-m-p30{padding:30px !important}.es-m-p30t{padding-top:30px !important}.es-m-p30b{padding-bottom:30px !important}.es-m-p30r{padding-right:30px !important}.es-m-p30l{padding-left:30px !important}.es-m-p35{padding:35px !important}.es-m-p35t{padding-top:35px !important}.es-m-p35b{padding-bottom:35px !important}.es-m-p35r{padding-right:35px !important}.es-m-p35l{padding-left:35px !important}.es-m-p40{padding:40px !important}.es-m-p40t{padding-top:40px !important}.es-m-p40b{padding-bottom:40px !important}.es-m-p40r{padding-right:40px !important}.es-m-p40l{padding-left:40px !important}.es-desk-hidden{display:table-row !important;width:auto !important;overflow:visible !important;max-height:inherit !important}.h-auto{height:auto !important}}</style> </head><body neue=\"\" style=\"width:100%;font-family:roboto,'helvetica\"><table class=\"es-wrapper\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top;background-color:#FAFAFA\"><tbody><tr><td valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-content\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0\"><table bgcolor=\"#ffffff\" class=\"es-content-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0;padding-top:15px;padding-left:20px;padding-right:20px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;padding-top:10px;padding-bottom:10px;font-size:0px\"><img src=\"https://zpxohn.stripocdn.email/content/guids/CABINET_54100624d621728c49155116bef5e07d/images/84141618400759579.png\" alt=\"\" style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\" width=\"100\"></td></tr><tr><td align=\"center\" class=\"es-m-txt-c\" style=\"padding:0;Margin:0;padding-bottom:10px\"><h1 style=\"Margin:0;line-height:40px;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;font-size:40px;font-style:normal;font-weight:bold;color:#333333\"><b>Sistema de Junta Comunal</b><br></h1></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-content\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0\"><table bgcolor=\"#ffffff\" class=\"es-content-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px\"><tbody><tr><td align=\"left\" style=\"Margin:0;padding-bottom:5px;padding-top:20px;padding-left:20px;padding-right:20px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" class=\"es-m-p0r es-m-p0l\" style=\"Margin:0;padding-top:5px;padding-bottom:15px;padding-left:40px;padding-right:40px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#0a2b6e;font-size:14px\"><span style=\"font-size:26px;font-family:'lucida sans unicode', 'lucida grande', sans-serif\"><strong>"+usuarionombre+"</strong></span><br><span style=\"color:#696969\">¡El estado de su solicitud ha cambiado!</span></p></td></tr><tr><td align=\"center\" class=\"es-m-txt-c\" style=\"padding:0;Margin:0\"><h2 style=\"Margin:0;line-height:28px;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;font-size:23px;font-style:normal;font-weight:bold;color:#333333\">Solicitud&nbsp;<a target=\"_blank\" href=\"\" style=\"-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:underline;color:#5C68E2;font-size:23px\">#"+id+ "</a></h2></td></tr><tr><td align=\"center\" class=\"es-m-p0r es-m-p0l\" style=\"Margin:0;padding-top:5px;padding-bottom:5px;padding-left:40px;padding-right:40px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px\">" + theDate.ToString("MMMM dd, yyyy H:mm:ss") + "</p></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td class=\"esdev-adapt-off\" align=\"left\" style=\"Margin:0;padding-top:10px;padding-bottom:10px;padding-left:20px;padding-right:20px\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"esdev-mso-table\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:560px\"><tbody><tr><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;width:70px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px\"><strong>Nuevo Estado:</strong></p></td></tr></tbody></table></td></tr></tbody></table></td><td style=\"padding:0;Margin:0;width:20px\"></td><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;width:265px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;display:none\"></td></tr></tbody></table></td></tr></tbody></table></td><td style=\"padding:0;Margin:0;width:20px\"></td><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0;width:80px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;display:none\"></td></tr></tbody></table></td></tr></tbody></table></td><td style=\"padding:0;Margin:0;width:20px\"></td><td class=\"esdev-mso-td\" valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-right\" align=\"right\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:right\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0;width:85px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"right\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px\">Iniciado</p></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td align=\"left\" style=\"Margin:0;padding-bottom:10px;padding-top:15px;padding-left:20px;padding-right:20px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"left\" style=\"padding:0;Margin:0;width:560px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" style=\"padding:0;Margin:0;padding-top:10px;padding-bottom:10px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;font-size:14px\">¿Tienes alguna pregunta? Llámenos al +(507) 229-1166, Ext. 1166.</p></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td align=\"left\" bgcolor=\"#0a2b6e\" style=\"Margin:0;padding-bottom:15px;padding-top:20px;padding-left:20px;padding-right:20px;background-color:#0a2b6e\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tbody><tr><td align=\"center\" bgcolor=\"#0a2b6e\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#ffffff;font-size:14px\">Usted está recibiendo este correo electrónico porque su tramite cambio de estado. Asegúrese de que nuestros mensajes lleguen a su bandeja de entrada (y no a sus carpetas masivas o de correo no deseado).</p></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></body></html>";
            correo.Main(email, asunto, "Notificacion de Tramite");

            // redirigir a la sala de tramites
            Response.Redirect("~/App/Private/Tramite.aspx?idTramite=" + id + "&op=U");
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            string id;
            LinkButton BtnConsultar = (LinkButton)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;

            Response.Redirect("~/App/Private/Tramite.aspx?idTramite=" + id + "&op=U");
        }

        
        //BOTON PARA ADMINISTRADORES

        public Boolean BtnVisibility(string StatusNo, string ButtonName)
        { // 0 means not active, 1 means activated

            if (ButtonName == "Btn1" || ButtonName == "Btn2")
            {
                if (StatusNo == "Administrador" || StatusNo == "Evaluador")
                {//not active
                    return true;
                }
                else if (StatusNo == "Revisor") //active
                {
                    return false;
                }
            }
            return true;
        }

    }

}