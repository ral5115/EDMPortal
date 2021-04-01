using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDUsuarios : Configuraciones
    {
        public void Sp_AlmacenarUsuarios(string Documento, string Usuario, string Clave,
            string NombreCompleto, int IdPerfil, string Correo)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_AlmacenarUsuarios";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("Documento", Documento);
            _SqlCommand.Parameters.AddWithValue("Usuario", Usuario);
            _SqlCommand.Parameters.AddWithValue("Clave", Clave);
            _SqlCommand.Parameters.AddWithValue("NombreCompleto", NombreCompleto);
            _SqlCommand.Parameters.AddWithValue("IdPerfil", IdPerfil);
            _SqlCommand.Parameters.AddWithValue("Correo", Correo);

            try
            {
                _SqlCommand.Connection.Open();
                _SqlCommand.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Sp_ActualizarUsuarios(int RowId, string Documento, string Usuario, string Clave,
            string NombreCompleto, int IdPerfil, string Correo)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ActualizarUsuarios";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("RowId", RowId);
            _SqlCommand.Parameters.AddWithValue("Documento", Documento);
            _SqlCommand.Parameters.AddWithValue("Usuario", Usuario);
            _SqlCommand.Parameters.AddWithValue("Clave", Clave);
            _SqlCommand.Parameters.AddWithValue("NombreCompleto", NombreCompleto);
            _SqlCommand.Parameters.AddWithValue("IdPerfil", IdPerfil);
            _SqlCommand.Parameters.AddWithValue("Correo", Correo);

            try
            {
                _SqlCommand.Connection.Open();
                _SqlCommand.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Sp_EliminarUsuarios(int RowId)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_EliminarUsuarios";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("RowId", RowId);

            try
            {
                _SqlCommand.Connection.Open();
                _SqlCommand.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataSet Sp_ConsultarUsuarios(int RowId, string Usuario)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            DataSet DsGenerico = new DataSet();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ConsultarUsuarios";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("RowId", RowId);
            _SqlCommand.Parameters.AddWithValue("Usuario", Usuario);

            try
            {
                _SqlDataAdapter.SelectCommand = _SqlCommand;
                _SqlDataAdapter.Fill(DsGenerico);
                return DsGenerico;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                _SqlCommand.Parameters.Clear();
                _SqlCommand.Connection.Close();
            }
        }
    }
}
