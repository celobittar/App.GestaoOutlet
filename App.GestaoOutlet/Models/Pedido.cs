using System;
using System.Collections.Generic;

namespace App.GestaoOutlet.Models;

public partial class Pedido
{
    public int Idpedido { get; set; }

    public int IdformaPag { get; set; }

    public string EnderecoEntrega { get; set; }

    public string DtEntrega { get; set; }

    public string VlrGasto { get; set; }

    public string VlrRecebido { get; set; }

    public string Qtde { get; set; }

    public int Idstatus { get; set; }

    public int IdpedidoCategoria { get; set; }

    public int IdpedidoModelo { get; set; }

    public string FaltaPagar { get; set; }

    public virtual ICollection<Categorium> Idcategoria { get; } = new List<Categorium>();

    public virtual ICollection<Modelo> Idmodelos { get; } = new List<Modelo>();
}
