using System.ComponentModel.DataAnnotations;

namespace Soporte.Models
{
    public class AtmsModel
    {
        public int id { get; set; }

        //Nombre del ATM
        [Required(ErrorMessage = "Nombre Reqerido")]
        [MinLength(3, ErrorMessage = "El Nombre del ATM debe tener Minimo 3 caracteres")]
        [Display(Name = "El Nombre del ATM")] // Nombre de la vista
        public string nombre { get; set; }

        // Direccion donde se encuentra ubicado el ATM

        [Required(ErrorMessage = "Direccion Reqerido")]
        [MinLength(3, ErrorMessage = "La Direccion del ATM debe tener Minimo 3 caracteres")]
        [Display(Name = "La Direccion del ATM")] // Nombre de la vista
        public string direccion { get; set; }

        //Tipo de ATM

        [Required(ErrorMessage = "Tipo Reqerido")]
        [MinLength(3, ErrorMessage = "El tipo del ATM debe tener Minimo 3 caracteres")]
        [Display(Name = "El tipo del ATM")] // Nombre de la vista
        public string tipo { get; set; }

        //Modelo del ATM
        [Required(ErrorMessage = "Modelo Reqerido")]
        [MinLength(3, ErrorMessage = "El Modelo del ATM debe tener Minimo 3 caracteres")]
        [Display(Name = "El Modelo del ATM")] // Nombre de la vista
        public string modelo { get; set; }

        //relaciones

        //Nombre del gestores

        [Display(Name = "Gestores ATM")] // Nombre de la vista
        public int GestoresModelId { get; set; }
        public GestoresModel GestoresModel { get; set; }

        // Mantenimiento

        [Display(Name = "Mantenimientos")] // Nombre de la vista
        public int MantenimientosModelId { get; set; }
        public MantenimientosModel MantenimientosModel { get; set; }

        //Agencia

        [Display(Name = "Agencias")] // Nombre de la vista
        public int AgenciasModelId { get; set; }
        public AgenciasModel AgenciasModel { get; set; }

        //bancos

        [Display(Name = "Bancos")] // Nombre de la vista
        public int BancosModelId { get; set; }

        public BancosModel BancosModel { get; set; }
    }
}
