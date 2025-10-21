namespace TaskWeb.Repositories;

using System.Collections.Generic;
using TaskWeb.Models;
using Microsoft.Data.SqlClient;

public class UsuarioDatabaseRepository : DbConnection, IUsuarioRepository
{
    public UsuarioDatabaseRepository(string? strConn) : base(strConn)
    {
        
    }

    public Usuario Login(LoginViewModel model)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Usuario WHERE Email = @email AND Senha = @senha";
        cmd.Parameters.AddWithValue("email", model.Email);
        cmd.Parameters.AddWithValue("senha", model.Senha);

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Usuario
            {
                UsuarioId = (int)reader["UsuarioId"],
                Email = (string)reader["Email"],
                Nome = (string)reader["Nome"]
            };
        }

        return null;
    }
}