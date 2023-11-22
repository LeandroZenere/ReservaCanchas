using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class PersonaViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Display(Name = "Dni")]
        public int Dni { get; set; }
        [Display(Name = "Telefono")]
        public int Telefono { get; set; }

        [Display(Name = "Foto DNI")]
        public IFormFile Foto { get; set; }

        [Display(Name = "Foto")]
        public string? FotoDNI { get; set; }
    }
}
