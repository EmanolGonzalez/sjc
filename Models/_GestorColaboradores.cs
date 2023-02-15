using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace sjc
{
    public class _GestorColaboradores
    {
        cConexion conexion = new cConexion();
        cVarios v = new cVarios();

        //TRAER COLABORADORES
        public int getNumeroDeColaboradores()
        {
            DataSet date = conexion.buscar("select count(colab_id) as ncolaboradores from ssjc_colbab", "ssjc_colbab");
            return Convert.ToInt32(date.Tables[0].Rows[0]["ncolaboradores"]);
        }
        public DataSet getTodosColaboradores()
        {
            DataSet data = conexion.buscar("SELECT colab_id as idC,colab_numeroIdent as ndoc,colab_name as nombre,colab_lastname as apellido,cargo_nombre as cargo,dep_nombre as departamento FROM ssjc_colbab AS colaborador INNER JOIN ssjc_colabcargo AS cargo ON  colaborador.colab_cargo = cargo.cargo_id INNER JOIN ssjc_departamento AS depa ON colaborador.colab_departamento = depa.dep_id order by  colab_id asc;", "ssjc_colbab");
            return data;
        }

        //TRAER RECIDENTES
        public int getNumeroDeResidentes()
        {
            DataSet date = conexion.buscar("select count(user_id) as ncolaboradores from ssjc_user", "ssjc_user");
            return Convert.ToInt32(date.Tables[0].Rows[0]["ncolaboradores"]);
        }
        public DataSet getTodosUsuarios()
        {
            DataSet data = conexion.buscar("SELECT user_id as ndoc,user_name as nombre, user_lastname as apellido,user_email as correo FROM ssjc_user as usuario order by  user_id asc;", "ssjc_user");
            return data;
        }


        //VER, CREAR, ACTUALIZAR, ELIMINAR COLABORADORES
        public DataSet getInfoColaborador(int idc)
        {
            DataSet data = conexion.buscar("select colab_typeDocmuent as doc, colab_numeroIdent as ndoc ,colab_name as nombre,colab_lastname as apellido,colab_celular as telefono,colab_email as correo,colab_password as pass,colab_cargo as cargo,colab_rol as rol,colab_departamento as dep from ssjc_colbab where colab_id =" + idc, "ssjc_colbab");
            return data;
        }
        public void setNuevoColaborador(string doc, string ndoc, string nombre, string apellido, string telefono, string correo, string pass, int cargo, int rol, int depa)
        {
            conexion.Insertar("insert into ssjc_colbab(colab_typeDocmuent,colab_numeroIdent,colab_name,colab_lastname,colab_celular,colab_email,colab_password,colab_cargo,colab_rol,colab_departamento) values('" + v.CadenasValidacion(doc) + "','" + v.CadenasValidacion(ndoc) + "','" + v.CadenasValidacion(nombre) + "','" + v.CadenasValidacion(apellido) + "','" + v.CadenasValidacion(telefono) + "','" + v.CadenasValidacion(correo) + "','" + v.CadenasValidacion(pass) + "'," + cargo + "," + rol + "," + depa + ")");
        }
        public void updateColaborador(int idC, string doc, string ndoc, string nombre, string apellido, string telefono, string correo, string pass, int cargo, int rol, int depa)
        {
            conexion.Insertar("UPDATE ssjc_colbab SET colab_typeDocmuent ='" + v.CadenasValidacion(doc) + "' ,colab_numeroIdent = '" + v.CadenasValidacion(ndoc) + "' , colab_name = '" + v.CadenasValidacion(nombre) + "' , colab_lastname = '" + v.CadenasValidacion(apellido) + "' , colab_celular = '" + v.CadenasValidacion(telefono) + "' , colab_email = '" + v.CadenasValidacion(correo) + "' , colab_password = '" + v.CadenasValidacion(pass) + "' , colab_cargo = " + cargo + ", colab_rol = " + rol + " , colab_departamento = " + depa + " WHERE colab_id =" + idC);
        }
        public void delColaborador(int id)
        {
            conexion.Insertar("DELETE FROM ssjc_colbab WHERE colab_id =" + id);

        }

        //LISTAS PARA CREAR COLABORADORES
        public DataSet getRoles()
        {
            DataSet data = conexion.buscar("select rol_id as id, rol_nombre as nombre from ssjc_colabrol", "ssjc_colabrol");
            return data;
        }
        public DataSet getDepartamentos()
        {
            DataSet data = conexion.buscar("select dep_id as id,dep_nombre as nombre from ssjc_departamento;", "ssjc_departamento");
            return data;
        }
        public DataSet getCargos()
        {
            DataSet data = conexion.buscar("select cargo_id as id,cargo_nombre as nombre from ssjc_colabcargo;", "ssjc_colabcargo");
            return data;
        }
    }
}