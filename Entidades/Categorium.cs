using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }

        public int CatCodigo { get; set; }
        public string CatNombre { get; set; } = null!;
        public string CatDescripcion { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
