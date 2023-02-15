using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace sjc
{
    public class _ObjectSession
    {
        public int CoId { get; set; }
        public string CoNombre { get; set; }
        public int CoCargo { get; set; }
        public int CoRol { get; set; }
        public int CoDepartamento { get; set; }
    }
    public class _ObjectUserSession
    { 
        public int UsId { get; set; }
        public string UsNumDoc { get; set; }
        public string UsNombres { get; set; }
        public string UsApellidos { get; set; }
    }
    public class _ObjectUserRegister
    {
        public string NumDocCiudadano { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string FNaciento { get; set; }
    }
    public class _ObjectUserSecurityQuestion
    {
        public string Pregunta1 { get; set; }
        public string Pregunta2 { get; set; }
        public string Pregunta3 { get; set; }
        public string Pregunta4 { get; set; }
    }

}