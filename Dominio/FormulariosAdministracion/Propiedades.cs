using Dominio.Modelos;
using System.Data;

namespace Dominio.FormulariosAdministracion
{
    public class Propiedades
    {
        Infraestructura.CRUD.BDConsultar _BDConsultar = new Infraestructura.CRUD.BDConsultar();
        Infraestructura.CRUD.BDPropiedades _BDPropiedades = new Infraestructura.CRUD.BDPropiedades();

        public DataSet Consultar()
        {
            return _BDConsultar.Query("Sp_ListadoPropiedades");
        }

        public string Insertar(ModeloPropiedad Modelo)
        {
            if (_BDPropiedades.Sp_ValidarPropiedad(Modelo.Nombre).Tables[0].Rows.Count > 0)
            {
                return "EXISTE";
            }
            else
            {
                _BDPropiedades.Sp_AlmacenarPropiedades(Modelo.Nombre, Modelo.Valor);
                return "";
            }
        }

        public void Actualizar(ModeloPropiedad Modelo)
        {
            _BDPropiedades.Sp_ActualizarPropiedades(Modelo.RowId, Modelo.Nombre, Modelo.Valor);
        }

        public void Eliminar(int RowId)
        {
            _BDPropiedades.Sp_EliminarPropiedades(RowId);
        }

        public ModeloPropiedad EnviarModelo(int RowId)
        {
            DataSet DsGenerico = _BDPropiedades.Sp_ConsultarPropiedades(RowId);

            ModeloPropiedad Modelo = new ModeloPropiedad();

            Modelo.RowId = (int)DsGenerico.Tables[0].Rows[0]["RowId"];
            Modelo.Nombre = DsGenerico.Tables[0].Rows[0]["Nombre"].ToString();
            Modelo.Valor = DsGenerico.Tables[0].Rows[0]["Valor"].ToString();

            return Modelo;
        }
    }
}
