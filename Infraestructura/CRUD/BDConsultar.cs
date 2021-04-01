using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDConsultar : Configuraciones
    {
        public DataSet Query(string NombreProcedimiento)
        {

            SqlConnection SqlConnection = new SqlConnection(Conexion); 
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            SqlCommand _SqlCommand = new SqlCommand();
            DataSet DsGenerico = new DataSet();

            _SqlCommand.Connection = SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = NombreProcedimiento;
            _SqlCommand.CommandTimeout = 999999999;
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
