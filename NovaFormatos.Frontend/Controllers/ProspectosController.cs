using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NovaFormatos.Shared.Data;
using NovaFormatos.Frontend.Models;
using System.Net.NetworkInformation;
using NovaFormatos.Frontend.Services;
using System.Text;
using System.Reflection;

namespace NovaFormatos.Frontend.Controllers
{
    public class ProspectosController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IServicioLista _lista;
        public ProspectosController(IHttpClientFactory httpClientFactory, IServicioLista lista)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7056/");
            _lista = lista;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("/api/tblprospectos");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var prospectos = JsonConvert.DeserializeObject<IEnumerable<tblprospectos>>(content);
                return View("Index", prospectos);
            }
            return View(new List<tblprospectos>());
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"/api/tblprospectos/{id}");
            if (!response.IsSuccessStatusCode)
            {
                TempData["ErrorMessage"] = "Error al obtener el prospecto";
                return RedirectToAction("Index");
            }
            var jsonString = await response.Content.ReadAsStringAsync();
            var prospecto = JsonConvert.DeserializeObject<tblprospectos>(jsonString);

            return View(prospecto);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"/api/tblprospectos/{id}");
            if (!response.IsSuccessStatusCode)
            {
                TempData["ErrorMessage"] = "Error al obtener el prospecto";
                return RedirectToAction("Index");
            }
            var jsonString = await response.Content.ReadAsStringAsync();
            var prospecto = JsonConvert.DeserializeObject <coloniasViewModel>(jsonString);
            return View(prospecto);
        }
    }
}
