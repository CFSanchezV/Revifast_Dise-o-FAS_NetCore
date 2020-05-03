using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Revifast.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int VehiculoId { get; set; }

        [Display(Name = "Conductor")]
        public int? ConductorId { get; set; }


        [StringLength(30, MinimumLength = 6, ErrorMessage = "Entre 6 y 30 caracteres")]
        public string Placa { get; set; }

        [StringLength(30, MinimumLength = 5, ErrorMessage = "Ingrese Marca y Modelo")]
        public string Modelo { get; set; }

        [StringLength(10, MinimumLength = 3, ErrorMessage = "Entre 3 y 10 caracteres")]
        public string Categoria { get; set; }


        public virtual Conductor Conductor { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}