using Microsoft.AspNetCore.Mvc;
using UserAuthApi.Models;
using UserAuthApi.Services;

namespace UserAuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Define a rota base: api/categoria
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET: api/categoria
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> ListarAsync()
        {
            var categorias = await _categoriaService.ListarAsync();
            return Ok(categorias);
        }

        // POST: api/categoria
        [HttpPost]
        public async Task<ActionResult<Categoria>> IncluirAsync([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var novaCategoria = await _categoriaService.IncluirAsync(categoria);
            return CreatedAtAction(nameof(ListarAsync), new { id = novaCategoria.Id }, novaCategoria);
        }

        // PUT: api/categoria/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarAsync(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.Id)
                return BadRequest("ID na URL não corresponde ao objeto.");

            try
            {
                await _categoriaService.AlterarAsync(id, categoria);
                return NoContent();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE: api/categoria/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirAsync(int id)
        {
            try
            {
                await _categoriaService.ExcluirAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
