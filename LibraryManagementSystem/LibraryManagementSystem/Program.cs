namespace LibraryManagementSystem;

public class Program
{
    static void Main(string[] args)
    {
        string root = Directory.GetCurrentDirectory();
        string combinedPaths = Path.Combine(root, @"..\..\..\.\.env");

        string fullPath = Path.GetFullPath(combinedPaths);

        DotEnv.Load(combinedPaths);

        DatabaseManager database = new DatabaseManager();

        Library library = new Library(database);

        library.ViewBooks();
    }
}
