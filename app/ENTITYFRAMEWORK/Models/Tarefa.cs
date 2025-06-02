using UserAuthApi.Models;


namespace  UserAuthApi.Models;

public class Tarefa
{
    public int Id {get;set;}
    public required string Nome {get;set;}
    public required string Descrição {get;set;}
    public bool Concluida {get;set;}


    //essa categoria liga essa tarefa a outra categoria
    public required Categoria Categoria {get;set;}
    public int CategoriaId {get;set;}
}