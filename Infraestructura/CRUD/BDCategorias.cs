using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDCategorias : Configuraciones
    {
        public DataSet Sp_ConsultarCategorias(int RowId)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            DataSet DsGenerico = new DataSet();

            try
            {
                _SqlCommand.Connection = _SqlConnection;
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.CommandText = "Sp_ConsultarCategorias";

                _SqlCommand.Parameters.AddWithValue("RowId", RowId);

                _SqlDataAdapter.SelectCommand = _SqlCommand;
                _SqlDataAdapter.Fill(DsGenerico);

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

            return DsGenerico;
        }

        public void Sp_AlmacenarCategorias(string CodigoGeneroERP, string CodigoCategoriaERP, string DescripcionERP, string Pilatos, string Diesel,
            string Replay, string SuperDry, string Kipling, string Girbaud)
        {
            SqlConnection SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();

            _SqlCommand.Connection = SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_AlmacenarCategorias";

            _SqlCommand.Parameters.AddWithValue("CodigoGeneroERP", CodigoGeneroERP);
            _SqlCommand.Parameters.AddWithValue("CodigoCategoriaERP", CodigoCategoriaERP);
            _SqlCommand.Parameters.AddWithValue("DescripcionERP", DescripcionERP);
            _SqlCommand.Parameters.AddWithValue("Pilatos", Pilatos);
            _SqlCommand.Parameters.AddWithValue("Diesel", Diesel);
            _SqlCommand.Parameters.AddWithValue("Replay", Replay);
            _SqlCommand.Parameters.AddWithValue("SuperDry", SuperDry);
            _SqlCommand.Parameters.AddWithValue("Kipling", Kipling);
            _SqlCommand.Parameters.AddWithValue("Girbaud", Girbaud);

            try
            {
                _SqlCommand.Connection.Open();
                _SqlCommand.ExecuteNonQuery();
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

        public void Sp_ActualizarCategorias(int RowId, string CodigoGeneroERP, string CodigoCategoriaERP, string DescripcionERP, string Pilatos, string Diesel,
            string Replay, string SuperDry, string Kipling, string Girbaud)
        {
            SqlConnection SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();

            _SqlCommand.Connection = SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ActualizarCategorias";

            _SqlCommand.Parameters.AddWithValue("RowId", RowId);
            _SqlCommand.Parameters.AddWithValue("CodigoGeneroERP", CodigoGeneroERP);
            _SqlCommand.Parameters.AddWithValue("CodigoCategoriaERP", CodigoCategoriaERP);
            _SqlCommand.Parameters.AddWithValue("DescripcionERP", DescripcionERP);
            _SqlCommand.Parameters.AddWithValue("Pilatos", Pilatos);
            _SqlCommand.Parameters.AddWithValue("Diesel", Diesel);
            _SqlCommand.Parameters.AddWithValue("Replay", Replay);
            _SqlCommand.Parameters.AddWithValue("SuperDry", SuperDry);
            _SqlCommand.Parameters.AddWithValue("Kipling", Kipling);
            _SqlCommand.Parameters.AddWithValue("Girbaud", Girbaud);

            try
            {
                _SqlCommand.Connection.Open();
                _SqlCommand.ExecuteNonQuery();
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

        public void Sp_EliminarCategorias(int RowId)
        {
            SqlConnection SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();

            _SqlCommand.Connection = SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_EliminarCategorias";
            _SqlCommand.Parameters.AddWithValue("RowId", RowId);

            try
            {
                _SqlCommand.Connection.Open();
                _SqlCommand.ExecuteNonQuery();
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
