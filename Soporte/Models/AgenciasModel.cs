using System.ComponentModel.DataAnnotations;

namespace Soporte.Models
{
    public class AgenciasModel
    {

        public int id { get; set; }

        // Nombre de la agencia
        [Required(ErrorMessage = "Nombre Reqerido")]
        [MinLength(3, ErrorMessage = "El Nombre de la Agencia debe tener Minimo 3 caracteres")]
        [Display(Name = "Nombre de la Agencia")] // Nombre de la vista

        public string nombre { get; set; }

        // Numero de telefono de la agencia
        [Required(ErrorMessage = "Telefono Reqerido")]
        [MinLength(3, ErrorMessage = "El telefono de la Agencia debe tener Minimo 3 caracteres")]
        [Display(Name = "Telefono de la agencia")] // Nombre de la vista
        public string telefono { get; set; }

        //Direccion de la agencia

        [Required(ErrorMessage = "Direccion Reqerido")]
        [MinLength(3, ErrorMessage = "La Direccion del la Agencia debe tener Minimo 3 caracteres")]
        [Display(Name = "La Direccion de la Agencia")] // Nombre de la vista
        public string direccion { get; set; }

        //Ciudad de la agencia 

        [Required(ErrorMessage = "Ciudad Reqerido")]
        [MinLength(3, ErrorMessage = "La Ciudad del la Agencia debe tener Minimo 3 caracteres")]
        [Display(Name = "La Ciudad de la Agencia")] // Nombre de la vista

        public string ciudad { get; set; }
    }
}
