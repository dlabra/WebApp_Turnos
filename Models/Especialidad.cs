using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Especialidad
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}