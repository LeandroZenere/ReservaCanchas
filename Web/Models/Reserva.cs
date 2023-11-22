using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("Reserva")]
    public class Reserva
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese la fecha.")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Por favor, ingresar la hora de inicio del turno.")]
        [Display(Name = "Hora de inicio")]
        public TimeSpan HoraInicio { get; set; }


        [Required(ErrorMessage = "Por favor, ingresar la hora de finalización del turno.")]
        [Display(Name = "Hora de finalización")]
        public TimeSpan HoraFin { get; set; }


        [Required(ErrorMessage = "Por favor, ingresar una cancha disponible.")]
        [Display(Name = "Cancha")]
        public int idCancha { get; set; }

        [Required(ErrorMessage = "Por favor, ingresar una persona.")]
        [Display(Name = "Persona")]
        public int idPersona { get; set; }

        [Required(ErrorMessage = "Por favor, asigne un estado.")]
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
