using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Cuentum
{
    public Guid Id { get; set; }

    public int Numero { get; set; }

    public string? Tipo { get; set; }

    public decimal SaldoInicial { get; set; }

    public string Estado { get; set; } = null!;

    public Guid IdCliente { get; set; }

    public decimal Saldo { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
