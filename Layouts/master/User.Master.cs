using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sjc.Layouts.master
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Label LogUser
        {
            get
            {
                return this.logUser;
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {

            _SystemLogs bitacora = new _SystemLogs();
            bitacora.AccessLogs(new _Session().getIdCiudadano(), new _Session().getNombreCompletoCiudadano(), "Residente", "Logout");

            Session.Clear();
            Response.Redirect("~/App/Public/Login.aspx");
        }
    }
}