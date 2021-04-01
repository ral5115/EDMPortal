using Dominio.Modelos;
using System;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class UsuariosController : Controller
    {
        Dominio.FormulariosAdministracion.Usuarios _Usuarios = new Dominio.FormulariosAdministracion.Usuarios();
        Dominio.Recursos.Combos _Combos = new Dominio.Recursos.Combos();

        public ActionResult Index()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2)
            {
                return View(_Usuarios.Consultar());
            }

            return RedirectToAction("Index", "Login");
        }

        public ActionResult Create()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2)
            {
                ViewBag.ListadoPerfiles = _Combos.Obtener("Sp_ListadoPerfiles");
                return View("Create");
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Create(ModeloUsuario Modelo)
        {
            if (_Usuarios.ValidarUsuario(Modelo.Usuario) == "EXISTE")
            {
                ViewData["Error"] = "EL USUARIO YA EXISTE...";
                ViewBag.ListadoPerfiles = _Combos.Obtener("Sp_ListadoPerfiles", Modelo.RowId.ToString());
                return View(Modelo);
            }

            _Usuarios.Insertar(Modelo);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int RowId)
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2)
            {
                RecuperarCombo(RowId);
                return View(_Usuarios.EnviarModelo(RowId));
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Edit(ModeloUsuario Modelo)
        {
            _Usuarios.Actualizar(Modelo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(string RowId)
        {
            _Usuarios.Eliminar(Convert.ToInt32(RowId));
            return Json("El usuario ha sido eliminado.", JsonRequestBehavior.AllowGet);
        }

        private void RecuperarCombo(int RowId)
        {
            ViewBag.ListadoPerfiles = _Combos.Obtener("Sp_ListadoPerfiles", _Usuarios.EnviarModelo(RowId).IdPerfil.ToString());
        }
    }
}