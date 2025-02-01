namespace LibraryManagementSystem;

public class Library
{
    private readonly DatabaseManager _databaseManager;

    public Library(DatabaseManager databaseManager)
    {
        _databaseManager = databaseManager;
    }

    public void ViewBooks()
    {
        _databaseManager.DBGetBooks();
    }

    public void AddBook(string title, string author)
    {
        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author))
        {
            Console.WriteLine("Title and author must contain valid values");
            return;
        }
        _databaseManager.DBAddBook(title, author);
        Console.WriteLine("Book successfully added");
    }

    public void RemoveBook(int id)
    {
        _databaseManager.DBRemoveBook(id);
        Console.WriteLine("Book successfully removed");
    }
}
