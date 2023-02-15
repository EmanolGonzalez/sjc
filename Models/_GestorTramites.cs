using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace sjc
{
    public class _GestorTramites
    {
        cConexion conexion = new cConexion();

        //TRAMITES TODOS LOS DEPARTAMENTOS
        public DataSet getAllSolicitudesNuevas()
        {
            DataSet data = conexion.buscar("SELECT soli_id as \"No.Tramite\",estado_nombre as \"Estado\",cate_nombre as \"Categoria\",user_numeroIdent as \"Identificacion\",CONCAT(user_name,\" \",user_lastname)as \"Residente\",tsoli_nombre as \"Tipo Solicitud\",soli_fecha_creacion as\"Fecha\" FROM ssjc_user as usuario INNER JOIN ssjc_solicitudes AS solicitud ON solicitud.soli_id_residente = usuario.user_id INNER JOIN ssjc_estadosollid AS estado ON estado.estado_id = solicitud.soli_estado INNER JOIN ssjc_categsolid AS categoria ON categoria.cate_id = solicitud.soli_categoria INNER JOIN ssjc_detallesercom as detalle ON detalle.det_id_soli = solicitud.soli_id INNER JOIN ssjc_tiposolidetallesc as tipo ON tipo.tsoli_id = detalle.det_tipo_soli WHERE soli_estado = 1 ;", "ssjc_solicitudes");
            return data;
        }
        public DataSet getAllSolicitudesEnProgreso()
        {
            DataSet data = conexion.buscar("SELECT soli_id as \"No.Tramite\",estado_nombre as \"Estado\",cate_nombre as \"Categoria\",user_numeroIdent as \"Identificacion\",CONCAT(user_name,\" \",user_lastname)as \"Residente\",tsoli_nombre as \"Tipo Solicitud\",soli_fecha_creacion as\"Fecha\" FROM ssjc_user as usuario INNER JOIN ssjc_solicitudes AS solicitud ON solicitud.soli_id_residente = usuario.user_id INNER JOIN ssjc_estadosollid AS estado ON estado.estado_id = solicitud.soli_estado INNER JOIN ssjc_categsolid AS categoria ON categoria.cate_id = solicitud.soli_categoria INNER JOIN ssjc_detallesercom as detalle ON detalle.det_id_soli = solicitud.soli_id INNER JOIN ssjc_tiposolidetallesc as tipo ON tipo.tsoli_id = detalle.det_tipo_soli WHERE soli_estado <> 1 AND soli_estado <> 7 AND soli_estado<> 5 AND soli_estado <> 8 ;", "ssjc_solicitudes");
            return data;
        }
        public DataSet getAllSolicitudesHistorial()
        {
            DataSet data = conexion.buscar("SELECT soli_id as \"No.Tramite\",estado_nombre as \"Estado\",cate_nombre as \"Categoria\",user_numeroIdent as \"Identificacion\",CONCAT(user_name,\" \",user_lastname)as \"Residente\",tsoli_nombre as \"Tipo Solicitud\",soli_fecha_creacion as\"Fecha\"  FROM ssjc_user as usuario INNER JOIN ssjc_solicitudes AS solicitud ON solicitud.soli_id_residente = usuario.user_id INNER JOIN ssjc_estadosollid AS estado ON estado.estado_id = solicitud.soli_estado INNER JOIN ssjc_categsolid AS categoria ON categoria.cate_id = solicitud.soli_categoria INNER JOIN ssjc_detallesercom as detalle ON detalle.det_id_soli = solicitud.soli_id INNER JOIN ssjc_tiposolidetallesc as tipo ON tipo.tsoli_id = detalle.det_tipo_soli WHERE soli_estado = 7 OR soli_estado = 5 OR soli_estado = 8 ;", "ssjc_solicitudes");
            return data;
        }

        //TRAMITES  DEPARTAMENTOS ORNATO Y ASEO
        public DataSet getOASolicitudesNuevas()
        {
            DataSet data = conexion.buscar("SELECT soli_id as \"No.Tramite\",estado_nombre as \"Estado\",cate_nombre as \"Categoria\",user_numeroIdent as \"Identificacion\",CONCAT(user_name,\" \",user_lastname)as \"Residente\",tsoli_nombre as \"Tipo Solicitud\",soli_fecha_creacion as\"Fecha\" FROM  ssjc_user as usuario INNER JOIN ssjc_solicitudes AS solicitud ON solicitud.soli_id_residente = usuario.user_id INNER JOIN ssjc_estadosollid AS estado ON estado.estado_id = solicitud.soli_estado INNER JOIN ssjc_categsolid AS categoria ON categoria.cate_id = solicitud.soli_categoria INNER JOIN  ssjc_detallesercom as detalle ON detalle.det_id_soli = solicitud.soli_id INNER JOIN  ssjc_tiposolidetallesc as tipo ON tipo.tsoli_id = detalle.det_tipo_soli WHERE soli_categoria = 1 and soli_estado = 1; ", "ssjc_solicitudes");
            return data;
        }
        public DataSet getOASolicitudesEnProceso()
        {
            DataSet data = conexion.buscar("SELECT soli_id as \"No.Tramite\",estado_nombre as \"Estado\",cate_nombre as \"Categoria\",user_numeroIdent as \"Identificacion\",CONCAT(user_name,\" \",user_lastname)as \"Residente\",tsoli_nombre as \"Tipo Solicitud\",soli_fecha_creacion as\"Fecha\" FROM ssjc_user as usuario INNER JOIN ssjc_solicitudes AS solicitud ON solicitud.soli_id_residente = usuario.user_id INNER JOIN ssjc_estadosollid AS estado ON estado.estado_id = solicitud.soli_estado INNER JOIN ssjc_categsolid AS categoria ON categoria.cate_id = solicitud.soli_categoria INNER JOIN ssjc_detallesercom as detalle ON detalle.det_id_soli = solicitud.soli_id INNER JOIN ssjc_tiposolidetallesc as tipo ON tipo.tsoli_id = detalle.det_tipo_soli WHERE  soli_categoria = 1 and (soli_estado <> 1 AND soli_estado <> 7 AND soli_estado<> 5 AND soli_estado <> 8 )", "ssjc_solicitudes");
            return data;
        }
        public DataSet getOASolicitudesHistorial()
        {
            DataSet data = conexion.buscar("SELECT soli_id as \"No.Tramite\",estado_nombre as \"Estado\",cate_nombre as \"Categoria\",user_numeroIdent as \"Identificacion\",CONCAT(user_name,\" \",user_lastname)as \"Residente\",tsoli_nombre as \"Tipo Solicitud\",soli_fecha_creacion as\"Fecha\"  FROM ssjc_user as usuario INNER JOIN ssjc_solicitudes AS solicitud ON solicitud.soli_id_residente = usuario.user_id INNER JOIN ssjc_estadosollid AS estado ON estado.estado_id = solicitud.soli_estado INNER JOIN ssjc_categsolid AS categoria ON categoria.cate_id = solicitud.soli_categoria INNER JOIN ssjc_detallesercom as detalle ON detalle.det_id_soli = solicitud.soli_id INNER JOIN ssjc_tiposolidetallesc as tipo ON tipo.tsoli_id = detalle.det_tipo_soli WHERE soli_categoria = 1 and (soli_estado = 7 OR soli_estado = 5 OR soli_estado = 8)", "ssjc_solicitudes");
            return data;
        }


    }
}