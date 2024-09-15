using System;
using System.IO;

/*
 * Завдання 6
 * Створіть на диску 100 директорій із іменами
 * від Folder_0 до Folder_99, потім видаліть їх.
 */
class Program
{
    static void Main()
    {
        string baseDirectory =
            @"/Users/yanamakogon/Documents/net developer/c#/C# professional/BaseDirectory";
        
        if (!Directory.Exists(baseDirectory))
        {
            Directory.CreateDirectory(baseDirectory);
        }
        
        // Створення 100 директорій
        for (int i = 0; i < 100; i++)
        {
            string folderName = Path.Combine(baseDirectory, $"Folder_{i}");
            Directory.CreateDirectory(folderName);
            Console.WriteLine($"Створено директорію: {folderName}");
        }

        Console.WriteLine("Всі директоріі створено\n");
        
        // Видалення 100 директорій

        for (int i = 0; i < 100; i++)
        {
            string forlderName = Path.Combine(baseDirectory, $"Folder_{i}");
            Directory.Delete(forlderName);
            Console.WriteLine($"Видалено директорію: {forlderName}");
        }
        Console.WriteLine("Всі дерикторіі видалено");
    }
}