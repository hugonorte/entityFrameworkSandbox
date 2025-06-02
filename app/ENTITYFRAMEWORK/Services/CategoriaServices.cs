using UserAuthApi.Models;
using UserAuthApi.Repositories;

namespace UserAuthApi.Services
{
    public class CategoriaService
    {
        private readonly CategoriaRepository _categoriaRepository;

        public CategoriaService(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        // Lógica de listagem
        public async Task<List<Categoria>> ListarAsync()
        {
            return await _categoriaRepository.ListarAsync();
        }

        // Lógica de inclusão
        public async Task<Categoria> IncluirAsync(Categoria categoria)
        {
            return await _categoriaRepository.IncluirAsync(categoria);
        }

        // Lógica de alteração
        public async Task AlterarAsync(int id, Categoria categoria)
        {
            var existente = await _categoriaRepository.ObterPorId(id);
            if (existente is null)
                throw new KeyNotFoundException("Categoria não encontrada.");

            existente.Nome = categoria.Nome;
            await _categoriaRepository.SalvarAlteracoesAsync();
        }

        // Lógica de exclusão
        public async Task ExcluirAsync(int id)
        {
            var existente = await _categoriaRepository.ObterPorId(id);
            if (existente is null)
                throw new KeyNotFoundException("Categoria não encontrada.");

            _categoriaRepository.Excluir(existente);
            await _categoriaRepository.SalvarAlteracoesAsync();
        }
    }
}


// entityframework_default

// docker run --rm -v $(pwd)/app/ENTITYFRAMEWORK:/app -w /app --network entityframework_default mcr.microsoft.com/dotnet/sdk:9.0 bash
//  -c "dotnet tool install --global dotnet-ef && /root/.dotnet/tools/dotnet-ef migrations add InitialCreate"

// docker run --rm -v $(pwd)/app/ENTITYFRAMEWORK:/app -w /app --network entityframework_default mcr.microsoft.com/dotnet/sdk:9.0 bash -c 
// "dotnet tool install --global dotnet-ef && /root/.dotnet/tools/dotnet-ef database update"