using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Cliente
{
    public Guid Id { get; set; }

    public string Contrasena { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public Guid IdPersona { get; set; }

    public virtual ICollection<Cuentum> Cuenta { get; set; } = new List<Cuentum>();

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
