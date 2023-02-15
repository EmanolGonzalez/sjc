using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sjc
{
    public class _InfJuntaComunal
    {
        private string[] JuntaComunalDepartamentos = new string[] {
            "vacio",
            "Administración",
            "Línea Única de Atención",
            "Ornato y Aseo",
            "Eventos",
            "Asesoría Legal",
            "Recepción",
            "Despacho"
        };        
        private string[] JuntaComunalCargos = new string[] {
            "vacio",
            "Administrador",
            "Jefe De Departamento",
            "Colaborador",
            "Representante"
        };
        private string[] JuntaComunalRol = new string[] {
            "vacio",
            "Administrador",
            "Evaluador",
            "Revisor"
        };

        public string ColaboradorDepartamento(int ale)
        {
            return JuntaComunalDepartamentos[ale];
        }
        public string ColaboradorCargo(int ale)
        {
            return JuntaComunalCargos[ale];
        }
        public string ColaboradorRol(int ale)
        {
            return JuntaComunalRol[ale];
        }

    }
}