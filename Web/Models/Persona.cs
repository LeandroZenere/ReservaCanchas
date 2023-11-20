using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    [Table("Persona")]
    public class Persona
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Display(Name = "Número del DNI")]
        public string Dni { get; set; }

        [Display(Name = "Foto del DNI")]
        public string? FotoDni { get; set; }

        [Display(Name = "Número de teléfono")]
        public string Telefono { get; set; }

    }

}
