namespace TaskWeb.Models;

public class Tarefa
{
    public int TarefaId { get; set; }
    public string Title { get; set; }
    public int UsuarioId { get; set; }
    public int TagId { get; set; }
    public string TagName { get; set; }
}