using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UserAuthApi.Data;
using UserAuthApi.Models;

namespace UserAuthApi.Repositories
{
    public class CategoriaRepository
    {
        private readonly AppDbContext _contexto;

        public CategoriaRepository(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        // Lista todas as categorias do banco
        public async Task<List<Categoria>> ListarAsync()
        {
            return await _contexto.Categorias.ToListAsync();
        }

        // Inclui uma nova categoria no banco
        public async Task<Categoria> IncluirAsync(Categoria categoria)
        {
            EntityEntry<Categoria> retorno = await _contexto.Categorias.AddAsync(categoria);
            await _contexto.SaveChangesAsync();
            return retorno.Entity;
        }

        // Busca uma categoria pelo ID
        public async Task<Categoria?> ObterPorId(int id)
        {
            return await _contexto.Categorias.FindAsync(id);
        }

        // Remove uma categoria
        public void Excluir(Categoria categoria)
        {
            _contexto.Categorias.Remove(categoria);
        }

        // Salva as alterações no banco (para update ou delete)
        public async Task SalvarAlteracoesAsync()
        {
            await _contexto.SaveChangesAsync();
        }
    }
}
