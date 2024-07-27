using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NovaFormatos.Shared.Data;
using NovaFormatos.Frontend.Models;
using System.Net.NetworkInformation;
using NovaFormatos.Frontend.Services;
using System.Text;

namespace NovaFormatos.Frontend.Controllers
{
    public class ColoniasController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IServicioLista _lista;
        public ColoniasController(IHttpClientFactory httpClientFactory, IServicioLista lista)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7056/");
            _lista = lista;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("/api/colonias");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var colonias = JsonConvert.DeserializeObject<IEnumerable<colonias>>(content);
                return View("Index", colonias);
            }
            return View(new List<colonias>());
        }

        public async Task<IActionResult> Edit(string id)
        {
            var response = await _httpClient.GetAsync($"/api/colonias/{id}");
            if (!response.IsSuccessStatusCode)
            {
                TempData["ErrorMessage"] = "Error al obtener la Colonia";
                return RedirectToAction("Index");
            }
            var jsonString = await response.Content.ReadAsStringAsync();
            var colonia = JsonConvert.DeserializeObject<colonias>(jsonString);

            return View(colonia);
        }
    }
}
