using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sjc
{
    public class _SystemLogs
    {
        cConexion conexion = new cConexion();
        cVarios v = new cVarios();

        public void AccessLogs(Int64 UsId, string UsNombre, string UsTipo, string UsAccion)
        {
            DateTime theDate = DateTime.Now;
            conexion.Insertar("INSERT INTO ssjc_accesssystem (access_userid,access_username,access_usertype,access_action,access_time) VALUES (" + UsId + ",'" + UsNombre + "','" + v.CadenasValidacion(UsTipo) + "','" + v.CadenasValidacion(UsAccion) + "','" + theDate.ToString("yyyyy-MM-dd H:mm:ss") + "')");
        }
    }
}