using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace sjc
{
    public class _SystemRegister
    {
        cConexion con = new cConexion();
        cVarios reformatear = new cVarios();

        public DataSet ExisteCiudadanoNumeroDocumento(string NumDoc)
        {
            return con.buscar("select user_numeroIdent from ssjc_user where user_numeroIdent = '" + reformatear.CadenasValidacion(NumDoc) + "'", "ssjc_user");
        }
        private dynamic getInformacionCiudadanoApi(string cedula)
        {
            return new cTeApi().GetIfon(cedula);
        }

        public _ObjectUserRegister getInformacionCiudadano(string NumDocumento)
        {
            dynamic ciudadano = new _SystemRegister().getInformacionCiudadanoApi(NumDocumento);
            _ObjectUserRegister userRegister = new _ObjectUserRegister();

            if (ciudadano == null)
            { return userRegister ; }

            userRegister.Nombre1 = traerPrimerNombre(ciudadano);
            userRegister.Nombre2 = traerSegundoNombre(ciudadano);
            userRegister.Apellido1 = traerApellidoPaterno(ciudadano);
            userRegister.Apellido2 = traerApellidoMaterno(ciudadano);
            userRegister.FNaciento = traerNacimiento(ciudadano);

            return userRegister;
        }
        private dynamic traerPrimerNombre(dynamic obj)
        {
            return obj.verificarPersonaDesglosadaRs.PersonaInfo.PublicaBasico[0].primerNombre;
        }
        private dynamic traerSegundoNombre(dynamic obj)
        {
            return obj.verificarPersonaDesglosadaRs.PersonaInfo.PublicaBasico[0].segundoNombre;
        }
        private dynamic traerApellidoPaterno(dynamic obj)
        {
            return obj.verificarPersonaDesglosadaRs.PersonaInfo.PublicaBasico[0].apellidoPaterno;
        }
        private dynamic traerApellidoMaterno(dynamic obj)
        {
            return obj.verificarPersonaDesglosadaRs.PersonaInfo.PublicaBasico[0].apellidoMaterno;
        }
        private dynamic traerNacimiento(dynamic obj)
        {
            var fn = obj.verificarPersonaDesglosadaRs.PersonaInfo.PublicaRegistro[0].fechaNacimiento;

            return Convert.ToDateTime(fn).ToString("yyyy-MM-dd");
        }


        public _ObjectUserSecurityQuestion getRespuestaDeSeguridad(string NumDocumento)
        {
            dynamic ciudadano = new _SystemRegister().getInformacionCiudadanoApi(NumDocumento);
            _ObjectUserSecurityQuestion respuestaSeuridad = new _ObjectUserSecurityQuestion();

            if (ciudadano == null)
            { return respuestaSeuridad; }

            respuestaSeuridad.Pregunta1 = traerNacimiento(ciudadano);
            respuestaSeuridad.Pregunta2 = traerPaternoApellido(ciudadano);
            respuestaSeuridad.Pregunta3 = traerLugarCentro(ciudadano);
            respuestaSeuridad.Pregunta4 = traerCentro(ciudadano);


            return respuestaSeuridad;
        }
        private dynamic traerPaternoApellido(dynamic obj)
        {
            return obj.verificarPersonaDesglosadaRs.PersonaInfo.ConfidencialPadre[0].apellidoPaternoPadre;
        }
        private dynamic traerLugarCentro(dynamic obj)
        {
            dynamic objeto = obj.verificarPersonaDesglosadaRs.PersonaInfo.ConfidencialCentro[0].provinciaCentro;
            return (objeto == "") ? "ninguna de las anteriores" : objeto;
        }
        private dynamic traerCentro(dynamic obj)
        {
            dynamic objeto = obj.verificarPersonaDesglosadaRs.PersonaInfo.ConfidencialCentro[0].nombreCentro;
            return (objeto == "") ? "ninguna de las anteriores" : objeto;
        }


        public void setRegistroCiudadano(String typeDocmuent, String cedula, String name, String sname, String lastname, String slastname, String fnacimiento, String celular, String email, String diretion, String password)
        {
            con.Insertar("INSERT INTO ssjc_user (user_typeDocmuent,user_numeroIdent,user_name,user_sname,user_lastname,user_slastname,user_fnacimiento,user_celular,user_email,user_diretion,user_password) VALUES ('" + reformatear.CadenasValidacion(typeDocmuent) + "','" + reformatear.CadenasValidacion(cedula) + "','" + reformatear.CadenasValidacion(name) + "','" + reformatear.CadenasValidacion(sname) + "','" + reformatear.CadenasValidacion(lastname) + "','" + reformatear.CadenasValidacion(slastname) + "','" + fnacimiento + "','" + reformatear.CadenasValidacion(celular) + "','" + email + "','" + reformatear.CadenasValidacion(diretion) + "','" + reformatear.CadenasValidacion(password) + "')");
        }

    }
}