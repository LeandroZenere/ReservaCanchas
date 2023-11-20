using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    [Table("Persona")]
    public class Persona
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor, ingresar el nombre.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor, ingresar el apellido.")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Por favor, ingresar el DNI.")]
        [Display(Name = "Número del DNI")]
        public int Dni { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese la Foto del DNI.")]
        [Display(Name = "Foto del DNI")]
        public string? FotoDni { get; set; }

        [Required(ErrorMessage = "Por favor, ingresar el número de teléfono.")]
        [Display(Name = "Número de teléfono")]
        public int Telefono { get; set; }

    }

}
