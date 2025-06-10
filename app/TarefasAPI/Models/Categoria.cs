namespace TarefasAPI.Models;
using TarefasAPI.Models;

public class Categoria
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public List<Tarefa> Tarefas { get; set; } = [];
}