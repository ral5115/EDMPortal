using System.Data;

namespace Dominio.FormulariosAdministracion
{
    public class Permisos
    {
        Infraestructura.CRUD.BDConsultar _BDConsultar = new Infraestructura.CRUD.BDConsultar();
        Infraestructura.CRUD.BDPermisos _BDPermisos = new Infraestructura.CRUD.BDPermisos();

        public DataSet Consultar()
        {
            return _BDConsultar.Query("Sp_ListadoPermisos");
        }

        public void Actualizar(int RowId, string Campo, bool Visible)
        {
            _BDPermisos.Sp_ActualizarPermisos(RowId, Campo, Visible);
        }
    }
}
