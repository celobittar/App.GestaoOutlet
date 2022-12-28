namespace App.GestaoOutlet.Models
{
    public class PedidoViewModel
    {
        public int IDPedido { get; set; }
        public int IDFormaPag { get; set; }
        public string EnderecoEntrega { get; set; }
        public string DtEntrega { get; set;}
        public string VlrGasto { get; set; }
        public string VlrRecebido { get; set; }
        public int Qtde { get; set; }
        public int IDStatus { get; set; }
        public int IDPedidoCategoria{ get; set; }
        public int IDPedidoModelo { get; set; }
        public string FaltaPagar { get; set; }
    }
}
