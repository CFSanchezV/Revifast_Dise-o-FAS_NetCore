using System;
using System.Collections.Generic;

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
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }

        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}