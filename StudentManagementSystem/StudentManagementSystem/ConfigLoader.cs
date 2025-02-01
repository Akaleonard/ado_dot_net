using DotNetEnv

namespace StudentManagementSystem;

public static class ConfigLoader
{
    public static void LoadEnv()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string combinedPath = Path.Combine(currentDirectory, @"..\..\..\.env");
        string fullPath = Path.GetFullPath(combinedPath);
        Env.Load(fullPath);
    }
}
