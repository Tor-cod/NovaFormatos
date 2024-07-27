using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaFormatos.Shared.Data
{
    public class tblprospectos
    {
        public int id { get; set; }
        public string? idsucursal { get; set; }
        public string? cia { get; set; } = null!;
        public string? nombre1 { get; set; } = null!;
        public string? nombre2 { get; set; } = null!;
        public string? apellidop { get; set; } = null!;
        public string? apellidom { get; set; } = null!;
        public string? rfc { get; set; } = null!;
        public string? direccion1 { get; set; } = null!;
        public string? noexterior { get; set; } = null!;
        public string? nointerior { get; set; } = null!;
        public string? idcolonia { get; set; }
        public string? colonia { get; set; }
        public string? idmunicipio { get; set; }
        public string? idestado { get; set; }
        public string? cp { get; set; }
        public string? telefono { get; set; }
    }
}
