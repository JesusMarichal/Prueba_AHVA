using System.ComponentModel.DataAnnotations;

namespace PruebaAHVA.Models
{
    public class PerfilEditViewModel
    {
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? ApellidoPaterno { get; set; }

        [MaxLength(100)]
        public string? ApellidoMaterno { get; set; }

        [MaxLength(20)]
        public string? TipoDocumento { get; set; }

        [MaxLength(20)]
        public string? NumeroDocumento { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        [MaxLength(50)]
        public string? Nacionalidad { get; set; }

        [MaxLength(20)]
        public string? Sexo { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? CorreoSecundario { get; set; }

        [MaxLength(20)]
        public string? TelefonoMovil { get; set; }

        [MaxLength(20)]
        public string? TelefonoSecundario { get; set; }

        [MaxLength(50)]
        public string? TipoContratacion { get; set; }

        public DateTime? FechaContratacion { get; set; }
    }
}
