using System.ComponentModel.DataAnnotations;

namespace Soporte.Models
{
    public class GestoresModel
    {
        public int id { get; set; }

        // Nombre del Encargado
        [Required(ErrorMessage = "Nombre Reqerido")]
        [MinLength(3, ErrorMessage = "Nombre del encargado del ATM debe tener Minimo 3 caracteres")]
        [Display(Name = "Nombre del Encargado del ATM")] // Nombre de la vista
        public string nombres { get; set; }

        // Apellodo del Encragado

        [Required(ErrorMessage = "Apellido Reqerido")]
        [MinLength(3, ErrorMessage = "El Apellido del encragado del ATM debe tener Minimo 3 caracteres")]
        [Display(Name = "Apellido del Encragado del ATM")] // Nombre de la vista
        public string apellido { get; set; }

        //Cargo del Encragado

        [Required(ErrorMessage = "Cargo Reqerido")]
        [MinLength(3, ErrorMessage = "El Cargo del encragado del ATM debe tener Minimo 3 caracteres")]
        [Display(Name = "Cargo del Encragado del ATM")] // Nombre de la vista
        public string cargo { get; set; }

        //Direccion del domicilio del Encargado

        [Required(ErrorMessage = "Direccion Reqerido")]
        [MinLength(3, ErrorMessage = "La Direccion del encragado del ATM debe tener Minimo 3 caracteres")]
        [Display(Name = "Direccion de domicilio")] // Nombre de la vista
        public string direccion { get; set; }
    }
}
