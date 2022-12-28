using Microsoft.AspNetCore.Mvc;

namespace App.GestaoOutlet.Controllers
{
    public class PedidosController : Controller
    {
        public IActionResult Pedidos()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }


    }
}
