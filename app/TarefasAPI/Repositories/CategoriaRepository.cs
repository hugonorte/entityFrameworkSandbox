namespace TarefasAPI.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TarefasAPI.Models;
using TarefasAPI.Data;

public class CategoriaRepository
{
   private readonly TarefasApiContext _context;
   public CategoriaRepository(TarefasApiContext context)
   {
      _context = context;
   }

   public async Task<List<Categoria>> ListarAsync()
   {
      return await _context.Categorias.ToListAsync();
   }

   public async Task<Categoria> IncluirAsync(Categoria categoria)
   {
      EntityEntry<Categoria> retorno = await _context.Categorias.AddAsync(categoria);
      await _context.SaveChangesAsync();

      return retorno.Entity;
   }

   public async Task AlterarAsync(int id, Categoria categoria)
   {
      Categoria? registroNoBanco = await ObterPorId(id);

      if (registroNoBanco == null)
      {
         throw new KeyNotFoundException($"Categoria com ID {id} não encontrada.");
      }
      _context.Entry(registroNoBanco).CurrentValues.SetValues(categoria);
      await _context.SaveChangesAsync();
   }

   public async Task<Categoria?> ObterPorId(int id)
   {
      Categoria? retorno = await _context.Categorias.FindAsync(id);

      return retorno;
   }

   internal async Task ExcluirAsync(int id)
   {
      Categoria? registroNoBanco = await ObterPorId(id);

      if (registroNoBanco == null)
      {
         throw new KeyNotFoundException($"Categoria com ID {id} não encontrada.");
      }

      _context.Categorias.Remove(registroNoBanco);
      await _context.SaveChangesAsync();
   }
}