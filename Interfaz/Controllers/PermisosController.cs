using System;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class PermisosController : Controller
    {
        Dominio.FormulariosAdministracion.Permisos _Permisos = new Dominio.FormulariosAdministracion.Permisos();

        public ActionResult Index()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2)
            {
                return View(_Permisos.Consultar());
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult EditMenu(string Check, string RowId)
        {
            _Permisos.Actualizar(Convert.ToInt32(RowId), "Visible", Convert.ToBoolean(Check));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSubMenu(string Check, string RowId)
        {
            _Permisos.Actualizar(Convert.ToInt32(RowId), "VisibleSubMenu", Convert.ToBoolean(Check));
            return RedirectToAction("Index");
        }
    }
}