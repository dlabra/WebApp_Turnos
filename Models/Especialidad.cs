using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Especialidad
    {
        [Key]
        public int Id { get; set; }

        //Agregamos Data Annotations Name = nobmre del campo que se muetra, Prompt = placeholder
        [StringLength(200, ErrorMessage = "El campo descripción debe tener máximo 200 caracteres")]
        [Required(ErrorMessage = "Debe ingresar una descripción")]
        [Display(Name = "Descripción", Prompt = "Ingrese una descripción")]
        public string Descripcion { get; set; }
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
}