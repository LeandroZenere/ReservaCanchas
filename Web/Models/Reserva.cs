using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("Reserva")]
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        [Display(Name = "Hora de inicio")]
        public TimeSpan HoraInicio { get; set; }
        [Display(Name = "Hora de finalización")]
        public TimeSpan HoraFin { get; set; }

        [Display(Name = "Cancha")]
        public int idCancha { get; set; }

        [Display(Name = "Persona")]
        public int idPersona { get; set; }

        [Display(Name = "Estado asignado")]
        public int idEstado { get; set; }

        [ForeignKey("idCancha")]
        public virtual Cancha? Cancha { get; set; }
        [ForeignKey("idPersona")]
        public virtual Persona? Persona { get; set; }

        [ForeignKey("idEstado")]
        public virtual Estado? Estado { get; set; }

    }
}
