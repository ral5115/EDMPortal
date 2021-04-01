using Dominio.Modelos;
using System;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class DepartamentosController : Controller
    {
        Dominio.FormulariosAdministracion.Departamentos _Departamentos = new Dominio.FormulariosAdministracion.Departamentos();

        public ActionResult Index()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(_Departamentos.Consultar());
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
        public ActionResult Create(ModeloDepartamento Modelo)
        {
            _Departamentos.Insertar(Modelo);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int RowId)
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(_Departamentos.EnviarModelo(RowId));
        }

        [HttpPost]
        public ActionResult Edit(ModeloDepartamento Modelo)
        {
            _Departamentos.Actualizar(Modelo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(string RowId)
        {
            _Departamentos.Eliminar(Convert.ToInt32(RowId));
            return Json("El departamento ha sido eliminado.", JsonRequestBehavior.AllowGet);
        }
    }
}