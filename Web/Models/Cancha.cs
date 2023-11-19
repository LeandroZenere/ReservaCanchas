using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    [Table("Cancha")]
    public class Cancha
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, ingresar el nombre de la cancha")]
        [Display(Name = "Disponible")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor, ingresar el precio.")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }

        //[Display(Name = "Estado")]
        //public int? EstadoId { get; set; }

        //[ForeignKey("idEstado")]
        //public virtual Estado? Estado { get; set; }

    }
}


