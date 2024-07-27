using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NovaFormatos.Frontend.Services
{
    public interface IServicioLista
    {
        Task<IEnumerable<SelectListItem>> GetListaColonias();
    }
}
