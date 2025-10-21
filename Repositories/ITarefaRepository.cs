namespace TaskWeb.Repositories;

using TaskWeb.Models;

public interface ITarefaRepository
{
    void Create(Tarefa model);
    List<Tarefa> ReadAll(int usuarioId );
    Tarefa Read(int id);
    void Update(Tarefa model);
    void Delete(int id);
}