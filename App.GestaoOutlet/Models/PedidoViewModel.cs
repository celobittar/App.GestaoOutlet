using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.GestaoOutlet.Models
{
    public class PedidoViewModel
    {
        public List<Pedido> Pedidos { get; set; }
        public SelectList IdPedidos { get; set; }
        public int IdPedido { get; set; }
        public string SearchIDPedido { get; set; }
    }
}
