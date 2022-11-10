using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public int FacCodigo { get; set; }
        public int CliCodigo { get; set; }
        public int MpoCodigo { get; set; }
        public string? FacFechaEmision { get; set; }

        public virtual Cliente CliCodigoNavigation { get; set; } = null!;
        public virtual ModoPago MpoCodigoNavigation { get; set; } = null!;
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
