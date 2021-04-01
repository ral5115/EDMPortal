using Dominio.Modelos;
using System;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class CategoriasController : Controller
    {

        Dominio.FormulariosAdministracion.Categorias _Categorias = new Dominio.FormulariosAdministracion.Categorias();

        public ActionResult Index()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(_Categorias.Consultar());
        }

        public ActionResult Create()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(ModeloCategoria Modelo)
        {
            _Categorias.Insertar(Modelo);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int RowId)
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(_Categorias.EnviarModelo(RowId));
        }

        [HttpPost]
        public ActionResult Edit(ModeloCategoria Modelo)
        {
            _Categorias.Actualizar(Modelo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(string RowId)
        {
            _Categorias.Eliminar(Convert.ToInt32(RowId));
            return Json("La categoria ha sido eliminada.", JsonRequestBehavior.AllowGet);
        }
    }
}