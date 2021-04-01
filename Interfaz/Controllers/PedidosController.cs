using System.Threading.Tasks;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class PedidosController : Controller
    {
        Dominio.FormulariosPublicos.Pedidos _Pedidos = new Dominio.FormulariosPublicos.Pedidos();

        public async Task<ActionResult> Nacional()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return await Task.Run(() =>
            {
                return View(_Pedidos.Nacional());
            });
        }

        public async Task<ActionResult> Internacional()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return await Task.Run(() =>
            {
                return View(_Pedidos.Internacional());
            });
        }
    }
}