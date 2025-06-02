using UserAuthApi.Models;
using System.Collections.Generic;

namespace  UserAuthApi.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public List<Tarefa> Tarefas { get; set; } 
    }
}
