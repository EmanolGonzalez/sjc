using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace sjc
{
    public class cAdministrativos
    {
        cConexion conexion = new cConexion();
        cVarios v = new cVarios();

        public Int64 getSolicitudesTotales()
        {
            DataSet data = conexion.buscar("select count(*) as cuenta from ssjc_solicitudes where soli_estado = 1", "ssjc_solicitudes");
            return Convert.ToInt64(data.Tables[0].Rows[0]["cuenta"]);
        }

        public Int64 getSolicitudesSCTotales()
        {
            DataSet data = conexion.buscar("select count(*) as cuenta  from ssjc_solicitudes where soli_categoria =1 and soli_estado = 1 ;", "ssjc_solicitudes");
            return Convert.ToInt64(data.Tables[0].Rows[0]["cuenta"]);
        }

        public Int64 getSolicitudesProceso()
        {
            DataSet data = conexion.buscar("select count(*) as cuenta from ssjc_solicitudes where soli_estado <> 1 and soli_estado <> 7 and soli_estado <> 8", "ssjc_solicitudes");
            return Convert.ToInt64(data.Tables[0].Rows[0]["cuenta"]);
        }

        public Int64 getSolicitudesSCProceso()
        {
            DataSet data = conexion.buscar("select count(*) as cuenta  from ssjc_solicitudes where soli_categoria =1 and  (soli_estado <> 1 and soli_estado <> 7 and soli_estado <> 8)", "ssjc_solicitudes");
            return Convert.ToInt64(data.Tables[0].Rows[0]["cuenta"]);
        }

        public Int64 getSolicitudesFinalizado()
        {
            DataSet data = conexion.buscar("select count(*) as cuenta from ssjc_solicitudes where soli_estado = 7 or soli_estado = 5 or soli_estado = 8 ", "ssjc_solicitudes");
            return Convert.ToInt64(data.Tables[0].Rows[0]["cuenta"]);
        }

        public Int64 getSolicitudesSCFinalizado()
        {
            DataSet data = conexion.buscar("select count(*) as cuenta  from ssjc_solicitudes where  soli_categoria =1 and ( soli_estado = 7 or soli_estado = 5 or soli_estado = 8 )", "ssjc_solicitudes");
            return Convert.ToInt64(data.Tables[0].Rows[0]["cuenta"]);
        }

        public int getNumeroDeColaboradores()
        {
            DataSet date = conexion.buscar("select count(colab_id) as ncolaboradores from ssjc_colbab", "ssjc_colbab");
            return Convert.ToInt32( date.Tables[0].Rows[0]["ncolaboradores"]);
        }
        public int getNumeroDeResidentes()
        {
            DataSet date = conexion.buscar("select count(user_id) as ncolaboradores from ssjc_user", "ssjc_user");
            return Convert.ToInt32( date.Tables[0].Rows[0]["ncolaboradores"]);
        }

        public DataSet getTodosColaboradores()
        {
            DataSet data = conexion.buscar("SELECT colab_id as idC,colab_numeroIdent as ndoc,colab_name as nombre,colab_lastname as apellido,cargo_nombre as cargo,dep_nombre as departamento FROM ssjc_colbab AS colaborador INNER JOIN ssjc_colabcargo AS cargo ON  colaborador.colab_cargo = cargo.cargo_id INNER JOIN ssjc_departamento AS depa ON colaborador.colab_departamento = depa.dep_id order by  colab_id asc;", "ssjc_colbab");
            return data;
        }
        public DataSet getTodosUsuarios()
        {
            DataSet data = conexion.buscar("SELECT user_id as ndoc,user_name as nombre, user_lastname as apellido,user_email as correo FROM ssjc_user as usuario order by  user_id asc;", "ssjc_user");
            return data;
        }
        

    }
}