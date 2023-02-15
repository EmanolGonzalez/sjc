using sjc.Layouts.master;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sjc.App.Private
{
    public partial class gtrUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifySessions();

            if (!Page.IsPostBack)
            {
                traerColab();
                traerInfo();   
            }

            if (!(gridColab.Rows.Count == 0))
            {
                gridColab.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        public void traerInfo()
        {

            ncolaboradores.InnerText = new _GestorColaboradores().getNumeroDeColaboradores().ToString();
            //nresidentes.InnerText = adm.getNumeroDeResidentes().ToString();
            llenarListas();
            llenarColaboradores();
            //llenarUsuarios();
        }
        public void llenarListas()
        {
            newColabRol.DataSource = new _GestorColaboradores().getRoles();
            newColabDepart.DataSource = new _GestorColaboradores().getDepartamentos();
            newColabCargo.DataSource = new _GestorColaboradores().getCargos();
            newColabRol.DataBind();
            newColabDepart.DataBind();
            newColabCargo.DataBind();
        }

        public void llenarColaboradores()
        {
            if (!(new _GestorColaboradores().getTodosColaboradores().Tables[0].Rows.Count == 0))
            {
                gridColab.DataSource = new _GestorColaboradores().getTodosColaboradores();

                gridColab.DataBind();
                gridColab.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }


        //public void llenarUsuarios()
        //{
        //    cAdministrativos adm = new cAdministrativos();
        //    gridResidents.DataSource = adm.getTodosUsuarios();
        //    gridResidents.DataBind();


        //}


        //protected void btnCancelarAddUpd_Click(object sender, EventArgs e)
        //{
        //    vaciaCampos();
        //    Page.Response.Redirect(Page.Request.Url.ToString(), true);
        //}


        //Agregar Colaborador

        protected void addColaborador_Click(object sender, EventArgs e)
        {
                btnAddNewColaborador.Visible=true;
                btnActaualizarColaborador.Visible = false;
                colabContrasenaGen.Enabled = false;
                colabContrasenaGen.Text = contrasenaAleatoria();
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "mostrarModal(\"addColaboradorModal\");", true);  
        }

        protected void btnActaualizarColaborador_Click(object sender, EventArgs e)
        {
            try
            {
                addColaboradorMessage.Text = "";

                if (!(newColabDocu.SelectedItem.Text != "Seleccione Documento" && newColabNumero.Text != ""
                    && newColabNombre.Text != "" && newColabApellido.Text != ""
                    && newColabTelefono.Text != "" && newColabCargo.SelectedItem.Text != "Seleccione Cargo"
                    && newColabCorreo.Text != "" && newColabRol.SelectedItem.Text != "Seleccione Rol"
                    && newColabDepart.SelectedItem.Text != "Seleccione Departamento"))
                {
                    if (newColabDocu.SelectedItem.Text == "Seleccione Documento" || newColabNumero.Text == ""
                        || newColabNombre.Text == "" || newColabApellido.Text == ""
                        || newColabTelefono.Text == "" || newColabCargo.SelectedItem.Text == "Seleccione Cargo"
                        || newColabCorreo.Text == "" || newColabRol.SelectedItem.Text == "Seleccione Rol"
                        || newColabDepart.SelectedItem.Text == "Seleccione Departamento")
                    {
                        addColaboradorMessage.Text = "Algun campo no esta llenado correctamente";
                        ClientScript.RegisterStartupScript(GetType(), "mostrar", "mostrarModal(\"addColaboradorModal\");", true);
                        return;
                    }
                }

                new _GestorColaboradores().updateColaborador(
                    Convert.ToInt32(newColabId.Text),
                    newColabDocu.Text,
                    newColabNumero.Text,
                    newColabNombre.Text,
                    newColabApellido.Text,
                    newColabTelefono.Text,
                    newColabCorreo.Text,
                    colabContrasenaGen.Text,
                    Convert.ToInt32(newColabCargo.SelectedValue),
                    Convert.ToInt32(newColabRol.SelectedValue),
                    Convert.ToInt32(newColabDepart.SelectedValue));

                vaciaCampos();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            catch (Exception ex)
            {
                addColaboradorMessage.Text = ex.Message;
            }
        }

        protected void btnAddNewColaborador_Click(object sender, EventArgs e)
        {

            try
            {
                addColaboradorMessage.Text = "";
                newColabId.Text = "";

                if (!(newColabDocu.SelectedItem.Text != "Seleccione Documento" && newColabNumero.Text != "" 
                    && newColabNombre.Text != "" && newColabApellido.Text != "" 
                    && newColabTelefono.Text != "" && newColabCargo.SelectedItem.Text != "Seleccione Cargo" 
                    && newColabCorreo.Text != "" && newColabRol.SelectedItem.Text != "Seleccione Rol" 
                    && newColabDepart.SelectedItem.Text != "Seleccione Departamento"))
                {
                    if (newColabDocu.SelectedItem.Text == "Seleccione Documento" || newColabNumero.Text == "" 
                        || newColabNombre.Text == "" || newColabApellido.Text == "" 
                        || newColabTelefono.Text == "" || newColabCargo.SelectedItem.Text == "Seleccione Cargo"
                        || newColabCorreo.Text == "" || newColabRol.SelectedItem.Text == "Seleccione Rol" 
                        || newColabDepart.SelectedItem.Text == "Seleccione Departamento")
                    {
                        addColaboradorMessage.Text = "<p class=\"text-danger\">Algun campo no esta llenado correctamente.</p>";
                        ClientScript.RegisterStartupScript(GetType(), "mostrar", "mostrarModal(\"addColaboradorModal\");", true);
                        return;
                    }
                }                


                new _GestorColaboradores().setNuevoColaborador(
                    newColabDocu.Text,
                    newColabNumero.Text,
                    newColabNombre.Text,
                    newColabApellido.Text,
                    newColabTelefono.Text,
                    newColabCorreo.Text,
                    colabContrasenaGen.Text,
                    Convert.ToInt32(newColabCargo.SelectedValue),
                    Convert.ToInt32(newColabRol.SelectedValue),
                    Convert.ToInt32(newColabDepart.SelectedValue));
                
                vaciaCampos();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            catch (Exception ex)
            {
                addColaboradorMessage.Text = ex.Message;
            }
        }
        protected void btnCancelarAddUpd_Click(object sender, EventArgs e)
        {
            vaciaCampos();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void editColaborador_Click(object sender, EventArgs e)
        {
            btnActaualizarColaborador.Visible = true;
            btnAddNewColaborador.Visible = false;
            colabContrasenaGen.Enabled = true;
            LinkButton BtnConsultar = (LinkButton)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;

            DataSet data = new DataSet();
            data = new _GestorColaboradores().getInfoColaborador(Convert.ToInt32(selectedrow.Cells[0].Text));
            newColabId.Text = selectedrow.Cells[0].Text;
            newColabDocu.SelectedValue = data.Tables[0].Rows[0]["doc"].ToString();
            newColabNumero.Text = data.Tables[0].Rows[0]["ndoc"].ToString();
            newColabNombre.Text = data.Tables[0].Rows[0]["nombre"].ToString();
            newColabApellido.Text = data.Tables[0].Rows[0]["apellido"].ToString();
            newColabTelefono.Text = data.Tables[0].Rows[0]["telefono"].ToString();
            newColabCorreo.Text = data.Tables[0].Rows[0]["correo"].ToString();
            colabContrasenaGen.Text = data.Tables[0].Rows[0]["pass"].ToString();  
            newColabCargo.SelectedValue  = data.Tables[0].Rows[0]["cargo"].ToString();
            newColabRol.SelectedValue = data.Tables[0].Rows[0]["rol"].ToString();
            newColabDepart.SelectedValue = data.Tables[0].Rows[0]["dep"].ToString();

            Page.ClientScript.RegisterStartupScript(GetType(), "mostrar", "mostrarModal(\"addColaboradorModal\");", true);
        }


        protected void delColaborador_Click(object sender, EventArgs e)
        {
            LinkButton BtnEliminar = (LinkButton)sender;
            GridViewRow selectedrow = (GridViewRow)BtnEliminar.NamingContainer;

            delId.Text = selectedrow.Cells[0].Text;
            delNombre.Text = selectedrow.Cells[1].Text;
            delApellido.Text = selectedrow.Cells[2].Text;
            Page.ClientScript.RegisterStartupScript(GetType(), "mostrar", "mostrarModal(\"delConfirmacionModal\");", true);
        }
        protected void aceptarDelColaborador_Click(object sender, EventArgs e)
        {
        new _GestorColaboradores().delColaborador(Convert.ToInt32(delId.Text));
            vaciaCampos();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        
        public string contrasenaAleatoria()
        {return new cVarios().PassRandom();}

        public void vaciaCampos()
        {
            newColabId.Text = "";
            newColabDocu.SelectedItem.Text = "";
            newColabNumero.Text = "";
            newColabNombre.Text = "";
            newColabApellido.Text = "";
            newColabTelefono.Text = "";
            newColabCorreo.Text = "";
            colabContrasenaGen.Text = "";
            newColabCargo.SelectedItem.Text = "Seleccione Cargo";
            newColabRol.SelectedItem.Text = "Seleccione Rol";
            newColabDepart.SelectedItem.Text = "Seleccione Departamento";
            delId.Text = "";
        }

    }
}