using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace sjc
{
    public class cConexion
    {

       protected MySql.Data.MySqlClient.MySqlConnection conMysql;
       protected MySql.Data.MySqlClient.MySqlCommand comMysql;
       private String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["mysql"].ToString();

        public DataSet buscar(String strSQL, String tabla)
        {
            DataSet ds = new DataSet();
            try
            {
                conMysql = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                conMysql.Open();
                MySql.Data.MySqlClient.MySqlDataAdapter daSQL = new MySql.Data.MySqlClient.MySqlDataAdapter(strSQL, conMysql);
                daSQL.Fill(ds, tabla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conMysql.Close();
            }
            return ds;
        }

        public void Insertar(String strsql)
        {
            try
            {

                conMysql = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                conMysql.Open();
                comMysql = new MySql.Data.MySqlClient.MySqlCommand(strsql, conMysql);
                comMysql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conMysql.Close();
            }
        }

        public double escalar_double(String strsql)
        {
            try
            {
                conMysql = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                conMysql.Open();
                MySql.Data.MySqlClient.MySqlCommand cmsSQL = new MySql.Data.MySqlClient.MySqlCommand(strsql, conMysql);
                return Convert.ToDouble(cmsSQL.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conMysql.Close();
            }
        }

        public Int64 escalar_entero(String strsql)
        {
            try
            {
                conMysql = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                conMysql.Open();
                MySql.Data.MySqlClient.MySqlCommand cmsSQL = new MySql.Data.MySqlClient.MySqlCommand(strsql, conMysql);
                return Convert.ToInt64(cmsSQL.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conMysql.Close();
            }
        }



    }
}