using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDClientesPos: Configuraciones
    {
        public DataSet Sp_ListadoClientesPos(int RowIdUsuario)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            DataSet DsGenerico = new DataSet();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ListadoClientesPos";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("RowIdUsuario", RowIdUsuario);

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

        public string Sp_AlmacenarClientesPos(int RowId, string Documento, string RowIdTipoDocumento,
            string Nombre1, string Nombre2, string Apellido1, string Apellido2, string FechaNacimiento, string RH,
            string Direccion, string RowIdDepartamento, string RowIdCiudad, string Telefono, string Correo, string Celular,
            string RowIdSexo, int RowIdUsuario)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_AlmacenarClientesPos";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("RowId", RowId);
            _SqlCommand.Parameters.AddWithValue("Documento", Documento);
            _SqlCommand.Parameters.AddWithValue("RowIdTipoDocumento", RowIdTipoDocumento);
            _SqlCommand.Parameters.AddWithValue("Nombre1", Nombre1);
            _SqlCommand.Parameters.AddWithValue("Nombre2", Nombre2);
            _SqlCommand.Parameters.AddWithValue("Apellido1", Apellido1);
            _SqlCommand.Parameters.AddWithValue("Apellido2", Apellido2);
            _SqlCommand.Parameters.AddWithValue("FechaNacimiento", FechaNacimiento);
            _SqlCommand.Parameters.AddWithValue("RH", RH);
            _SqlCommand.Parameters.AddWithValue("Direccion", Direccion);
            _SqlCommand.Parameters.AddWithValue("RowIdDepartamento", RowIdDepartamento);
            _SqlCommand.Parameters.AddWithValue("RowIdCiudad", RowIdCiudad);
            _SqlCommand.Parameters.AddWithValue("Telefono", Telefono);
            _SqlCommand.Parameters.AddWithValue("Correo", Correo);
            _SqlCommand.Parameters.AddWithValue("Celular", Celular);
            _SqlCommand.Parameters.AddWithValue("RowIdSexo", RowIdSexo);
            _SqlCommand.Parameters.AddWithValue("RowIdUsuario", RowIdUsuario);

            try
            {
                _SqlCommand.Connection.Open();
                _SqlCommand.ExecuteNonQuery();
                return "Importacion exitosa";
            }
            catch (Exception Ex)
            {
                return Ex.Message.ToString();
            }
            finally
            {
                _SqlCommand.Connection.Close();
            }
        }

        public void Sp_EliminarClientesPos(int RowId)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_EliminarClientesPos";
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
            finally
            {
                _SqlCommand.Parameters.Clear();
                _SqlCommand.Connection.Close();
            }
        }

        public DataSet Sp_ConsultarClientesLocal(string Documento)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            DataSet DsGenerico = new DataSet();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ConsultarClientesLocal";
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

        public DataSet Sp_ConsultarClientesSiesa(string Documento)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            DataSet DsGenerico = new DataSet();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ConsultarClientesSiesa";
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

        public DataSet Sp_ListadoCiudades(string RowIdDepartamento)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            DataSet DsGenerico = new DataSet();

            try
            {
                _SqlCommand.Connection = _SqlConnection;
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.CommandText = "Sp_ListadoCiudades";
                _SqlCommand.Parameters.AddWithValue("RowIdDepartamento", RowIdDepartamento);

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

        public DataSet Sp_ConsultarClientePosPorDocumento(string Documento)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            DataSet DsGenerico = new DataSet();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ConsultarClientePosPorDocumento";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("Documento", Documento);

            try
            {
                _SqlDataAdapter.SelectCommand = _SqlCommand;
                _SqlDataAdapter.Fill(DsGenerico);
                DsGenerico.Tables[0].TableName = "Clientes_Pos";
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

        public DataSet Sp_ConsultarCampo(string Campo, string Documento)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            DataSet DsGenerico = new DataSet();

            var Query = "SELECT " + Campo + " FROM ClientesPos WHERE Documento = '" + Documento + "'";

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.Text;
            _SqlCommand.CommandText = Query;
            _SqlCommand.CommandTimeout = 999999999;

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
                _SqlCommand.Connection.Close();
            }
        }

        public void Sp_ActualizarCampo(string Campo, string Documento)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();

            var Query = "UPDATE ClientesPos SET " + Campo + " = 1 WHERE Documento = " + "'" + Documento + "'";

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.Text;
            _SqlCommand.CommandText = Query;
            _SqlCommand.CommandTimeout = 999999999;

            try
            {
                _SqlCommand.Connection.Open();
                _SqlCommand.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                _SqlCommand.Connection.Close();
            }
        }
    }
}
