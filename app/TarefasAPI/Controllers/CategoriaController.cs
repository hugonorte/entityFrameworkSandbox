using Microsoft.AspNetCore.Mvc;
using TarefasAPI.Models;
using TarefasAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TarefasAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController(CategoriaService categoriaService)
{
    private readonly CategoriaService _categoriaService = categoriaService;

    [HttpGet]
    public async Task<ActionResult<List<Categoria>>> ListarAsync()
    {
        List<Categoria> retorno = await _categoriaService.ListarAsync();

        return retorno;
    }

    [HttpPost]
    public async Task<Categoria> IncluirAsync([FromBody] Categoria categoria)
    {
        Categoria retorno = await _categoriaService.IncluirAsync(categoria);

        return retorno;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> AlterarAsync(int id, [FromBody] Categoria categoria)
    {
        await _categoriaService.AlterarAsync(id, categoria);
        return new NoContentResult();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> ExcluirAsync(int id)
    {
        await _categoriaService.ExcluirAsync(id);
        return new NoContentResult();
    }
}