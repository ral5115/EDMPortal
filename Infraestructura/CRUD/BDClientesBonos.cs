using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDClientesBonos  : Configuraciones
    {
        public void Sp_AlmacenarClientesBonos(string IdCentroOperacion, string DescripcionCentroOperacion, string TipoDocumento,
            string Consecutivo, string Valor, string DocumentoCliente, string NombreCliente, string CorreoCliente, string FechaPedido,
            string CantidadBonos, string ValorBonos, string ConjuntoBonos, string UltimoBono, string Html, string Resultado)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_AlmacenarClientesBonos";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("IdCentroOperacion", IdCentroOperacion);
            _SqlCommand.Parameters.AddWithValue("DescripcionCentroOperacion", DescripcionCentroOperacion);
            _SqlCommand.Parameters.AddWithValue("TipoDocumento", TipoDocumento);
            _SqlCommand.Parameters.AddWithValue("Consecutivo", Consecutivo);
            _SqlCommand.Parameters.AddWithValue("Valor", Valor);
            _SqlCommand.Parameters.AddWithValue("DocumentoCliente", DocumentoCliente);
            _SqlCommand.Parameters.AddWithValue("NombreCliente", NombreCliente);
            _SqlCommand.Parameters.AddWithValue("CorreoCliente", CorreoCliente);
            _SqlCommand.Parameters.AddWithValue("FechaPedido", FechaPedido);
            _SqlCommand.Parameters.AddWithValue("CantidadBonos", CantidadBonos);
            _SqlCommand.Parameters.AddWithValue("ValorBonos", ValorBonos);
            _SqlCommand.Parameters.AddWithValue("ConjuntoBonos", ConjuntoBonos);
            _SqlCommand.Parameters.AddWithValue("UltimoBono", UltimoBono);
            _SqlCommand.Parameters.AddWithValue("Html", Html);
            _SqlCommand.Parameters.AddWithValue("Resultado", Resultado);

            try
            {
                _SqlCommand.Connection.Open();
                _SqlCommand.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                var Mensaje = Ex.Message.ToString();
            }
            finally
            {
                _SqlCommand.Connection.Close();
            }
        }

        public void Sp_ActualizarClientesBonos(int RowId, bool Usado)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ActualizarClientesBonos";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("RowId", RowId);
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

        public void Sp_ActualizarReenvioCorreo(string DocumentoCliente, string ConjuntoBonos)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ActualizarReenvioCorreo";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("DocumentoCliente", DocumentoCliente);
            _SqlCommand.Parameters.AddWithValue("ConjuntoBonos", ConjuntoBonos);

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

        public DataSet Sp_ValidarCodigoBono(string Marca)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            DataSet DsGenerico = new DataSet();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ValidarCodigoBono";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("Marca", Marca);

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

        public DataSet Sp_ConsultarClientesBonos(int RowId)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            DataSet DsGenerico = new DataSet();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ConsultarClientesBonos";
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

        public void Sp_EliminarClientesBonos(int RowId)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_EliminarClientesBonos";
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
    }
}
