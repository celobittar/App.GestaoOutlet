using App.GestaoOutlet.Data;
using App.GestaoOutlet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace App.GestaoOutlet.Controllers
{
    public class PedidosController : Controller
    {
        private readonly DboutletContext _context;

        public PedidosController(DboutletContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int IDPedido, [Bind("IDPedido,IDFormaPag,EnderecoEntrega,DtEntrega,VlrGasto,VlrRecebido,Qtde,IDStatus,IDPedidoCategoria,IDPedidoModelo,FaltaPagar")] Pedido pedido)
        {
            IQueryable<int> pedidoQuery = from m in _context.Pedidos
                                          orderby m.Idpedido
                                          select m.Idpedido;

            var pedidos = from m in _context.Pedidos select m;

            var PedidosVM = new PedidoViewModel
            {
                IdPedidos = new SelectList(await pedidoQuery.Distinct().ToListAsync()),
                Pedidos = await pedidos.ToListAsync()
            };

            return View(PedidosVM);
        }


        public IActionResult Create()
        {
            return View();
        }


    }
}
