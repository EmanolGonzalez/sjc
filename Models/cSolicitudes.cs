using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace sjc
{
    public class cSolicitudes
    {
        cConexion conexion = new cConexion();
        cVarios v = new cVarios();

        public void setAdjJc(Int64 soli, string adjunto)
        {
            conexion.Insertar("UPDATE ssjc_detallesercom SET det_adjjunta = '"+adjunto+"' WHERE det_id_soli ="+soli);
        }

    //pedir solicitud solicitudes realizadas por un usuario en especifico
        public DataSet getUserSoli(Int64 id_residente)
        {
            DataSet data = conexion.buscar("SELECT soli_id as \"Numero de Tramite\",estado_nombre as \"Estado\", cate_nombre as \"Categoria\",soli_fecha_creacion AS \"Fecha De Solicitud\" FROM ssjc_solicitudes solicitud INNER JOIN ssjc_estadosollid estado on estado.estado_id = solicitud.soli_estado INNER JOIN ssjc_categsolid categoria on categoria.cate_id = solicitud.soli_categoria WHERE soli_id_residente = '" + id_residente + "' ORDER BY soli_id asc", "ssjc_solicitudes");
            return  data; 
        }

        public DataSet getTramite(Int64 id_tramite)
        {
            DataSet data = conexion.buscar("SELECT concat(user_name,\" \",user_sname,\" \",user_lastname,\" \",user_slastname) as nombre, user_typeDocmuent as Documentacion,user_numeroIdent as identificacion,user_email as email, user_celular as celular,soli_estado as id_estado, estado_nombre as estado,soli_fecha_creacion as fecha, tsoli_nombre as tipo, concat(sector_nombre,\" --- \",det_dir_sol) as direccion, det_descsol as descricion, det_adjuser as adjuntoUser,det_adjjunta as adjuntoJC FROM ssjc_solicitudes as solicitud INNER JOIN ssjc_user AS usuario ON usuario.user_id = solicitud.soli_id_residente INNER JOIN ssjc_detallesercom AS detalle ON detalle.det_id_soli = solicitud.soli_id INNER JOIN ssjc_tiposolidetallesc AS tipo ON tipo.tsoli_id = detalle.det_tipo_soli INNER JOIN ssjc_sectoredetallessc AS sector ON sector.sector_id = detalle.det_sector INNER JOIN ssjc_estadosollid AS estado ON estado.estado_id = solicitud.soli_estado WHERE soli_id =" + id_tramite, "ssjc_solicitudes");
            return data;
        }

        public DataSet getCategoriaTramite(Int64 id_tramite)
        {
            DataSet data = conexion.buscar("select soli_categoria as idcate, cate_nombre as nomcate from ssjc_solicitudes solicitud inner join ssjc_categsolid categoria on categoria.cate_id = solicitud.soli_categoria where soli_id =" + id_tramite , "ssjc_solicitudes");
            return data;
        }


        // cambiar estado de una solicitud
        public void StatusStartSoli(Int64 id_tramite)
        {
            DateTime theDate = DateTime.Now;
            conexion.Insertar("UPDATE ssjc_solicitudes SET soli_estado = 2 , soli_fecha_modificacion ='"+theDate.ToString("yyyyy-MM-dd H:mm:ss")+"' WHERE soli_id = " + id_tramite + " ");
        }

        public void ChangeStatusSoli(Int64 id_tramite, string estado)
        {
            DateTime theDate = DateTime.Now;
            conexion.Insertar("UPDATE ssjc_solicitudes SET soli_estado =" + estado + " , soli_fecha_modificacion ='" + theDate.ToString("yyyyy-MM-dd H:mm:ss") + "'  WHERE soli_id = " + id_tramite + " ");
        }

        public void CancelSoli(Int64 id_tramite)  
        {
            DateTime theDate = DateTime.Now;
            conexion.Insertar("UPDATE ssjc_solicitudes SET soli_estado = 8 , soli_fecha_modificacion ='" + theDate.ToString("yyyyy-MM-dd H:mm:ss") + "' WHERE soli_id = " + id_tramite + " ");
        }


        public void AprobRechSoli(Int64 id_tramite, string estado,string coment)
        {
            DateTime theDate = DateTime.Now;
            conexion.Insertar("UPDATE ssjc_solicitudes SET soli_estado =" + estado + " , soli_fecha_modificacion ='" + theDate.ToString("yyyyy-MM-dd H:mm:ss") + "', soli_comentario ='"+coment+"'  WHERE soli_id = " + id_tramite + " ");
        }

        public void sethistSoli(Int64 soli_id,string historia)
        {
            DateTime theDate = DateTime.Now;
            conexion.Insertar("insert into ssjc_histsolid (hist_id_soli,hist_contenido,hist_date) values("+soli_id+",'"+historia+"','"+theDate.ToString("yyyyy-MM-dd H:mm:ss") + "')");
        }

        public DataSet gethistsoli(Int64 idsoli)
        {
            DataSet data = conexion.buscar("SELECT concat(hist_contenido,\" el \",hist_date) as Historico FROM ssjc_histsolid where hist_id_soli="+idsoli, "ssjc_histsolid");
            return data;
        }


    }
}