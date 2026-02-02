using System.ComponentModel.DataAnnotations;

namespace Soporte.Models
{
    public class BancosModel
    {
        public int id { get; set; }

        // Nombre de la banco

        [Required(ErrorMessage = "Nombre Reqerido")]
        [MinLength(3, ErrorMessage = "El nombre de la Institucion debe tener Minimo 3 caracteres")]
        [Display(Name = "El nombre de la Institucion")] // Nombre de la vista
        public string nombre { get; set; }

        //Direccion de la banco

        [Required(ErrorMessage = "Direccion Reqerido")]
        [MinLength(3, ErrorMessage = "La Direccion del la Institucion debe tener Minimo 3 caracteres")]
        [Display(Name = "La Direccion de la Institucion")] // Nombre de la vista
        public string direccion { get; set; }

        //Telefono de la banco

        [Required(ErrorMessage = "Telefono Reqerido")]
        [MinLength(3, ErrorMessage = "El telefono de la Institucion debe tener Minimo 3 caracteres")]
        [Display(Name = "El telefono de la Institucion")] // Nombre de la vista
        public string telefono { get; set; }

        //email de la banco
        [Required(ErrorMessage = "Mail Reqerido")]
        [MinLength(3, ErrorMessage = "mail de la nstitucion debe tener Minimo 3 caracteres")]
        [Display(Name = "El Mail de la Institucion")] // Nombre de la vista
        public string correo { get; set; }
    }
}
