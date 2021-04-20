using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Turnos.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }

        [Display(Name = "Nombre", Prompt = "Ingrese un nombre")]
        [StringLength(50, ErrorMessage = "El campo nombre debe tener máximo 50 caracteres")]
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido", Prompt = "Ingrese el apellido")]
        [StringLength(50, ErrorMessage = "El campo apellido debe tener máximo 50 caracteres")]
        [Required(ErrorMessage = "Debe ingresar un apellido")]
        public string Apellido { get; set; }

        [Display(Name = "Direccion", Prompt = "Ingrese una direccion")]
        [StringLength(250, ErrorMessage = "El campo direccion debe tener máximo 250 caracteres")]
        [Required(ErrorMessage = "Debe ingresar una direccion")]
        public string Direccion { get; set; }

        [Display(Name = "Telefono", Prompt = "Ingrese un telefono")]
        [StringLength(20, ErrorMessage = "El campo telefono debe tener máximo 20 caracteres")]
        [Required(ErrorMessage = "Debe ingresar un telefono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe ingresar un email")]
        [Display(Name = "Email", Prompt = "Ingrese un email")]
        [EmailAddress(ErrorMessage = "No es un email valido")]
        public string Email { get; set; }

        [Display(Name = "Horario de atencion desde", Prompt = "Ingrese desde cuando esta disponible")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm: tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionDesde { get; set; }

        [Display(Name = "Horario de atencion desde", Prompt = "Ingrese hasta cuando esta disponible")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm: tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionHasta { get; set; }

        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
}