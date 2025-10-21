namespace TaskWeb.Repositories;

using System.Collections.Generic;
using TaskWeb.Models;
using Microsoft.Data.SqlClient;

public class TagDatabaseRepository : DbConnection, ITagRepository
{
    public TagDatabaseRepository(string? strConn) : base(strConn)
    {        
    }

    public void Create(Tag tag)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "INSERT INTO Tag VALUES (@title)";
        cmd.Parameters.AddWithValue("title", tag.Title);

        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "DELETE FROM Tag WHERE TagId = @id";
        cmd.Parameters.AddWithValue("id", id);

        cmd.ExecuteNonQuery();
    }

    public List<Tag> Read()
    {
        List<Tag> tags = new List<Tag>();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Tag";

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            tags.Add(new Tag
            {
                TagId = (int)reader["TagId"],
                Title = (string)reader["Title"]
            });
        }

        return tags;
    }

    public Tag Read(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Tag WHERE TagId = @id";
        cmd.Parameters.AddWithValue("id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Tag
            {
                TagId = (int)reader["TagId"],
                Title = (string)reader["Title"]
            };
        }

        return null;
    }

    public void Update(Tag tag)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "UPDATE Tag SET Title = @title WHERE TagId = @id";
        cmd.Parameters.AddWithValue("id", tag.TagId);
        cmd.Parameters.AddWithValue("title", tag.Title);

        cmd.ExecuteNonQuery();
    }
}