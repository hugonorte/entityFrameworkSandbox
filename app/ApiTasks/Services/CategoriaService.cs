using ApiTasks.Repositories;

namespace ApiTasks.Services;

public class CategoriaService
{
    private readonly CategoriaRepository _categoriaRepository;
    public CategoriaService(CategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<List<Categoria>> ListarAsync()
    {
        List<Categoria> retorno = await _categoriaRepository.ListarAsync();

        return retorno;
    }

    public async Task<Categoria> IncluirAsync(Categoria categoria)
    {
        Categoria retorno = await _categoriaRepository.IncluirAsync(categoria);

        return retorno;
    }
}