using Microsoft.AspNetCore.Mvc.Rendering;
using NovaFormatos.Shared.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovaFormatos.Frontend.Models
{
    public class PropectoViewModel: tblprospectos
    {
        [NotMapped]
        public IEnumerable<SelectListItem>? Colonias { get; set; }
    }
}
