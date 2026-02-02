using System.ComponentModel.DataAnnotations;

namespace Soporte.Models
{
    public class MantenimientosModel
    {
        public int id { get; set; }

        // Tipo de Servicio de ATM
        [Required(ErrorMessage = "Tipo Reqerido")]
        [MinLength(3, ErrorMessage = "El Tipo del Servicio debe tener Minimo 3 caracteres")]
        [Display(Name = "Servicio del ATM")] // Nombre de la vista
        public string tipo { get; set; }

        // Fecha Inicio de Servicio del ATM

        [Required(ErrorMessage = "Fecha Inicio Reqerido")]
        [MinLength(3, ErrorMessage = "La Fecha Inicio del Servicio debe tener Minimo 3 caracteres")]
        [Display(Name = "La Fecha Inicio del Servicio")] // Nombre de la vista
        public string fechainicio { get; set; }

        //fecha Fin del Servicio del ATM
        [Required(ErrorMessage = "Fecha Fin Reqerido")]
        [MinLength(3, ErrorMessage = "La Fecha Fin del Servicio  debe tener Minimo 3 caracteres")]
        [Display(Name = "La Fecha Fin del Servicio")] // Nombre de la vista
        public string fechafin { get; set; }

        //Observaciones del Servicio del ATM

        [Required(ErrorMessage = "Observacion Reqerido")]
        [MinLength(3, ErrorMessage = "La Observacion del Servicio debe tener Minimo 3 caracteres")]
        [Display(Name = "La Observacion del Servicio")] // Nombre de la vista
        public string Observaciones { get; set; }
    }
}
