using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDReferidos : Configuraciones
    {
        public void Sp_AlmacenarReferidos(int RowIdEmpleado, long Documento, string NombreCompleto, string Telefono, string Correo)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_AlmacenarReferidos";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("RowIdEmpleado", RowIdEmpleado);
            _SqlCommand.Parameters.AddWithValue("Documento", Documento);
            _SqlCommand.Parameters.AddWithValue("NombreCompleto", NombreCompleto);
            _SqlCommand.Parameters.AddWithValue("Telefono", Telefono);
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

        public void Sp_ActualizarReferidos(int RowId, int RowIdEmpleado, long Documento, string NombreCompleto, string Telefono, 
            string Correo, bool Usado)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ActualizarReferidos";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("RowId", RowId);
            _SqlCommand.Parameters.AddWithValue("RowIdEmpleado", RowIdEmpleado);
            _SqlCommand.Parameters.AddWithValue("Documento", Documento);
            _SqlCommand.Parameters.AddWithValue("NombreCompleto", NombreCompleto);
            _SqlCommand.Parameters.AddWithValue("Telefono", Telefono);
            _SqlCommand.Parameters.AddWithValue("Correo", Correo);
            _SqlCommand.Parameters.AddWithValue("Usado", Usado);

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

        public void Sp_EliminarReferidos(int RowId)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_EliminarReferidos";
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

        public DataSet Sp_ConsultarReferidosPorDocumento(long Documento)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            DataSet DsGenerico = new DataSet();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ConsultarReferidosPorDocumento";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("Documento", Documento);

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

        public DataSet Sp_ConsultarReferidosPorRowId(int RowId)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            DataSet DsGenerico = new DataSet();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ConsultarReferidosPorRowId";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("RowId", RowId);

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

        public DataSet Sp_ListadoReferidosPorEmpleado(int RowIdEmpleado)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            DataSet DsGenerico = new DataSet();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ListadoReferidosPorEmpleado";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("RowIdEmpleado", RowIdEmpleado);

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
