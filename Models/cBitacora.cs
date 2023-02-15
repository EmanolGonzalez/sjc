using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace sjc
{
    public class cBitacora
    {
        cConexion conexion = new cConexion();
        cVarios v = new cVarios();

        public void BitacoraAcceso(Int64 usuario, string tipousurio, string accion)
        {
            DateTime theDate = DateTime.Now;
            conexion.Insertar("INSERT INTO ssjc_accesssystem (access_userid,access_usertype,access_action,access_time) VALUES (" + usuario +",'"+ v.CadenasValidacion(tipousurio) +"','"+ v.CadenasValidacion(accion) +"','"+ theDate.ToString("yyyyy-MM-dd H:mm:ss") + "')");
        }


    }
}