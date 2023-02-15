using System;
using System.Web.UI;
using System.Data;
using sjc.Layouts.master;

namespace sjc.App.Private
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                VerifySessions();
                ((User)Master).LogUser.Text = new _Session().getNombreCompletoCiudadano();
                GetInfUSerComplet(new _Session().getIdCiudadano());
            }
        }

        protected void VerifySessions()
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/App/Public/Login.aspx");
            }
        }

        private void GetInfUSerComplet(long IdU)
        {
            cUsuario usuario = new cUsuario();
            DataSet data = usuario.getUnUsuario(IdU);
            this.profileName1.Text = data.Tables[0].Rows[0]["user_name"].ToString() + " " + data.Tables[0].Rows[0]["user_sname"].ToString() + " " + data.Tables[0].Rows[0]["user_lastname"].ToString() + " " + data.Tables[0].Rows[0]["user_slastname"].ToString();
            this.ProfileName2.Text = data.Tables[0].Rows[0]["user_name"].ToString() + " " + data.Tables[0].Rows[0]["user_sname"].ToString() + " " + data.Tables[0].Rows[0]["user_lastname"].ToString() + " " + data.Tables[0].Rows[0]["user_slastname"].ToString();
            this.profileTypeDoc.Text = data.Tables[0].Rows[0]["user_typeDocmuent"].ToString();
            this.profileIndentNumber.Text = data.Tables[0].Rows[0]["user_numeroIdent"].ToString();
            this.profileEmail.Text = data.Tables[0].Rows[0]["user_email"].ToString();
            this.profileBirth.Text = data.Tables[0].Rows[0]["date"].ToString();
            this.profileCel.Text = data.Tables[0].Rows[0]["user_celular"].ToString();
            this.profileDirect.Text = data.Tables[0].Rows[0]["user_diretion"].ToString();

        }

    }
}