using Infraestructura.Properties;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDCompania: Configuraciones
    {

        public void Sp_ActualizarCompania(int RowId, string DC_Nit, string DC_RazonSocial, string DC_NombreUsuario,
             string DC_Direccion, string DC_Telefono, string DC_Correo, string DC_FechaCreacion, string EL_FondoPantallaLogin,
             string EL_FondoLogin, string EL_TextoLogin, string EL_ColorTextoLogin, string EL_ColorIconoLogin, string EL_ColorBotonLogin,
             string EL_ColorBotonTextoLogin, string EL_UrlFondo, string EP_TextoEmpresa, string EP_ColorFondoEmpresa, string EP_ColorTextoEmpresa,
             string EP_ColorFondoNavbar, string EP_ColorFondoSiebar, string EP_ColorFondoCentral, string EP_ColorFondoAdministracion,
             string EP_ColorTextoBotones, string EP_ColorBotonConsultar, string EP_ColorBotonInsertar, string EP_ColorBotonActualizar
             , string EP_ColorBotonEliminar, string EP_ColorBotonRegresar, string EP_UrlFondo)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ActualizarCompania";
            _SqlCommand.CommandTimeout = 999999999;

            _SqlCommand.Parameters.AddWithValue("RowId", RowId);
            _SqlCommand.Parameters.AddWithValue("DC_Nit", DC_Nit);
            _SqlCommand.Parameters.AddWithValue("DC_RazonSocial", DC_RazonSocial);
            _SqlCommand.Parameters.AddWithValue("DC_NombreUsuario", DC_NombreUsuario);
            _SqlCommand.Parameters.AddWithValue("DC_Direccion", DC_Direccion);
            _SqlCommand.Parameters.AddWithValue("DC_Telefono", DC_Telefono);
            _SqlCommand.Parameters.AddWithValue("DC_Correo", DC_Correo);
            _SqlCommand.Parameters.AddWithValue("DC_FechaCreacion", DC_FechaCreacion);
            _SqlCommand.Parameters.AddWithValue("EL_FondoPantallaLogin", EL_FondoPantallaLogin);
            _SqlCommand.Parameters.AddWithValue("EL_FondoLogin", EL_FondoLogin);
            _SqlCommand.Parameters.AddWithValue("EL_TextoLogin", EL_TextoLogin);
            _SqlCommand.Parameters.AddWithValue("EL_ColorTextoLogin", EL_ColorTextoLogin);
            _SqlCommand.Parameters.AddWithValue("EL_ColorIconoLogin", EL_ColorIconoLogin);
            _SqlCommand.Parameters.AddWithValue("EL_ColorBotonLogin", EL_ColorBotonLogin);
            _SqlCommand.Parameters.AddWithValue("EL_ColorBotonTextoLogin", EL_ColorBotonTextoLogin);
            _SqlCommand.Parameters.AddWithValue("EL_UrlFondo", EL_UrlFondo);
            _SqlCommand.Parameters.AddWithValue("EP_TextoEmpresa", EP_TextoEmpresa);
            _SqlCommand.Parameters.AddWithValue("EP_ColorFondoEmpresa", EP_ColorFondoEmpresa);
            _SqlCommand.Parameters.AddWithValue("EP_ColorTextoEmpresa", EP_ColorTextoEmpresa);
            _SqlCommand.Parameters.AddWithValue("EP_ColorFondoNavbar", EP_ColorFondoNavbar);
            _SqlCommand.Parameters.AddWithValue("EP_ColorFondoSiebar", EP_ColorFondoSiebar);
            _SqlCommand.Parameters.AddWithValue("EP_ColorFondoCentral", EP_ColorFondoCentral);
            _SqlCommand.Parameters.AddWithValue("EP_ColorFondoAdministracion", EP_ColorFondoAdministracion);
            _SqlCommand.Parameters.AddWithValue("EP_ColorTextoBotones", EP_ColorTextoBotones);
            _SqlCommand.Parameters.AddWithValue("EP_ColorBotonConsultar", EP_ColorBotonConsultar);
            _SqlCommand.Parameters.AddWithValue("EP_ColorBotonInsertar", EP_ColorBotonInsertar);
            _SqlCommand.Parameters.AddWithValue("EP_ColorBotonActualizar", EP_ColorBotonActualizar);
            _SqlCommand.Parameters.AddWithValue("EP_ColorBotonEliminar", EP_ColorBotonEliminar);
            _SqlCommand.Parameters.AddWithValue("EP_ColorBotonRegresar", EP_ColorBotonRegresar);
            _SqlCommand.Parameters.AddWithValue("EP_UrlFondo", EP_UrlFondo);

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

        public DataSet Sp_ConsultarCompania(int RowId)
        {
            SqlConnection _SqlConnection = new SqlConnection(Conexion);
            SqlCommand _SqlCommand = new SqlCommand();
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            DataSet DsGenerico = new DataSet();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = "Sp_ConsultarCompania";
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
    }
}
