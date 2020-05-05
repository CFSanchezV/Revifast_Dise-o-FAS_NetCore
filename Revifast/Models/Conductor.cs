using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Revifast.Models
{
    public partial class Conductor
    {
        public Conductor()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int ConductorId { get; set; }
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Nombres es requerido")]
        [DataType(DataType.Text)]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Apellidos es requerido")]
        [DataType(DataType.Text)]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "DNI es requerido")]
        [StringLength(8,MinimumLength = 8,ErrorMessage ="DNI requiere 8 caracteres")]
        public string Dni { get; set; }
        public string Correo { get; set; }
        [Required(ErrorMessage = "Celular es requerido")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Celular requiere 9 caracteres")]
        [DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }

        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}