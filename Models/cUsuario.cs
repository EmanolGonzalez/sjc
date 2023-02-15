using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace sjc
{
    public class cUsuario
    {
        cConexion conexion = new cConexion();
        cVarios v = new cVarios();


        //      pedir Info Un Usuario
        public DataSet getUnUsuario(Int64 codigo)
        {
            string formato = "%d-%m-%Y";
            return conexion.buscar("SELECT user_typeDocmuent,user_numeroIdent,user_name,user_sname,user_lastname,user_slastname,date_format(user_fnacimiento,'"+formato+"') as date,user_celular,user_email,user_diretion FROM ssjc_user WHERE user_id=" + codigo, "ssjc_user");
        }

        //      pedir nombre completo
        public DataSet getIdPorCorreo(String correoUser)
        {
            return conexion.buscar("SELECT user_id,user_email FROM ssjc_user WHERE user_email='" + v.CadenasValidacion(correoUser) + "'", "ssjc_user");
        }

        //      pedir nombre completo
        public DataSet getNombreCompleto(Int64 codigo)
        {
            return conexion.buscar(" SELECT  CONCAT(user_name,\" \",user_sname,\" \",user_lastname,\" \",user_slastname)as nombre FROM ssjc_user where user_id='" + codigo + "';", "ssjc_user");
        }

        //Recovery Password

        //      Cambio de Clave
        public void CambioClave(String clave, Int64 codigo_u)
        {
            conexion.Insertar("UPDATE ssjc_user set user_password='" + v.CadenasValidacion(clave) + "' where user_id=" + codigo_u);
        }
        //      Operaciones de Recovery
        public void deleteRecoveryPasswordRequest(string token)
        {
             conexion.Insertar("DELETE from ssjc_userrecopassrequest WHERE recovey_id='" + token+"'");
        }
        public DataSet getRecoveryPasswordRequest(String token)
        {
            return conexion.buscar("SELECT * FROM ssjc_userrecopassrequest WHERE recovey_id='" + v.CadenasValidacion(token) + "'", "ssjc_userrecopassrequest");
        }
        public void setRecoveryPasswordRequest(string token, string email)
        {
            DateTime theDate = DateTime.Now;
            conexion.Insertar("INSERT INTO ssjc_userrecopassrequest VALUES('"+token+"' , '"+email+"' , '" + theDate.ToString("yyyyy-MM-dd H:mm:ss") + "')");
        }

 
    }
}