using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class DetalleFactura
    {
        public int DfaCodigo { get; set; }
        public int DfaCantidad { get; set; }
        public decimal DfaPrecio { get; set; }
        public int FacCodigo { get; set; }
        public int ProdCodigo { get; set; }

        public virtual Factura FacCodigoNavigation { get; set; } = null!;
        public virtual Producto ProdCodigoNavigation { get; set; } = null!;
    }
}
