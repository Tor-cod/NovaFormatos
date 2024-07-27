using Microsoft.AspNetCore.Mvc.Rendering;
using NovaFormatos.Shared.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovaFormatos.Frontend.Models
{
    public class coloniasViewModel: colonias
    {
        [NotMapped]
        public IEnumerable<SelectListItem>? Colonias { get; set; }
    }
}
