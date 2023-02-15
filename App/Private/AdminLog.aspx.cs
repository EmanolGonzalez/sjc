using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.IO;
using System.Net;


namespace sjc.App.Private
{
    public partial class AdminLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                loginMessage.Text = "";

                if (loginUser.Text == string.Empty || loginPassword.Text == string.Empty)
                { loginMessage.Text = "Tiene un campo esta vacio"; return; }

                if (loginUser.Text != string.Empty && loginPassword.Text != string.Empty && IsReCaptchaValid() == false)
                { loginMessage.Text = "Recuerde completar el Captcha"; return; }

                _ObjectSession buscar = new _Session().getColaboradorSession(loginUser.Text, loginPassword.Text);

                if (!(buscar != null))
                { loginMessage.Text = "Usuario no encontrado, verifique los campos que esten con las credenciales correcta"; return; }

                _SystemLogs bitacora = new _SystemLogs();
                Session["usuario"] = buscar;
                bitacora.AccessLogs(buscar.CoId, new _Session().getNombreCompletoColaborador(), "Funcionario", "Login");
                Response.Redirect("~/App/Private/ColaboradorPrincipal.aspx");

            }
            catch (Exception ex)
            {
                this.loginMessage.Text = ex.Message;
            }
        }

        protected bool IsReCaptchaValid()
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = ConfigurationManager.AppSettings["SecretKey"];
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = String.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }
    }
}