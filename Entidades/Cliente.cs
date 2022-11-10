using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public int CliCodigo { get; set; }
        public string CliCedula { get; set; } = null!;
        public string CliApellidos { get; set; } = null!;
        public string CliNombres { get; set; } = null!;
        public string CliDireccion { get; set; } = null!;
        public string CliFechaNacimiento { get; set; } = null!;
        public string CliTelefono { get; set; } = null!;
        public string CliMail { get; set; } = null!;

        public string CliPassword { get; set; } = null!;

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
