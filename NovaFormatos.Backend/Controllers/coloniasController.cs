using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovaFormatos.Backend.Models;
using NovaFormatos.Shared.Data;

namespace NovaFormatos.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class coloniasController : ControllerBase
    {
        private readonly DataContext _context;
        public coloniasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.colonias.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var colonia = await _context.colonias
                .SingleOrDefaultAsync(p => p.idcolonia == id);
            if (colonia == null)
            {
                return NotFound();
            }
            return Ok(colonia);
        }
    }
}
