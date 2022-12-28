using System;
using System.Collections.Generic;

namespace App.GestaoOutlet.Models;

public partial class Categorium
{
    public int Idcategoria { get; set; }

    public string DescricaoCategoria { get; set; }

    public virtual ICollection<Pedido> Idpedidos { get; } = new List<Pedido>();
}
