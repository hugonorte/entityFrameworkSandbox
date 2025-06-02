using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using ApiTasks.Data;

namespace ApiTasks.Repositories;

public class CategoriaRepository
{
    private readonly AppDbContext _contexto;
    public CategoriaRepository(AppDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Categoria>> ListarAsync()
    {
        List<Categoria> retorno = await _contexto.Categorias.ToListAsync();

        return retorno;
    }

    public async Task<Categoria> IncluirAsync(Categoria categoria)
    {
        EntityEntry<Categoria> retorno = await _contexto.Categorias.AddAsync(categoria);
        await _contexto.SaveChangesAsync();
        return retorno.Entity;
    }
}