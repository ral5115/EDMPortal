using Dominio.Modelos;
using System;
using System.Data;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class ReferidosController : Controller
    {
        Infraestructura.CRUD.BDConsultar _BDConsultar = new Infraestructura.CRUD.BDConsultar();
        Dominio.FormulariosPublicos.Referidos _Referidos = new Dominio.FormulariosPublicos.Referidos();
        Dominio.Recursos.Correo _Correo = new Dominio.Recursos.Correo();

        public ActionResult Index()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2 || (int)Session["Perfil"] == 4)
            {
                return View(_Referidos.Consultar());
            }
            else if ((int)Session["Perfil"] == 5)
            {
                return View(_Referidos.Consultar(Convert.ToInt32(Session["Usuario"])));
            }

            return RedirectToAction("Index", "Login");
        }

        public ActionResult Create()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 5)
            {
                DataSet DsGenerico = _Referidos.Consultar(Convert.ToInt32(Session["Usuario"]));

                if (DsGenerico.Tables[0].Rows.Count < 20)
                {
                    return View("Create");
                }
                Session["Mensaje"] = "Lo sentimos no puede registrar mas de 20 referidos.";
                return RedirectToAction("Index");

            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Create(ModeloReferido Modelo)
        {
            if (_Referidos.ValidarReferido(Convert.ToInt64(Modelo.Documento)) == "EXISTE")
            {
                ViewData["Error"] = "EL REFERIDO YA EXISTE...";
                return View(Modelo);
            }

            DataSet DsPropiedades = _BDConsultar.Query("Sp_ConsultarListadoPropiedades");
            DataSet DsGenerico = _Referidos.Consultar(Convert.ToInt32(Session["Usuario"]));
            _Referidos.Insertar(Convert.ToInt32(Session["Usuario"]), Modelo);
            Session["Mensaje"] = _Correo.Banner(DsPropiedades.Tables[0].Rows[0]["CorreoRemitente"].ToString(),
                                                DsPropiedades.Tables[0].Rows[0]["ClaveMail"].ToString(),
                                                DsPropiedades.Tables[0].Rows[0]["ServidorDeCorreo"].ToString(),
                                                Convert.ToInt32(DsPropiedades.Tables[0].Rows[0]["Puerto"]),
                                                Convert.ToBoolean(DsPropiedades.Tables[0].Rows[0]["SSL"]),
                                                DsPropiedades.Tables[0].Rows[0]["Mascara"].ToString(),
                                                DsPropiedades.Tables[0].Rows[0]["Asunto"].ToString(),
                                                Modelo.Correo,
                                                DsGenerico.Tables[0].Rows[0]["Empleado"].ToString(),
                                                Modelo.NombreCompleto,
                                                DsPropiedades.Tables[0].Rows[0]["RutaBannerReferidos"].ToString());

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int RowId)
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2 || (int)Session["Perfil"] == 4)
            {
                return View(_Referidos.EnviarModelo(RowId));
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Edit(ModeloReferido Modelo)
        {
            _Referidos.Actualizar(Convert.ToInt32(Session["Usuario"]), Modelo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(string RowId)
        {
            _Referidos.Eliminar(Convert.ToInt32(RowId));
            return Json("El referido ha sido eliminado.", JsonRequestBehavior.AllowGet);
        }
    }
}