using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sjc
{
    public class cTeApi
    {
        private string apiUrl = "http://svr-cdi-piz-p03:11223/zato/te/v1/verificarpersona";

        private string bodyApiRequest(string cedu = "")
        {
            var jsonBody = new
            {
                datosComunesPeticion = new
                {
                    cadenaVerificacion = "string",
                    nombrePersonaContacto = "Sistema Junta Comunal",
                    aplicacion = "Sistema Junta Comunal"
                },
                verificarPersonaDesglosadaRq = new
                {
                    cedula = ""+cedu+"",
                    numeroPlastico = "",
                    tiempoEspera = 0
                }
            };


            return (string)JsonConvert.SerializeObject(jsonBody);
        }


        public async Task<dynamic> getStatus(string cedula)
        {

            dynamic r = null;

            WinHttpHandler   handler = new WinHttpHandler();
            using (var httpClient = new HttpClient(handler))
            {
                using (var requestMessage = new HttpRequestMessage())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Add("Authorization", ConfigurationManager.AppSettings["Api"]);

                    requestMessage.Method= HttpMethod.Get;
                    requestMessage.RequestUri= new Uri(apiUrl);
                    requestMessage.Content = new StringContent(bodyApiRequest(cedula));

                    var response = await httpClient.SendAsync(requestMessage).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var contenidoString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        string json = JsonConvert.DeserializeObject(contenidoString).ToString();

                        dynamic persona = JsonConvert.DeserializeObject<dynamic>(json);
                        if (persona.verificarPersonaDesglosadaRs.statusInformation.status == "Success")
                        {
                            r = persona;
                        }
                        
                    }

                    return r; 
                }

            }
        }

 

        public dynamic GetIfon(string cedula)
        {
            return getStatus(cedula).Result;
        }
    }
}