using sjc.Layouts.master;
using System;


namespace sjc.App.Private
{
    public partial class ColaboradorPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifySessions();

            if (!IsPostBack)
            {
                getPanelColaborador();
            }

        }
        protected void VerifySessions()
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/App/Public/Login.aspx");
            }
        }

        public void getPanelColaborador() 
        {
            ((Admin)Master).colabLoglabel.Text = new _Session().getNombreCompletoColaborador();
            departameto.Text = getDepartamento(new _Session().getDepartamentoColaborador());
            colabCargo.Text = getCargo(new _Session().getCargoColaborador()); 

            getSolicitudesTotales();
            getAdminPaneles();
        }

        protected string getDepartamento(int IdDep)
        {
            return new _InfJuntaComunal().ColaboradorDepartamento(IdDep - 1);
        }
        protected string getCargo(int IdCargo)
        {
            return new _InfJuntaComunal().ColaboradorCargo(IdCargo - 1);
        }
        protected void getSolicitudesTotales()
        {
            cAdministrativos administrativo = new cAdministrativos();


            string dep = departameto.Text;


            if (dep == "Administración" || dep == "Línea Única de Atención" || dep == "Recepción")
            {
                this.totalNuevoTramites.Text = administrativo.getSolicitudesTotales().ToString();
                this.totalNuevoProceso.Text = administrativo.getSolicitudesProceso().ToString();
                this.totalNuevoFinalizado.Text = administrativo.getSolicitudesFinalizado().ToString();
            }
            else if (dep == "Ornato y Aseo")
            {
                this.totalNuevoTramites.Text = administrativo.getSolicitudesSCTotales().ToString();
                this.totalNuevoProceso.Text = administrativo.getSolicitudesSCProceso().ToString();
                this.totalNuevoFinalizado.Text = administrativo.getSolicitudesSCFinalizado().ToString();
            }

        }
        protected void getAdminPaneles()
        {

            if(colabCargo.Text == "Administrador")

            {
                PanelGestorUsuario.Visible = true;
            }
            else
            {
                PanelGestorUsuario.Visible = false;
            }

        }

    }
}