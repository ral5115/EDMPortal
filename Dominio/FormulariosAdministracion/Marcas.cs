using Dominio.Modelos;
using System.Data;

namespace Dominio.FormulariosAdministracion
{
    public class Marcas
    {
        Infraestructura.CRUD.BDConsultar _BDConsultar = new Infraestructura.CRUD.BDConsultar();
        Infraestructura.CRUD.BDMarcas _BDMarcas = new Infraestructura.CRUD.BDMarcas();

        public DataSet Consultar()
        {
            return _BDConsultar.Query("Sp_ListadoMarcas");
        }

        public void Insertar(ModeloMarca Modelo)
        {
            _BDMarcas.Sp_AlmacenarMarcas(
                Modelo.CodigoERP == null ? string.Empty : Modelo.CodigoERP,
                Modelo.DescripcionERP == null ? string.Empty : Modelo.DescripcionERP,
                Modelo.Pilatos == null ? string.Empty : Modelo.Pilatos,
                Modelo.Diesel == null ? string.Empty : Modelo.Diesel,
                Modelo.Replay == null ? string.Empty : Modelo.Replay,
                Modelo.SuperDry == null ? string.Empty : Modelo.SuperDry,
                Modelo.Kipling == null ? string.Empty : Modelo.Kipling,
                Modelo.Girbaud == null ? string.Empty : Modelo.Girbaud);
        }

        public void Actualizar(ModeloMarca Modelo)
        {
            _BDMarcas.Sp_ActualizarMarcas(Modelo.RowId,
                 Modelo.CodigoERP == null ? string.Empty : Modelo.CodigoERP,
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
            _BDMarcas.Sp_EliminarMarcas(RowId);
        }

        public ModeloMarca EnviarModelo(int RowId)
        {
            DataSet DsGenerico = _BDMarcas.Sp_ConsultarMarcas(RowId);

            ModeloMarca Modelo = new ModeloMarca();

            Modelo.RowId = (int)DsGenerico.Tables[0].Rows[0]["RowId"];
            Modelo.CodigoERP = DsGenerico.Tables[0].Rows[0]["CodigoERP"].ToString();
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
