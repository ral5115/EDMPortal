using Dominio.Modelos;
using System.Data;

namespace Dominio.FormulariosAdministracion
{
    public class Usuarios
    {
        Infraestructura.CRUD.BDConsultar _BDConsultar = new Infraestructura.CRUD.BDConsultar();
        Infraestructura.CRUD.BDUsuarios _BDUsuarios = new Infraestructura.CRUD.BDUsuarios();

        public DataSet Consultar()
        {
            return _BDConsultar.Query("Sp_ListadoUsuarios");
        }

        public void Insertar(ModeloUsuario Modelo)
        {
            _BDUsuarios.Sp_AlmacenarUsuarios(Modelo.Documento, Modelo.Usuario, Modelo.Clave,
                Modelo.NombreCompleto, Modelo.IdPerfil, Modelo.Correo == null ? string.Empty : Modelo.Correo);
        }

        public void Actualizar(ModeloUsuario Modelo)
        {
            _BDUsuarios.Sp_ActualizarUsuarios(Modelo.RowId, Modelo.Documento, Modelo.Usuario, Modelo.Clave,
                Modelo.NombreCompleto, Modelo.IdPerfil, Modelo.Correo == null ? string.Empty : Modelo.Correo);
        }

        public void Eliminar(int RowId)
        {
            _BDUsuarios.Sp_EliminarUsuarios(RowId);
        }

        public string ValidarUsuario(string Usuario)
        {
            DataSet DsGenerico = _BDUsuarios.Sp_ConsultarUsuarios(0, Usuario);

            if (DsGenerico.Tables[0].Rows.Count > 0)
            {
                return "EXISTE";
            }
            return "";
        }

        public ModeloUsuario EnviarModelo(int RowId)
        {
            DataSet DsGenerico = _BDUsuarios.Sp_ConsultarUsuarios(RowId, "");

            ModeloUsuario Modelo = new ModeloUsuario();

            Modelo.RowId = (int)DsGenerico.Tables[0].Rows[0]["RowId"];
            Modelo.IdPerfil = (int)DsGenerico.Tables[0].Rows[0]["RowId_Perfil"];
            Modelo.Documento = DsGenerico.Tables[0].Rows[0]["Documento"].ToString();
            Modelo.Usuario = DsGenerico.Tables[0].Rows[0]["Usuario"].ToString();
            Modelo.Clave = DsGenerico.Tables[0].Rows[0]["Clave"].ToString();
            Modelo.NombreCompleto = DsGenerico.Tables[0].Rows[0]["NombreCompleto"].ToString();
            Modelo.Correo = DsGenerico.Tables[0].Rows[0]["Correo"].ToString();

            return Modelo;
        }
    }
}
