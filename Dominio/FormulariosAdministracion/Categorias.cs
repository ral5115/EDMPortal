using Dominio.Modelos;
using System.Data;

namespace Dominio.FormulariosAdministracion
{
    public class Categorias
    {
        Infraestructura.CRUD.BDConsultar _BDConsultar = new Infraestructura.CRUD.BDConsultar();
        Infraestructura.CRUD.BDCategorias _BDCategorias = new Infraestructura.CRUD.BDCategorias();

        public DataSet Consultar()
        {
            return _BDConsultar.Query("Sp_ListadoCategorias");
        }

        public void Insertar(ModeloCategoria Modelo)
        {
            _BDCategorias.Sp_AlmacenarCategorias(
                Modelo.CodigoGeneroERP == null ? string.Empty : Modelo.CodigoGeneroERP,
                Modelo.CodigoCategoriaERP == null ? string.Empty : Modelo.CodigoCategoriaERP,
                Modelo.DescripcionERP == null ? string.Empty : Modelo.DescripcionERP,
                Modelo.Pilatos == null ? string.Empty : Modelo.Pilatos,
                Modelo.Diesel == null ? string.Empty : Modelo.Diesel,
                Modelo.Replay == null ? string.Empty : Modelo.Replay,
                Modelo.SuperDry == null ? string.Empty : Modelo.SuperDry,
                Modelo.Kipling == null ? string.Empty : Modelo.Kipling,
                Modelo.Girbaud == null ? string.Empty : Modelo.Girbaud);
        }

        public void Actualizar(ModeloCategoria Modelo)
        {
            _BDCategorias.Sp_ActualizarCategorias(Modelo.RowId,
                Modelo.CodigoGeneroERP == null ? string.Empty : Modelo.CodigoGeneroERP,
                Modelo.CodigoCategoriaERP == null ? string.Empty : Modelo.CodigoCategoriaERP,
                Modelo.DescripcionERP == null ? string.Empty : Modelo.DescripcionERP,
                Modelo.Pilatos == null ? string.Empty : Modelo.Pilatos,
                Modelo.Diesel == null ? string.Empty : Modelo.Diesel,
                Modelo.Replay == null ? string.Empty : Modelo.Replay,
                Modelo.SuperDry == null ? string.Empty : Modelo.SuperDry,
                Modelo.Kipling == null ? string.Empty : Modelo.Kipling,
                Modelo.Girbaud == null ? string.Empty : Modelo.Girbaud);
        }

        public void Eliminar(int RowId)
        {
            _BDCategorias.Sp_EliminarCategorias(RowId);
        }

        public ModeloCategoria EnviarModelo(int RowId)
        {
            DataSet DsGenerico = _BDCategorias.Sp_ConsultarCategorias(RowId);

            ModeloCategoria Modelo = new ModeloCategoria();

            Modelo.RowId = (int)DsGenerico.Tables[0].Rows[0]["RowId"];
            Modelo.CodigoGeneroERP = DsGenerico.Tables[0].Rows[0]["CodigoGeneroERP"].ToString();
            Modelo.CodigoCategoriaERP = DsGenerico.Tables[0].Rows[0]["CodigoCategoriaERP"].ToString();
            Modelo.DescripcionERP = DsGenerico.Tables[0].Rows[0]["DescripcionERP"].ToString();
            Modelo.Pilatos = DsGenerico.Tables[0].Rows[0]["Pilatos"].ToString();
            Modelo.Diesel = DsGenerico.Tables[0].Rows[0]["Diesel"].ToString();
            Modelo.Replay = DsGenerico.Tables[0].Rows[0]["Replay"].ToString();
            Modelo.SuperDry = DsGenerico.Tables[0].Rows[0]["SuperDry"].ToString();
            Modelo.Kipling = DsGenerico.Tables[0].Rows[0]["Kipling"].ToString();
            Modelo.Girbaud = DsGenerico.Tables[0].Rows[0]["Girbaud"].ToString();

            return Modelo;
        }
    }
}
