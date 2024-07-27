using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovaFormatos.Backend.Models;
using NovaFormatos.Frontend.Models;
using NovaFormatos.Shared.Data;
//using NovaFormatos.Shared.Models;
using System.Net.Http;

namespace NovaFormatos.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tblprospectosController : ControllerBase
    {
        private readonly DataContext _context;
        public tblprospectosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var prospectos = await _context.tblprospectos.Where(p => p.idsucursal == "001").ToListAsync();
            var colonias = await _context.colonias.ToListAsync();
            ProspectoViewModel prospecto = new()
            {
               Prospectos = prospectos,
               Colonias = colonias
            };

           
            return Ok(prospecto);

            //return Ok(await _context.tblprospectos.Where(p => p.idsucursal == "001").ToListAsync());
        }

        [HttpPost]

        public async Task<IActionResult> PostAsync(tblprospectos tblprospectos)
        {
            _context.Add(tblprospectos);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var prospecto = await _context.tblprospectos
                .SingleOrDefaultAsync(p => p.id == id &&  p.idsucursal == "001");
            if (prospecto == null)
            {
                return NotFound();
            }
            return Ok(prospecto);
        }

    }
}
