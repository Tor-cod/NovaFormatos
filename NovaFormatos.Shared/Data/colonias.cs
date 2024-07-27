using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovaFormatos.Shared.Data
{
    public class colonias
    {
        [Key]
        public string? idcolonia { get; set; }
        public string? colonia { get; set; }
    }
}
