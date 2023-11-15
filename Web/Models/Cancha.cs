using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    [Table("Cancha")]
    public class Cancha
    {
        public int Id { get; set; }
        [Display(Name = "Nombre de la Cancha")]
        public string Nombre { get; set; }
        public string Disponible { get; set; }

        [Required(ErrorMessage = "Por favor, ingresar el precio.")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }
    }
}
