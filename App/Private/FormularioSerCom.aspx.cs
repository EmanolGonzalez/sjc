using sjc.Layouts.master;
using System;
using System.Data;
using System.Web.UI;


namespace sjc.App.Private
{
    public partial class FormularioSerCom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                VerifySessions();
                ((User)Master).LogUser.Text = new _Session().getNombreCompletoCiudadano();
                GetInformacionSolicitante(new _Session().getIdCiudadano());
            }

        }
        protected void VerifySessions()
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/App/Public/Login.aspx");
            }
        }

        private void GetInformacionSolicitante(long IdU)

        {
            cUsuario usuario = new cUsuario();
            DataSet data = usuario.getUnUsuario(IdU);
            this.formNumIdent.Text = data.Tables[0].Rows[0]["user_numeroIdent"].ToString();
            this.formNameComplet.Text = data.Tables[0].Rows[0]["user_name"].ToString() + " " + data.Tables[0].Rows[0]["user_sname"].ToString() + " " + data.Tables[0].Rows[0]["user_lastname"].ToString() + " " + data.Tables[0].Rows[0]["user_slastname"].ToString();
            this.formEmail.Text = data.Tables[0].Rows[0]["user_email"].ToString();
            this.formCel.Text = data.Tables[0].Rows[0]["user_celular"].ToString();

        }

        protected void EnviarSolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                //VALIDA QUE TODOS LOS CAMPOS ESTAN LLENADOS
                if(!(this.formSectores.SelectedItem.Text != "Selecione un Sector" & formDireIncident.Text != "" & FormTipoServ.SelectedValue != "Seleccione Una Solicitud" & formPorqueSol.Text != "" & formCheck.Checked != false))
                {
                    this.formCheck.Checked = false;
                    this.error.Text = "<div class=\"text-danger text-center\">Verifique que todo los campos con * esten rellenados o el check con el ganchito ---> Baje Para revisar</div>";
                    return;
                }

                string adjunto = null;
                //VALIDAR GUARDAR EVIDENCIA   
                if (this.formServComUploadPicture.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(formServComUploadPicture.FileName);

                    adjunto = "SERVCOM" + new Random().Next(100) + new Random().Next(100) + "--" + this.formServComUploadPicture.FileName;

                    if (!(extension == ".jpeg" || extension == ".jpg" || extension == ".png" || extension == ".pdf"))
                    {
                        adjuntomessage.Text = "<b class=\"text-danger \">El documento que esta tratando de adjuntar no cumple con los tipo de extenciones que aceptamos.</b>";return;
                    }

                    if (!(formServComUploadPicture.PostedFile.ContentLength < 25000000))
                    {
                        adjuntomessage.Text = "<b class=\"text-danger \">El tamaño de la foto o archivo que quiere adjuntar supera el limite permitido.</b>";return;
                    }

                    formServComUploadPicture.SaveAs(Server.MapPath("~/Document/adj_SerCom/" + adjunto)); 
                }

                //REGISTRAR TRAMITE DE SERVICIO COMUNITARIO
                new _FormServicioComunitario().setServicioComunitario(
                    new _Session().getIdCiudadano(),
                    formEmail.Text,
                    formNameComplet.Text,
                    formSectores.SelectedValue,
                    formSectores.SelectedItem.Text,
                    formDireIncident.Text,
                    formPorqueSol.Text,
                    FormTipoServ.SelectedValue,
                    FormTipoServ.SelectedItem.Text,
                    adjunto);

                Response.Redirect("~/App/Private/solicitudComplete.aspx");
                Context.ApplicationInstance.CompleteRequest();

            }
            catch (Exception ex)
            {
                this.formCheck.Checked = false;
                this.error.Text = ex.Message;
            }
        }
    }
}