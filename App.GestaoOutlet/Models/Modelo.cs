using System;
using System.Collections.Generic;

namespace App.GestaoOutlet.Models;

public partial class Modelo
{
    public int Idmodelo { get; set; }

    public string DescricaoModelo { get; set; }

    public virtual ICollection<Pedido> Idpedidos { get; } = new List<Pedido>();
}
