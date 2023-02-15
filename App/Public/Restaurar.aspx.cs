using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;

namespace sjc.App.Public
{
    public partial class Restaurar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void recoverySubmit_Click(object sender, EventArgs e)
        {
            if (this.recoveryEmail.Text.Length == 0 | IsReCaptchaValid() == false)
            {
                this.recoveryEmail.Text = "";
                this.recoveryMessage.Text = "<p class=\" text-danger \">Verifique que la casilla de <b>Correo Electronico</b>  este llenada o el <b>captcha</b> verificado</p>";

            }
            if (!(this.recoveryEmail.Text.Length == 0 && IsReCaptchaValid() == false))
            {
                DataSet dataSet = new DataSet();

                dataSet = new cUsuario().getIdPorCorreo(this.recoveryEmail.Text);


                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    this.recoveryMessage.Text = "<p class=\" text-danger \">El correo electronico que usted ingreso no coincide con algun usuario en nuestra base de datos.</p>";
                    return;
                }
                    
                var getnom = new cUsuario().getNombreCompleto(Convert.ToInt64(dataSet.Tables[0].Rows[0]["user_id"].ToString()));
                string nombre = getnom.Tables[0].Rows[0]["user_name"].ToString();

                new cCorreo()._RecoveryMail(recoveryEmail.Text, nombre);

                this.recoveryEmail.Text = "";
                this.recoveryMessage.Text = "<p class=\" text-success fw-bolder\">Revise su correo para realizar el cambio de contrasena</p>";
                
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