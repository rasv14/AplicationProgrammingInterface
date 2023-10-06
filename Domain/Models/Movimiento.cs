using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Movimiento
{
    public Guid Id { get; set; }

    public DateTime Fecha { get; set; }

    public string Tipo { get; set; } = null!;

    public decimal Valor { get; set; }

    public decimal Saldo { get; set; }

    public Guid IdCuenta { get; set; }

    public virtual Cuentum IdCuentaNavigation { get; set; } = null!;
}
