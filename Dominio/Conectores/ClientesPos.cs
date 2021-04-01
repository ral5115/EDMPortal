using Infraestructura;
using System;
using System.Data;

namespace Dominio.Conectores
{
    public class ClientesPos : Configuraciones
    {
        Infraestructura.CRUD.BDConsultar _BDConsultar = new Infraestructura.CRUD.BDConsultar();
        Infraestructura.CRUD.BDClientesPos _BDClientesPos = new Infraestructura.CRUD.BDClientesPos();
        Recursos.Deserealizar _Deserealizar = new Recursos.Deserealizar();

        public string Importar(string Documento)
        {
            try
            {
                var RutaPlano = RutaPlanoReal;
                var Respuesta = _WebServiceGTReal.ImportarDatosDS(7800,
                           "clientespos1", 2, "1", "gt", "gt",
                           _BDClientesPos.Sp_ConsultarClientePosPorDocumento(Documento), ref RutaPlano);

                return _Deserealizar.XML(Respuesta);
            }
            catch (Exception Ex)
            {
                return Ex.Message.ToString();
            }
        }

        public void Importar()
        {
            try
            {
                DataSet DsClientes = _BDConsultar.Query("Sp_ListadoClientesHabeasData");

                if (DsClientes.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow Registro in DsClientes.Tables[0].Rows)
                    {
                        var Respuesta = Importar(Registro["Documento"].ToString());

                        if (Respuesta == "Importacion exitosa")
                        {
                            _BDClientesPos.Sp_ActualizarCampo("HabeasData", Registro["Documento"].ToString());
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                var Mensaje = Ex.Message.ToString();
            }
        }
    }
}
