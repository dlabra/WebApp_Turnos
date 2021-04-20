using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [StringLength(50, ErrorMessage = "El campo nombre debe tener máximo 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un apellido")]
        [StringLength(50, ErrorMessage = "El campo apellido debe tener máximo 50 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Debe ingresar una direccion")]
        [StringLength(250, ErrorMessage = "El campo direccion debe tener máximo 250 caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Debe ingresar un telefono")]
        [StringLength(20, ErrorMessage = "El campo telefono debe tener máximo 20 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe ingresar un email")]
        [EmailAddress(ErrorMessage = "No es un email valido")]
        [StringLength(100, ErrorMessage = "El campo email debe tener máximo 100 caracteres")]
        public string Email { get; set; }


    }
}