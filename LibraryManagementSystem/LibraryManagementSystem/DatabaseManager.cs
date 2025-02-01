using MySqlConnector;

namespace LibraryManagementSystem;

public class DatabaseManager
{
    string _mySqlConnectionString = Environment.GetEnvironmentVariable("MYSQL_CONNECTION_STRING") ?? throw new InvalidOperationException("MYSQL_CONNECTION_STRING environment variable is not set.");

    public void DBGetBooks()
    {
        using (var conn = new MySqlConnection(_mySqlConnectionString))
        {
            conn.Open();
            using (var cmd = new MySqlCommand("SELECT * FROM books", conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["title"]);
                    }
                }
            }
        }
    }

    public void DBAddBook(string title, string author)
    {
        using (var conn = new MySqlConnection(_mySqlConnectionString))
        {
            conn.Open();
            using (var cmd = new MySqlCommand("INSERT INTO books (title, author) VALUES (@title, @author)", conn))
            {
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@author", author);

                cmd.ExecuteNonQuery();
            }
        }
    }

    public void DBRemoveBook(int bookId)
    {
        using (var conn = new MySqlConnection(_mySqlConnectionString))
        {
            conn.Open();
            using (var cmd = new MySqlCommand("DELETE FROM books WHERE book_id=@book_id", conn))
            {
                cmd.Parameters.AddWithValue("@book_id", bookId);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
