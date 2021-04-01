using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDPermisos : Configuraciones
    {
        public void Sp_ActualizarPermisos(int RowId, string Campo, bool Visible)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();

            var Query = "UPDATE Permisos SET " + Campo + " = " + "'" + Visible + "'" + " WHERE Rowid = " + "'" + RowId + "'";

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
        }
    }
}
