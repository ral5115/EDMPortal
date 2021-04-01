﻿using System.Data;

namespace Dominio.Login
{
    public class Login
    {
        Infraestructura.CRUD.BDConsultar _BDConsultar = new Infraestructura.CRUD.BDConsultar();
        Infraestructura.CRUD.BDLogin _BDLogin = new Infraestructura.CRUD.BDLogin();
        Menu _Menu = new Menu();

        public DataSet Estilos()
        {
            return _BDConsultar.Query("Sp_ListadoEstilos");
        }

        public string[] Autenticar(string Usuario, string Clave)
        {
            DataSet DsAutenticacion = _BDLogin.Sp_ValidarAutenticacion(Usuario, Clave);

            if (DsAutenticacion.Tables[0].Rows.Count > 0)
            {
                var Menu = _Menu.Obtener((int)DsAutenticacion.Tables[0].Rows[0]["RowId_Perfil"],
               (string)DsAutenticacion.Tables[0].Rows[0]["EP_ColorFondoAdministracion"],
               (string)DsAutenticacion.Tables[0].Rows[0]["EP_ColorFondoAdministracion"]);

                var Accion = (string)DsAutenticacion.Tables[0].Rows[0]["Pagina_Inicial"];

                string[] ArregloAutenticacion = new string[]
                {
                    Accion,
                    Menu
                };
                return ArregloAutenticacion;
            }
            else
            {
                string[] ArregloAutenticacion = new string[] { "Usuario o Contraseña Incorrecta" };
                return ArregloAutenticacion;
            }
        }

        public DataSet DatosImportantes(string Usuario, string Clave)
        {
            return _BDLogin.Sp_ValidarAutenticacion(Usuario, Clave);
        }
    }
}
