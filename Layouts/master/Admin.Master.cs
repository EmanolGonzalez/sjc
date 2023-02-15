using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sjc.Layouts.master
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        public Label colabLoglabel
        {
            get{
                return this.colabLog;
            }
        }


        protected void Logout_Click(object sender, EventArgs e)
        {

            _SystemLogs bitacora = new _SystemLogs();
            bitacora.AccessLogs( new _Session().getIdColaborador(), new _Session().getNombreCompletoColaborador(), "Funcionario", "Login");

            Session.Clear();
            Response.Redirect("~/App/Private/AdminLog.aspx");
        }

    }
}