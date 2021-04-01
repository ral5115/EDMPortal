using Dominio.Modelos;
using System;
using System.Data;

namespace Dominio.FormulariosPublicos
{
    public class Referidos
    {
        Infraestructura.CRUD.BDConsultar _BDConsultar = new Infraestructura.CRUD.BDConsultar();
        Infraestructura.CRUD.BDReferidos _BDReferidos = new Infraestructura.CRUD.BDReferidos();

        public DataSet Consultar()
        {
            return _BDConsultar.Query("Sp_ListadoReferidos");
        }

        public DataSet Consultar(int RowIdEmpleado)
        {
            return _BDReferidos.Sp_ListadoReferidosPorEmpleado(RowIdEmpleado);
        }

        public void Insertar(int RowIdEmpleado, ModeloReferido Modelo)
        {
            _BDReferidos.Sp_AlmacenarReferidos(RowIdEmpleado, Modelo.Documento, Modelo.NombreCompleto,
                Modelo.Telefono, Modelo.Correo);
        }

        public void Actualizar(int RowIdEmpleado, ModeloReferido Modelo)
        {
            _BDReferidos.Sp_ActualizarReferidos(Modelo.RowId, RowIdEmpleado, Modelo.Documento, Modelo.NombreCompleto,
                Modelo.Telefono, Modelo.Correo, Modelo.Usado);
        }

        public void Eliminar(int RowId)
        {
            _BDReferidos.Sp_EliminarReferidos(RowId);
        }

        public string ValidarReferido(long Documento)
        {
            DataSet DsGenerico = _BDReferidos.Sp_ConsultarReferidosPorDocumento(Documento);

            if (DsGenerico.Tables[0].Rows.Count > 0)
            {
                return "EXISTE";
            }
            return "";
        }

        public ModeloReferido EnviarModelo(int RowId)
        {
            DataSet DsGenerico = _BDReferidos.Sp_ConsultarReferidosPorRowId(RowId);

            ModeloReferido Modelo = new ModeloReferido();

            Modelo.RowId = Convert.ToInt32(DsGenerico.Tables[0].Rows[0]["RowId"]);
            Modelo.RowIdEmpleado = Convert.ToInt32(DsGenerico.Tables[0].Rows[0]["RowIdEmpleado"]);
            Modelo.Empleado = DsGenerico.Tables[0].Rows[0]["Empleado"].ToString();
            Modelo.Documento = Convert.ToInt64(DsGenerico.Tables[0].Rows[0]["Documento"]);
            Modelo.NombreCompleto = DsGenerico.Tables[0].Rows[0]["Referido"].ToString();
            Modelo.Telefono = DsGenerico.Tables[0].Rows[0]["Telefono"].ToString();
            Modelo.Correo = DsGenerico.Tables[0].Rows[0]["Correo"].ToString();
            Modelo.Usado = Convert.ToBoolean(DsGenerico.Tables[0].Rows[0]["Usado"]);

            return Modelo;
        }
    }
}
