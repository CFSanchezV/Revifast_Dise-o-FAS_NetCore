using System;
using System.Collections.Generic;

namespace Revifast.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string Ruc { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
