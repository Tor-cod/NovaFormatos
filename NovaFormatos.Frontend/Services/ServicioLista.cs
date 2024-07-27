using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NovaFormatos.Shared.Data;

namespace NovaFormatos.Frontend.Services
{
    public class ServicioLista : IServicioLista
    {
        private readonly HttpClient _httpClient;

        public ServicioLista(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7056/");
        }
        public async Task<IEnumerable<SelectListItem>> GetListaColonias()
        {
            var response = await _httpClient.GetAsync("api/colonias");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var colonias = JsonConvert.DeserializeObject<IEnumerable<colonias>>(content);

                var listaColonias = colonias!.Select(e => new SelectListItem
                {
                    Value = e.idcolonia!.ToString(),
                    Text = e.colonia
                }).ToList();

                listaColonias.Insert(0, new SelectListItem
                {
                    Value = "",
                    Text = "Seleccione un Edificio"
                });
                return listaColonias;
            }
            return [];
        }
    }
}
