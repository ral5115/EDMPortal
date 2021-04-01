using Dominio.Modelos;
using System;
using System.Data;

namespace Dominio.FormulariosPublicos
{
    public class ClientesBonos
    {
        Infraestructura.CRUD.BDConsultar _BDConsultar = new Infraestructura.CRUD.BDConsultar();
        Infraestructura.CRUD.BDClientesBonos _BDClientesBonos = new Infraestructura.CRUD.BDClientesBonos();
        Recursos.Correo _Correo = new Recursos.Correo();

        public DataSet Consultar()
        {
            return _BDConsultar.Query("Sp_ListadoClientesBonos");
        }

        public void Actualizar(ModeloClientesBonos Modelo)
        {
            _BDClientesBonos.Sp_ActualizarClientesBonos(Modelo.RowId, Modelo.Usado);
        }

        public void Eliminar(int RowId)
        {
            _BDClientesBonos.Sp_EliminarClientesBonos(RowId);
        }

        public void Procesar()
        {
            DataSet DsPedidos = _BDConsultar.Query("Sp_ListadoPedidosBonos");

            if (DsPedidos.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Registro in DsPedidos.Tables[0].Rows)
                {
                    try
                    {
                        var Resultado = string.Empty;
                        var Array = Registro["Bonos-Valor-Marca-RutaBanner"].ToString().Split('-');
                        var CantidadBonos = Array[0];
                        var ValorBono = Array[1];
                        var Marca = Array[2];
                        var RutaBanner = Array[3];

                        Resultado = _Correo.Banner(Registro["CorreoRemitente"].ToString(),
                                           Registro["ClaveMail"].ToString(),
                                           Registro["ServidorDeCorreo"].ToString(),
                                           Convert.ToInt32(Registro["Puerto"]),
                                           Convert.ToBoolean(Registro["SSL"]),
                                           Registro["Mascara"].ToString(),
                                           Registro["Asunto"].ToString(),
                                           Registro["CorreoCliente"].ToString(),
                                           Registro["NombreCliente"].ToString(),
                                           Registro["DocumentoCliente"].ToString(),
                                           Registro["TipoDocumento"].ToString() + "-" + Registro["Consecutivo"].ToString(),
                                           Registro["Valor"].ToString(),
                                           Convert.ToInt32(CantidadBonos),
                                           ValorBono,
                                           Marca,
                                           RutaBanner);

                        var ArrayResultado = Resultado.Split('~');

                        _BDClientesBonos.Sp_AlmacenarClientesBonos(Registro["IdCentroOperacion"].ToString(),
                            Registro["DescripcionCentroOperacion"].ToString(),
                            Registro["TipoDocumento"].ToString(),
                            Registro["Consecutivo"].ToString(),
                            Registro["Valor"].ToString(),
                            Registro["DocumentoCliente"].ToString(),
                            Registro["NombreCliente"].ToString(),
                            Registro["CorreoCliente"].ToString(),
                            Registro["FechaPedido"].ToString(),
                            CantidadBonos,
                            ValorBono,
                            ArrayResultado[0],
                            ArrayResultado[1],
                            ArrayResultado[2],
                            ArrayResultado[3]);
                    }
                    catch (Exception Ex)
                    {
                        var Respuesta = Ex.Message.ToString();
                    }
                }
            }
        }

        public void ReenviarCorreo()
        {
            DataSet DsBonos = _BDConsultar.Query("Sp_ListadoBonos");

            if (DsBonos.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Registro in DsBonos.Tables[0].Rows)
                {
                    var Respuesta = _Correo.Banner(Registro["CorreoRemitente"].ToString(),
                             Registro["ClaveMail"].ToString(),
                             Registro["ServidorDeCorreo"].ToString(),
                             Convert.ToInt32(Registro["Puerto"]),
                             Convert.ToBoolean(Registro["SSL"]),
                             Registro["Mascara"].ToString(),
                             Registro["Asunto"].ToString(),
                             Registro["CorreoCliente"].ToString(),
                             Registro["Html"].ToString());

                    if (Respuesta == "Importacion exitosa")
                    {
                        _BDClientesBonos.Sp_ActualizarReenvioCorreo(Registro["DocumentoCliente"].ToString(), Registro["ConjuntoBonos"].ToString());
                    }
                }
            }
        }

        public ModeloClientesBonos EnviarModelo(int RowId)
        {
            DataSet DsGenerico = _BDClientesBonos.Sp_ConsultarClientesBonos(RowId);

            ModeloClientesBonos Modelo = new ModeloClientesBonos();

            Modelo.RowId = (int)DsGenerico.Tables[0].Rows[0]["RowId"];
            Modelo.IdCentroOperacion = DsGenerico.Tables[0].Rows[0]["IdCentroOperacion"].ToString();
            Modelo.DescripcionCentroOperacion = DsGenerico.Tables[0].Rows[0]["DescripcionCentroOperacion"].ToString();
            Modelo.TipoDocumento = DsGenerico.Tables[0].Rows[0]["TipoDocumento"].ToString();
            Modelo.Consecutivo = DsGenerico.Tables[0].Rows[0]["Consecutivo"].ToString();
            Modelo.Valor = DsGenerico.Tables[0].Rows[0]["Valor"].ToString();
            Modelo.DocumentoCliente = DsGenerico.Tables[0].Rows[0]["DocumentoCliente"].ToString();
            Modelo.NombreCliente = DsGenerico.Tables[0].Rows[0]["NombreCliente"].ToString();
            Modelo.CorreoCliente = DsGenerico.Tables[0].Rows[0]["CorreoCliente"].ToString();
            Modelo.FechaPedido = DsGenerico.Tables[0].Rows[0]["FechaPedido"].ToString();
            Modelo.CantidadBonos = DsGenerico.Tables[0].Rows[0]["CantidadBonos"].ToString();
            Modelo.ValorBonos = DsGenerico.Tables[0].Rows[0]["ValorBonos"].ToString();
            Modelo.ConjuntoBonos = DsGenerico.Tables[0].Rows[0]["ConjuntoBonos"].ToString();
            Modelo.UltimoBono = DsGenerico.Tables[0].Rows[0]["UltimoBono"].ToString();
            Modelo.Html = DsGenerico.Tables[0].Rows[0]["Html"].ToString();
            Modelo.Resultado = DsGenerico.Tables[0].Rows[0]["Resultado"].ToString();
            Modelo.Usado = (bool)DsGenerico.Tables[0].Rows[0]["Usado"];

            return Modelo;
        }
    }
}
