namespace TaskWeb.Repositories;

using System.Collections.Generic;
using TaskWeb.Models;
using Microsoft.Data.SqlClient;

public class TarefaDatabaseRepository : DbConnection, ITarefaRepository
{
    public TarefaDatabaseRepository(string? strConn) : base(strConn)
    {        
    }

    public void Create(Tarefa model)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "INSERT INTO Tarefa VALUES (@title, @usuarioId, @tagId)";
        cmd.Parameters.AddWithValue("title", model.Title);
        cmd.Parameters.AddWithValue("usuarioId", model.UsuarioId);
        cmd.Parameters.AddWithValue("tagId", model.TagId);

        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "DELETE FROM Tarefa WHERE TarefaId = @id";
        cmd.Parameters.AddWithValue("id", id);

        cmd.ExecuteNonQuery();
    }

    public List<Tarefa> ReadAll(int usuarioId)
    {
        List<Tarefa> lista = new List<Tarefa>();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT Tarefa.TarefaId, Tarefa.Title, Tarefa.TagId, Tag.Title as TagTitle FROM Tarefa JOIN Tag ON Tarefa.TagId = Tag.TagId WHERE UsuarioId = @usuarioId";

        cmd.Parameters.AddWithValue("usuarioId", usuarioId);

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            lista.Add(new Tarefa
            {
                TarefaId = (int)reader["TarefaId"],
                Title = (string)reader["Title"],
                TagId = (int)reader["TagId"],
                TagName = (string)reader["TagTitle"]
            });
        }

        return lista;
    }

    public Tarefa Read(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Tarefa WHERE TarefaId = @id";
        cmd.Parameters.AddWithValue("id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Tarefa
            {
                TarefaId = (int)reader["TarefaId"],
                Title = (string)reader["Title"],
                TagId = (int)reader["TagId"]
            };
        }

        return null;
    }

    public void Update(Tarefa model)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "UPDATE Tarefa SET Title = @title, TagId = @tagId WHERE TarefaId = @id";
        cmd.Parameters.AddWithValue("id", model.TarefaId);
        cmd.Parameters.AddWithValue("title", model.Title);
        cmd.Parameters.AddWithValue("tagId", model.TagId);

        cmd.ExecuteNonQuery();
    }
}