using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace Dominio.Recursos
{
    public class Combos
    {
        Infraestructura.CRUD.BDConsultar _BDConsultar = new Infraestructura.CRUD.BDConsultar();
        Infraestructura.CRUD.BDClientesPos _BDClientesPos = new Infraestructura.CRUD.BDClientesPos();

        public List<SelectListItem> Obtener()
        {
            List<SelectListItem> Item = new List<SelectListItem>();
            Item.Add(new SelectListItem { Text = "-- Seleccione --", Value = "" });

            return Item;
        }

        public List<SelectListItem> Obtener(string NombreProcedimiento)
        {
            DataSet DsGenercio = _BDConsultar.Query(NombreProcedimiento);
            List<SelectListItem> Item = new List<SelectListItem>();
            Item.Add(new SelectListItem { Text = "-- Seleccione --", Value = "", Selected = true });

            foreach (DataRow Registro in DsGenercio.Tables[0].Rows)
            {
                Item.Add(new SelectListItem { Text = Registro["Descripcion"].ToString(), Value = Registro["RowId"].ToString() });
            }

            return Item;
        }

        public List<SelectListItem> Obtener(string NombreProcedimiento, string  RowId)
        {
            DataSet DsGenercio = _BDConsultar.Query(NombreProcedimiento);
            List<SelectListItem> Item = new List<SelectListItem>();

            foreach (DataRow Registro in DsGenercio.Tables[0].Rows)
            {
                if (Registro["RowId"].ToString() == RowId)
                {
                    Item.Add(new SelectListItem { Text = Registro["Descripcion"].ToString(), Value = Registro["RowId"].ToString(), Selected = true });
                }
                else
                {
                    Item.Add(new SelectListItem { Text = Registro["Descripcion"].ToString(), Value = Registro["RowId"].ToString() });
                }
            }

            return Item;
        }

        public List<SelectListItem> ObtenerCiudades(string RowIdDepartamento, string RowIdCiudad)
        {
            DataSet DsGenercio = _BDClientesPos.Sp_ListadoCiudades(RowIdDepartamento);
            List<SelectListItem> Item = new List<SelectListItem>();

            foreach (DataRow Registro in DsGenercio.Tables[0].Rows)
            {
                if (Registro["RowId"].ToString() == RowIdCiudad)
                {
                    Item.Add(new SelectListItem { Text = Registro["Descripcion"].ToString(), Value = Registro["RowId"].ToString(), Selected = true });
                }
                else
                {
                    Item.Add(new SelectListItem { Text = Registro["Descripcion"].ToString(), Value = Registro["RowId"].ToString() });
                }
            }

            return Item;
        }

        public List<SelectListItem> ObtenerCiudades(string RowId)
        {
            DataSet DsGenercio = _BDClientesPos.Sp_ListadoCiudades(RowId);
            List<SelectListItem> Item = new List<SelectListItem>();
            Item.Add(new SelectListItem { Text = "-- Seleccione --", Value = "", Selected = true });

            foreach (DataRow Registro in DsGenercio.Tables[0].Rows)
            {
                Item.Add(new SelectListItem { Text = Registro["Descripcion"].ToString(), Value = Registro["RowId"].ToString() });
            }

            return Item;
        }
    }
}
