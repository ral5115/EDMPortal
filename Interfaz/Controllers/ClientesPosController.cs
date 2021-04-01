using Dominio.Modelos;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class ClientesPosController : Controller
    {
        Infraestructura.CRUD.BDClientesPos _BDClientesPos = new Infraestructura.CRUD.BDClientesPos();
        Dominio.FormulariosPublicos.ClientesPos _ClientesPos = new Dominio.FormulariosPublicos.ClientesPos();
        Dominio.Recursos.Combos _Combos = new Dominio.Recursos.Combos();

        public async Task<ActionResult> Index()
        {
            Session["Respuesta"] = string.Empty;

            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else if ((int)Session["Perfil"] == 2)
            {
                return await Task.Run(() =>
                {
                    return View(_ClientesPos.Consultar(-1));
                });
            }

            return await Task.Run(() =>
            {
                DataSet DatosImportantes = JsonConvert.DeserializeObject<DataSet>(Session["DatosImportantes"].ToString());
                return View(_ClientesPos.Consultar(Convert.ToInt32(DatosImportantes.Tables[0].Rows[0]["RowId_Usuario"])));
            });
        }

        public ActionResult Consult(string Campos)
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var Modelo = _ClientesPos.EnviarModelo(Campos);

            if (Modelo.Documento != string.Empty && Modelo.Celular != string.Empty)
            {
                Session["Respuesta"] = "CLIENTE ENCONTRADO...";

                RecuperarCombos(Modelo);

                return View("Create", Modelo);
            }

            Session["Respuesta"] = "CLIENTE NO ENCONTRADO...";

            LlenarCombos();

            return View("Create", Modelo);
        }

        public ActionResult Create()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            LlenarCombos();

            return View();
        }

        [HttpPost]
        public ActionResult Create(ModeloClientesPos Modelo)
        {
            DataSet DatosImportantes = JsonConvert.DeserializeObject<DataSet>(Session["DatosImportantes"].ToString());

            var Respuesta = _ClientesPos.InsertarActualizar(Modelo, Convert.ToInt32(DatosImportantes.Tables[0].Rows[0]["RowId_Usuario"]));

            if (Respuesta.Contains("Importacion exitosa"))
            {
                LlenarCombos();
                Session["Respuesta"] = Respuesta;
                return RedirectToAction("Create");
            }

            RecuperarCombos(Modelo);
            Session["Respuesta"] = Respuesta;
            return View("Create", Modelo);
        }

        public JsonResult GetCities(string RowId)
        {
            return Json(_Combos.ObtenerCiudades(RowId), JsonRequestBehavior.AllowGet);
        }

        private void LlenarCombos()
        {
            ViewBag.ListadoTipoDocumentos = _Combos.Obtener("Sp_ListadoTiposDocumento", "C");
            ViewBag.ListadoDepartamentos = _Combos.Obtener("Sp_ListadoDepartamentosERP");
            ViewBag.ListadoCiudades = _Combos.ObtenerCiudades("Sp_ListadoCiudades");
            ViewBag.ListadoSexo = _Combos.Obtener("Sp_ListadoGeneros");
        }

        private void RecuperarCombos(ModeloClientesPos Modelo)
        {
            ViewBag.ListadoTipoDocumentos = _Combos.Obtener("Sp_ListadoTiposDocumento", Modelo.RowIdTipoDocumento);
            ViewBag.ListadoDepartamentos = _Combos.Obtener("Sp_ListadoDepartamentosERP", Modelo.RowIdDepartamento);
            ViewBag.ListadoCiudades = _Combos.ObtenerCiudades(Modelo.RowIdDepartamento, Modelo.RowIdCiudad);
            ViewBag.ListadoSexo = _Combos.Obtener("Sp_ListadoGeneros", Modelo.RowIdSexo);
        }
    }
}