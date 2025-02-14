﻿namespace LibraryManagementSystem;

public static class DotEnv
{
    public static void Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        foreach (string line in File.ReadAllLines(filePath))
        {
            var parts = line.Split("=", 2, StringSplitOptions.RemoveEmptyEntries);
            //if (parts.Length != 2)
            //{
            //    continue;
            //}

            Environment.SetEnvironmentVariable(parts[0], parts[1]);
        }
    }
}
