using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace sjc
{
    public class cVarios
    {

        public string PassRandom()
        {
            Random rdn = new Random();
            string caracteres = "%$#@abcdefghijklmnopqrstuvwxyz%$#@ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 10;
            string contraseniaAleatoria = string.Empty;
            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                contraseniaAleatoria += letra.ToString();
            }

            return contraseniaAleatoria;
        }

        public String CadenasValidacion(String texto)
        {
            return texto.Replace("'", "").Replace("/", "").Replace(@"\", "");
        }

        private string[] provincias = new string[] { "BOCAS DEL TORO", "COCLÉ", "COLÓN", "CHIRIQUÍ", "DARIÉN", "HERRERA", "LOS SANTOS", "PANAMÁ", "VERAGUAS", "PANAMÁ OESTE" };
        private string[] centros = new string[] { "ESC. CERRO PELADO","ESC. SAN ISIDRO","C.E.B.G. REPUBLICA DE BOLIVIA","CENT.  TELE EDUCACION NICOLLE GARAY","ESC. SECUNDARIA DE ALANJE","I.P.T. FERNANDO DE LESSEPS","ESC. ESTADO DE MINNESOTA","ESC. PIJIBAZAL","C.E.B.G. JOSE DE LA C. HERRERA","C.E.B.G. COCLESITO","COL. FRANCISCO I. CASTILLERO","ESC. LOS TORETOS","IPHE DE BOCAS DEL TORO","ESC. SALSIPUEDES","IPHE DE LA VILLA","ESC. LAS FILIPINAS","ESC. SIMON BOLIVAR" };

        private string[] apellidos = new string[] {"Garcia","Gonzalez","Rodriguez","Diaz","Buhajeruk","De la Cruz","Lopez","Perez","Ruiz","Martinez","Lee","Soto","Sanchez","Hernandez","Kim","Roux","Gomez","Smith","Fernandez","Flores","Sheinbaum","Torres","Castillo","Ramirez","Rojas","Cruz","Castro","Morales","Alvarez","Reyes","Martin","Milei","Boric","Quispe","Rousseau","Gutierrez","Romero","Moreno","Ramos","Silva","Jimenez","Rivera","Vargas","de Leon","Yarima","Jose","Muñoz","Suarez","Medina","Muller" };
        public string ProvinciaAleatorio(int ale)
        {
            return provincias[ale];
        }
        public string CentroAleatorio(int ale)
        {
            return centros[ale];
        }

        public string ApellidoAleatorio(int ale)
        {
            return apellidos[ale];
        }
        
       public DateTime FechaAleatoria(Random ale)
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(ale.Next(range));
        }

        public int CalculoEdad(DateTime anniversaire)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - anniversaire.Year;
            if (anniversaire > now.AddYears(-age))
                age--;
            return age;
        }

        public void AddCssClassWeb(HtmlControl control, String css)

        {
            control.Attributes.Add("class", String.Join(" ", control
                       .Attributes["class"]
                       .Split(' ')
                       .Except(new string[] { "", css })
                       .Concat(new string[] { css })
                       .ToArray()
               ));
        }

       public void RemoveCssClassWeb(HtmlControl control, String css)
        {
            control.Attributes.Add("class", String.Join(" ", control
            .Attributes["class"]
            .Split(' ')
            .Except(new string[] { "", css })
            .ToArray()
            ));
        }       
       public void AddCssClassGeneric( HtmlGenericControl control, String css)
        {
            control.Attributes.Add("class", String.Join(" ", control
                       .Attributes["class"]
                       .Split(' ')
                       .Except(new string[] { "", css })
                       .Concat(new string[] { css })
                       .ToArray()
               ));
        }

       public void RemoveCssClassGeneric(HtmlGenericControl control, String css)
        {
            control.Attributes.Add("class", String.Join(" ", control
            .Attributes["class"]
            .Split(' ')
            .Except(new string[] { "", css })
            .ToArray()
            ));
        }


    }
}