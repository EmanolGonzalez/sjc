using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace sjc
{
    public class _Session
    {
        

        //peticiones
        private DataSet ColaboradorSession(string mail, string UserPwd)
        {
            cConexion con = new cConexion();
            return con.buscar(
                "select colab_id as CoId, concat(colaborador.colab_name,\" \", colaborador.colab_lastname) as CoNombre, colaborador.colab_cargo as CoCargo, colab_rol as CoRol, colab_departamento as CoDepartamento from ssjc_colbab as colaborador where colab_email = '" + new cVarios().CadenasValidacion( mail)+ "' and colab_password = '"+ new cVarios().CadenasValidacion(UserPwd) +"' ",
                "ssjc_colbab");
        }
        private DataSet CiudadanoSession(string UserNumDocOrMail,string UserPwd,string NumDocOrMail)
        {
            cConexion con = new cConexion();
            return con.buscar(
             "select user_id as UsId, user_numeroIdent as UsNumDoc, concat(user_name,\" \", user_sname) as UsNombres, concat(user_lastname, \" \", user_slastname) as UsApellidos from ssjc_user as usuario where "+NumDocOrMail+" = '"+ new cVarios().CadenasValidacion(UserNumDocOrMail) +"' and user_password = '"+ new cVarios().CadenasValidacion(UserPwd) +"' ",
             "ssjc_user");
        }

        public _ObjectSession getColaboradorSession(string correo, string contrasena)
        {
            _ObjectSession colaborador = new _ObjectSession();
            DataSet data = ColaboradorSession(correo, contrasena);

            if(data.Tables[0].Rows.Count == 0)
            {return colaborador = null;}

            colaborador.CoId = Convert.ToInt32(data.Tables[0].Rows[0]["CoId"].ToString());
            colaborador.CoNombre = data.Tables[0].Rows[0]["CoNombre"].ToString();
            colaborador.CoCargo = Convert.ToInt32(data.Tables[0].Rows[0]["CoCargo"].ToString());
            colaborador.CoRol = Convert.ToInt32(data.Tables[0].Rows[0]["CoRol"].ToString());
            colaborador.CoDepartamento = Convert.ToInt32(data.Tables[0].Rows[0]["CoDepartamento"].ToString());

            return colaborador;
        }

        public _ObjectUserSession getCiudadanoSession(string UserNumDocOrMail, string UserPwd)
        {
            _ObjectUserSession ciudadano = new _ObjectUserSession();
            string correo = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            string metodo = "user_numeroIdent";

            if (Regex.IsMatch(UserNumDocOrMail, correo) == true)
            {metodo = "user_email";}

            DataSet data = CiudadanoSession(UserNumDocOrMail,UserPwd,metodo);

            if (data.Tables[0].Rows.Count == 0)
            {return ciudadano = null;}

            ciudadano.UsId  = Convert.ToInt32(data.Tables[0].Rows[0]["UsId"].ToString());
            ciudadano.UsNumDoc = data.Tables[0].Rows[0]["UsNumDoc"].ToString();
            ciudadano.UsNombres = data.Tables[0].Rows[0]["UsNombres"].ToString();
            ciudadano.UsApellidos = data.Tables[0].Rows[0]["UsApellidos"].ToString();

            return ciudadano;
        }

        public int getIdColaborador()
        {
            _ObjectSession ciudadano = HttpContext.Current.Session["usuario"] as _ObjectSession;
            return ciudadano.CoId;
        }
        public string getNombreCompletoColaborador()
        {
            _ObjectSession ciudadano = HttpContext.Current.Session["usuario"] as _ObjectSession;
            return ciudadano.CoNombre;
        }
        public int getCargoColaborador()
        {
            _ObjectSession ciudadano = HttpContext.Current.Session["usuario"] as _ObjectSession;
            return ciudadano.CoCargo;
        }
        public int getRolColaborador()
        {
            _ObjectSession ciudadano = HttpContext.Current.Session["usuario"] as _ObjectSession;
            return ciudadano.CoRol;
        }
        public int getDepartamentoColaborador()
        {
            _ObjectSession ciudadano = HttpContext.Current.Session["usuario"] as _ObjectSession;
            return ciudadano.CoDepartamento;
        }

        public int getIdCiudadano()
        {
            _ObjectUserSession ciudadano = HttpContext.Current.Session["usuario"] as _ObjectUserSession;
            return ciudadano.UsId;
        }
        public string getNombreCompletoCiudadano()
        {
            _ObjectUserSession ciudadano = HttpContext.Current.Session["usuario"] as _ObjectUserSession;
            return ciudadano.UsNombres + " " + ciudadano.UsApellidos;
        }
        public string getNumeroIdentificacionDocumentoCiudadano()
        {
            _ObjectUserSession ciudadano = HttpContext.Current.Session["usuario"] as _ObjectUserSession;
            return ciudadano.UsNumDoc;
        }
        public _ObjectUserSecurityQuestion getRespuestas()
        {
            _ObjectUserSecurityQuestion respuestas = HttpContext.Current.Session["respuestas"] as _ObjectUserSecurityQuestion;
            return respuestas;
        }
        
    }
}