using NovaFormatos.Shared.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovaFormatos.Frontend.Models
{
    public class ProspectoViewModel
    {
        [NotMapped]
        public IEnumerable<colonias>? Colonias { get; set; }

        [NotMapped]
        public IEnumerable<tblprospectos>? Prospectos { get; set; }
        //public string? idcolonia { get; set; }
        //public string? colonia { get; set; }
    }
}
