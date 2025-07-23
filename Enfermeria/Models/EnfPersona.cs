using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // ← Agregado para usar [MaxLength]

namespace Enfermeria.Models;

public partial class EnfPersona
{
    public int Id { get; set; }

    public string Cedula { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string Usuario { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Departamento { get; set; }

    public string Tipo { get; set; } = null!;

    public string? Seccion { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    [MaxLength(10)] // ← Aquí se corrige el error (cambia a 1 si usas solo "M"/"F")
    public string Sexo { get; set; } = null!;

    // 🔥 Campo agregado para controlar si la persona está activa o inactiva
    public bool Activo { get; set; } = true;

    public virtual ICollection<EnfCita> EnfCitaIdPersonaNavigations { get; set; } = new List<EnfCita>();

    public virtual ICollection<EnfCita> EnfCitaIdProfeLlegadaNavigations { get; set; } = new List<EnfCita>();

    public virtual ICollection<EnfCita> EnfCitaIdProfeSalidaNavigations { get; set; } = new List<EnfCita>();
}
