using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("Estado")]
    public class Estado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, ingresar el nombre del estado.")]
        public string Nombre { get; set; }
        //public static readonly Estado Reservada = new Estado { Id = 1, Nombre = "Reservada" };
        //public static readonly Estado Disponible = new Estado { Id = 2, Nombre = "Disponible" };

    }
}
