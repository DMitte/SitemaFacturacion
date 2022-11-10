using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public int ProdCodigo { get; set; }
        public string ProdNombre { get; set; } = null!;
        public decimal ProdPrecio { get; set; }
        public int ProdStock { get; set; }
        public int CatCodigo { get; set; }

        public virtual Categorium CatCodigoNavigation { get; set; } = null!;
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
