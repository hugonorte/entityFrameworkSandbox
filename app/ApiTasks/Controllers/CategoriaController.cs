using Microsoft.AspNetCore.Mvc;
using ApiTasks.Services;

namespace ApiTasks.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CategoriaController(CategoriaService categoriaService)
{

    private readonly CategoriaService categoriaService = categoriaService;
    [HttpGet]
    public async Task<ActionResult<List<Categoria>>> ListarAsync()
    {

        List<Categoria> retorno = await categoriaService.ListarAsync();

        return retorno;
    }

    [HttpPost]
    public async Task<Categoria> IncluirAsync([FromBody] Categoria categoria)
    {
        Categoria retorno = await categoriaService.IncluirAsync(categoria);
        return retorno;
    }
}