using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    [Table("Cancha")]
    public class Cancha
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, ingresar el nombre de la cancha")]
        [Display(Name = "Nombre de la cancha")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor, ingresar el precio.")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }


    }
}


