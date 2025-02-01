namespace StudentManagementSystem;

public class StudentRepository
{
    private readonly DBHandler _dBHandler;

    public StudentRepository(DBHandler dBHandler)
    {
        _dBHandler = dBHandler;
    }

    public void AddStudent(string name, int age)
    {
        string query = "INSERT INTO students (name, age) VALUES (@name, @age)";
        var parameters = new Dictionary<string, object>
        {
            { "@name", name},
            { "@age" , age }
        };
        _dBHandler.ExecuteNonQuery(query, parameters);
    }
}
