using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDLogin: Configuraciones
    {
        public DataSet Sp_ValidarAutenticacion(string Usuario, string Clave)
        {
            SqlConnection SqlConnection = new SqlConnection(Conexion);
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            SqlCommand _SqlCommand = new SqlCommand();
            DataSet DsGenerico = new DataSet();

            _SqlCommand.Connection = SqlConnection;
            _SqlCommand.Connection = SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ValidarAutenticacion";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("Usuario", Usuario);
            _SqlCommand.Parameters.AddWithValue("Clave", Clave);
            _SqlDataAdapter.SelectCommand = _SqlCommand;

            try
            {
                _SqlCommand.Connection.Open();
                _SqlCommand.ExecuteNonQuery();
                _SqlDataAdapter.Fill(DsGenerico);
                return DsGenerico;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _SqlCommand.Connection.Close();
            }
        }

        public DataSet Sp_ListadoMenu(int RowId_Perfil)
        {
            SqlConnection SqlConnection = new SqlConnection(Conexion);
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            SqlCommand _SqlCommand = new SqlCommand();
            DataSet DsGenerico = new DataSet();

            _SqlCommand.Connection = SqlConnection;
            _SqlCommand.Connection = SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ListadoMenu";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("RowId_Perfil", RowId_Perfil);
            _SqlDataAdapter.SelectCommand = _SqlCommand;

            try
            {
                _SqlCommand.Connection.Open();
                _SqlCommand.ExecuteNonQuery();
                _SqlDataAdapter.Fill(DsGenerico);
                return DsGenerico;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _SqlCommand.Connection.Close();
            }
        }

        public DataSet Sp_ListadoSubMenu(int RowId_Perfil, int RowId_Munu)
        {
            SqlConnection SqlConnection = new SqlConnection(Conexion);
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            SqlCommand _SqlCommand = new SqlCommand();
            DataSet DsGenerico = new DataSet();

            _SqlCommand.Connection = SqlConnection;
            _SqlCommand.Connection = SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ListadoSubMenu";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("RowId_Perfil", RowId_Perfil);
            _SqlCommand.Parameters.AddWithValue("RowId_Munu", RowId_Munu);
            _SqlDataAdapter.SelectCommand = _SqlCommand;

            try
            {
                _SqlCommand.Connection.Open();
                _SqlCommand.ExecuteNonQuery();
                _SqlDataAdapter.Fill(DsGenerico);
                return DsGenerico;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _SqlCommand.Connection.Close();
            }
        }
    }
}
