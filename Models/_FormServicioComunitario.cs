using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace sjc
{
    public class _FormServicioComunitario
    {
        cConexion conexion = new cConexion();
        cVarios v = new cVarios();
        public void setRegistrarServicioComunitario(Int64 id_residente)
        {
            DateTime theDate = DateTime.Now;
            conexion.Insertar("INSERT INTO ssjc_solicitudes (soli_id_residente,soli_estado,soli_categoria,soli_fecha_creacion,soli_fecha_modificacion) VALUES ('" + id_residente + "',1,1,'" + theDate.ToString("yyyyy-MM-dd H:mm:ss") + "','" + theDate.ToString("yyyyy-MM-dd H:mm:ss") + "')");
        }

        public void setDetalleServicioComunitarioArchivo(Int64 soli, string sector, string dir_sol, string descsol, string det_tipo_soli, string det_adj)
        {
            DateTime theDate = DateTime.Now;
            conexion.Insertar("INSERT INTO ssjc_detallesercom (det_id_soli,det_sector, det_dir_sol, det_descsol, det_tipo_soli, det_adjuser) VALUES('" + soli + "','" + v.CadenasValidacion(sector) + "','" + v.CadenasValidacion(dir_sol) + "','" + v.CadenasValidacion(descsol) + "','" + v.CadenasValidacion(det_tipo_soli) + "' , '" + det_adj + "' ) ");
        }

        //pedir ultima solicitud de un residente para asignarle un detalle
        public Int64 getUltimaSolicitudUsuario(Int64 id_residente)
        {
            DataSet data = new DataSet();
            data = conexion.buscar("SELECT soli_id FROM ssjc_solicitudes WHERE soli_id_residente = '" + id_residente + "' ORDER BY soli_id DESC LIMIT 1", "ssjc_solicitudes");
            return Convert.ToInt64(data.Tables[0].Rows[0]["soli_id"]);
        }

        public void setServicioComunitario(Int64 IdSolicitante,string CorreoSolicitante,string NombreSolicitante, string ServComSectorIncidenteiD, string ServComSectorIncidenteTexto, string ServComDirecIncidente, string ServComDescripIncidente, string ServComTipoSolicitudID, string ServComTipoSolicitudTexto, string ServComEvidencia)
        {
            new _FormServicioComunitario().setRegistrarServicioComunitario(IdSolicitante);
            new _FormServicioComunitario().setDetalleServicioComunitarioArchivo(new _FormServicioComunitario().getUltimaSolicitudUsuario(IdSolicitante), ServComSectorIncidenteiD,v.CadenasValidacion(ServComDirecIncidente),v.CadenasValidacion(ServComDescripIncidente), ServComTipoSolicitudID, ServComEvidencia);
            new cSolicitudes().sethistSoli(new _FormServicioComunitario().getUltimaSolicitudUsuario(IdSolicitante), NombreSolicitante + " registro el tramite #" + new _FormServicioComunitario().getUltimaSolicitudUsuario(IdSolicitante));
            new cCorreo()._FormularioServicComunitario(CorreoSolicitante, NombreSolicitante, ServComTipoSolicitudTexto, ServComSectorIncidenteTexto, ServComDirecIncidente);
        }
    }
}