using System;
using System.Data;
using System.Linq;


namespace sjc.App.Public
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
           
        }

        protected void regBtnVerify_Click(object sender, EventArgs e)
        {
            cVarios estiloBackend = new cVarios();
            try
            {

                regMessagge.Text = "";
                //ver si esta vacio

                if (!(regIdentiNumber.Text.Length > 0))
                {
                    regMessagge.Text = "<p class=\"text-danger\">No ha ingresado ningún número de identificación para validar.</p>";
                    return;
                }

                //ver si existe el ciudadano
                if (new _SystemRegister().ExisteCiudadanoNumeroDocumento(regIdentiNumber.Text).Tables[0].Rows.Count > 0)

                {
                    regMessagge.Text = "<p class=\"text-danger\">Este usuario ya tiene un registro.</p>";
                    VaciarFormulario();
                    btnIdenti.Disabled = true;
                    return;
                }

                //si eligio pasaporte

                if (regDocumentType.Text == "Pasaporte")
                {
                    estiloBackend.AddCssClassWeb(regDataviewHead, "js-active");
                    estiloBackend.AddCssClassWeb(regValidaterviewHead, "js-active");
                    estiloBackend.AddCssClassGeneric(regDataViu, "js-active");
                    regBtnVerify.Style.Add("display", "none");
                    btnIdenti.Disabled = false;
                    return;
                }

                //si eligio cedula
                if (regDocumentType.Text == "Cédula")
                {
                    CedulaValid();
                    return;
                }  

            }
            catch (Exception ex)
            {
                regMessagge.Text = ex.Message;

            }  
        }

        protected void verificarPersona_Click(object sender, EventArgs e)
        {
            cVarios estiloBackend = new cVarios();
            try
            {

                //verificar que sean las respuestas correctas
                regMessagge.Text = "";
                estiloBackend.AddCssClassWeb(regValidaterviewHead, "js-active");
                estiloBackend.AddCssClassGeneric(regValidateViu, "js-active");
                if (!(RadioButtonListFechas.SelectedItem.Value == new _Session().getRespuestas().Pregunta1 &&
                    RadioButtonListApellidoPadre.SelectedItem.Value == new _Session().getRespuestas().Pregunta2 &&
                    RadioButtonListProvinciaCentro.SelectedItem.Value == new _Session().getRespuestas().Pregunta3 &&
                    RadioButtonListApellidoMadre.SelectedItem.Value == new _Session().getRespuestas().Pregunta4))
                {
                    regMessagge.Text = "<p class=\"text-danger\">Ha contestado incorrectamente, verifique sus respuestas.</p>";
                    return;
                }

                //habilitar el siguiente paso
                Session["respuestas"] = null;
                DeshabilitarFormulario();
                regMessagge.Text = "<p class=\"text-success\">Ha contestado correctamente sus respuestas de validación, puede dar al botón siguiente.</p>";

                _ObjectUserRegister ciudadano = new _SystemRegister().getInformacionCiudadano(regIdentiNumber.Text);
                regFname.Text = ciudadano.Nombre1;
                regSname.Text = ciudadano.Nombre2;
                regFlname.Text = ciudadano.Apellido1;
                regSlname.Text = ciudadano.Apellido2;
                regUbirth.Text = ciudadano.FNaciento;

                verificarPersona.Enabled = false;
                verificarPersona.Style.Add("display", "none");
                btnVali.Visible = true;
                    

            }
            catch (Exception ex)
            {
                regMessagge.Text = ex.Message;
            }

        }
        protected void regBtnSubmit_Click(object sender, EventArgs e)
        {
            cVarios estiloBackend = new cVarios();

            try
            {
                if (!(regDocumentType.Text.Length != 0 & regIdentiNumber.Text.Length != 0
                    & regFname.Text.Length != 0 & regFlname.Text.Length != 0
                    & regUbirth.Text.Length != 0 & regCel.Text.Length != 0
                    & regDirect.Text.Length != 0 & regEmail.Text.Length != 0
                    & regPass.Text.Length != 0))     
                    {
                        estiloBackend.AddCssClassWeb(regDataviewHead, "js-active");
                        estiloBackend.AddCssClassGeneric(regDataViu, "js-active");
                        regMessagge.Text = "<p class=\"text-danger\">Puede que algún campo * de requisito mínimo no se rellenó.</p>";
                        regPass.Text = "";
                        regRPass.Text = "";
                        regCheckDeclaration.Checked = false;
                        regBtnSubmit.Enabled = true;
                    return;
                    }

                new _SystemRegister().setRegistroCiudadano(
                    regDocumentType.Text,
                    regIdentiNumber.Text,
                    CapitalizarPrimeraLetra(regFname.Text),
                    CapitalizarPrimeraLetra(regSname.Text),
                    CapitalizarPrimeraLetra(regFlname.Text),
                    CapitalizarPrimeraLetra(regSlname.Text),
                    DateTime.Parse(this.regUbirth.Text).ToString("yyyyy-MM-dd"),
                    regCel.Text,
                    regEmail.Text,
                    regDirect.Text,
                    regPass.Text);

                string nombre = CapitalizarPrimeraLetra(regFname.Text) + " " +
                    CapitalizarPrimeraLetra(regSname.Text) + " " +
                    CapitalizarPrimeraLetra(regFlname.Text) + " " +
                    CapitalizarPrimeraLetra(regSlname.Text);


                new cCorreo()._RegisterMail(regEmail.Text,nombre);
                VaciarFormulario();
                Response.Redirect("~/App/Private/registerComplet.aspx");

            }
            catch (Exception ex)
            {
                regMessagge.Text = ex.Message;
            }

        }

        private void CedulaValid()
        {

           _ObjectUserRegister ciudadano = new _SystemRegister().getInformacionCiudadano(regIdentiNumber.Text);

            //problema en la consulta

            if (!(ciudadano != null))
            {
                regMessagge.Text = "<p class=\"text-danger\">Al parecer la busqueda tardo demasiado por favor vuelva a verificar su numero de identificacion.</p>";
                return;
            }

            //verificar la mayoria de edad
            if (!(new cVarios().CalculoEdad(DateTime.Parse(ciudadano.FNaciento)) > 17))

            { 
                regMessagge.Text = "<p class=\"text-danger\">No cumple con la edad necesaria para utilizar el sistema.</p>";
                regBtnVerify.Enabled = true;
                regBtnVerify.Visible = true;
                btnIdenti.Disabled = true;
                VaciarFormulario();
                return;
            }

            
            //pasar al siguiente step
            ValidateUserQuestions(ciudadano);

            regBtnVerify.Enabled = false;
            regBtnVerify.Style.Add("display", "none");
            btnIdenti.Disabled = false;
        }
        private void  ValidateUserQuestions( dynamic obj )
        {
            
            string[] fechas = new string[4];string[] apellidoPaterno = new string[4];string[] provinciacentro = new string[4];string[] proviciaVoto = new string[4];

            Session["respuestas"] = new _SystemRegister().getRespuestaDeSeguridad(regIdentiNumber.Text);

            fechas[0] = new _Session().getRespuestas().Pregunta1;
            apellidoPaterno[0] = new _Session().getRespuestas().Pregunta2;
            proviciaVoto[0] = new _Session().getRespuestas().Pregunta3;
            provinciacentro[0] = new _Session().getRespuestas().Pregunta4;


            int ite = 1;

            Random aleatorio = new Random();
            do
            {

                fechas[ite] = new cVarios().FechaAleatoria(aleatorio).ToString("yyyy-MM-dd");
                apellidoPaterno[ite] = new cVarios().ApellidoAleatorio(aleatorio.Next(49));
                proviciaVoto[ite] = new cVarios().ProvinciaAleatorio(aleatorio.Next(10));
                provinciacentro[ite] = new cVarios().CentroAleatorio(aleatorio.Next(16));

                ite++;
            } while (ite<4);

            Random random = new Random();
            RadioButtonListFechas.DataSource = fechas.OrderBy(x => random.Next()).ToArray();
            RadioButtonListApellidoMadre.DataSource = provinciacentro.OrderBy(x => random.Next()).ToArray();

            RadioButtonListApellidoPadre.DataSource = apellidoPaterno.OrderBy(x => random.Next()).ToArray();
            RadioButtonListProvinciaCentro.DataSource = proviciaVoto.OrderBy(x => random.Next()).ToArray();

            RadioButtonListFechas.DataBind();
            RadioButtonListApellidoMadre.DataBind();
            RadioButtonListApellidoPadre.DataBind();
            RadioButtonListProvinciaCentro.DataBind();


        }


        public void VaciarFormulario()
        {
            regDocumentType.SelectedValue = "Seleccione documento";
            regIdentiNumber.Text = "";
            regFname.Text = "";
            regFlname.Text = "";
            regSlname.Text = "";
            regUbirth.Text = "";
            regCel.Text = "";
            regEmail.Text = "";
            regDirect.Text = "";
            regPass.Text = "";
            regCheckDeclaration.Checked = false;
        }
        public void DeshabilitarFormulario()
        {
            regFname.Enabled = false;
            regSname.Enabled = false;
            regFlname.Enabled = false;
            regSlname.Enabled = false;
            regUbirth.Enabled = false;
            RadioButtonListFechas.Enabled= false;
            RadioButtonListApellidoMadre.Enabled= false;
            RadioButtonListApellidoPadre.Enabled= false;
            RadioButtonListProvinciaCentro.Enabled= false;
        }
        public static string CapitalizarPrimeraLetra(string sValue)
        {
            char[] array = sValue.ToCharArray();

            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }

            return new string(array);
        }

    }
}