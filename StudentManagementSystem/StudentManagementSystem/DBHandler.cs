namespace StudentManagementSystem;
using MySqlConnector;

public class DBHandler
{
    private readonly string _connectionString;

    public DBHandler()
    {
        _connectionString = Environment.GetEnvironmentVariable("MYSQL_CONNECTION_STRING") 
            ?? throw new InvalidOperationException("MYSQL_CONNECTION_STRING environement variable is not set");
    }

    private MySqlConnection GetMySqlConnection()
    {
        return new MySqlConnection(_connectionString);
    }

    public int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
    {
        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            using (var cmd = new MySqlCommand(query, conn))
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
                return cmd.ExecuteNonQuery();
            }
        }
    }
}

