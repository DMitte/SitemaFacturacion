using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class ModoPago
    {
        public ModoPago()
        {
            Facturas = new HashSet<Factura>();
        }

        public int MpoCodigo { get; set; }
        public string MpoNombre { get; set; } = null!;
        public string MpoDetalle { get; set; } = null!;

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
