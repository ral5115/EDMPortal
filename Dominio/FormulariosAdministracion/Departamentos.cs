using Dominio.Modelos;
using System.Data;

namespace Dominio.FormulariosAdministracion
{
    public class Departamentos
    {
        Infraestructura.CRUD.BDConsultar _BDConsultar = new Infraestructura.CRUD.BDConsultar();
        Infraestructura.CRUD.BDDepartamentos _BDDepartamentos = new Infraestructura.CRUD.BDDepartamentos();

        public DataSet Consultar()
        {
            return _BDConsultar.Query("Sp_ListadoDepartamentos");
        }

        public void Insertar(ModeloDepartamento Modelo)
        {
            _BDDepartamentos.Sp_AlmacenarDepartamentos(
                Modelo.CodigoERP == null ? string.Empty : Modelo.CodigoERP,
                Modelo.DescripcionERP == null ? string.Empty : Modelo.DescripcionERP,
                Modelo.Pilatos == null ? string.Empty : Modelo.Pilatos,
                Modelo.Diesel == null ? string.Empty : Modelo.Diesel,
                Modelo.Replay == null ? string.Empty : Modelo.Replay,
                Modelo.SuperDry == null ? string.Empty : Modelo.SuperDry,
                Modelo.Kipling == null ? string.Empty : Modelo.Kipling,
                Modelo.Girbaud == null ? string.Empty : Modelo.Girbaud);
        }

        public void Actualizar(ModeloDepartamento Modelo)
        {
            _BDDepartamentos.Sp_ActualizarDepartamentos(Modelo.RowId,
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
            _BDDepartamentos.Sp_EliminarDepartamentos(RowId);
        }

        public ModeloDepartamento EnviarModelo(int RowId)
        {
            DataSet DsGenerico = _BDDepartamentos.Sp_ConsultarDepartamentos(RowId);

            ModeloDepartamento Modelo = new ModeloDepartamento();

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
