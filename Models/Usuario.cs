using System.ComponentModel.DataAnnotations;

namespace PruebaAHVA.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Password { get; set; } = string.Empty;

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

        [MaxLength(100)]
        public string? CorreoSecundario { get; set; }

        [MaxLength(20)]
        public string? TelefonoMovil { get; set; }

        [MaxLength(20)]
        public string? TelefonoSecundario { get; set; }

        [MaxLength(100)]
        public string? Cargo { get; set; }

        [MaxLength(150)]
        public string? Institucion { get; set; }

        [MaxLength(50)]
        public string? TipoContratacion { get; set; }

        public DateTime? FechaContratacion { get; set; }

        [MaxLength(20)]
        public string Estado { get; set; } = "Activo";

        public int IntentosFallidos { get; set; } = 0;

        public DateTime? BloqueadoHasta { get; set; }

        public int RolId { get; set; }

        public Rol? Rol { get; set; }
    }
}
