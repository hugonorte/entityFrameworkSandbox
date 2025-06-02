public class Tarefa
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public required string Descricao { get; set; }
    public bool Concluida { get; set; } = false;

    public required Categoria Categoria { get; set; }
    public int CategoriaId { get; set; }
}