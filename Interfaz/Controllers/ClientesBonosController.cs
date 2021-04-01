using Dominio.Modelos;
using System;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class ClientesBonosController : Controller
    {
        Dominio.FormulariosPublicos.ClientesBonos _ClientesBonos = new Dominio.FormulariosPublicos.ClientesBonos();

        public ActionResult Index()
        {
            return View(_ClientesBonos.Consultar());
        }

        public ActionResult Detail(int RowId)
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2 || (int)Session["Perfil"] == 4)
            {
                return View(_ClientesBonos.EnviarModelo(RowId));
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Detail(ModeloClientesBonos Modelo)
        {
            _ClientesBonos.Actualizar(Modelo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(string RowId)
        {
            _ClientesBonos.Eliminar(Convert.ToInt32(RowId));
            return Json("El cliente ha sido eliminado.", JsonRequestBehavior.AllowGet);
        }
    }
}