/*
 * Напишіть програму для пошуку заданого файлу на диску.
 * Додайте код, який використовує клас FileStream і дозволяє
 * переглядати файл у текстовому вікні. Насамкінець додайте
 * можливість стиснення знайденого файлу.
 */

using System.IO.Compression;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введіть ім'я файлу для пошуку: ");
        // NewFile1.txt
        string fileName = Console.ReadLine();
        
        Console.WriteLine("Введіть шлях до директорії, де шукати файл: ");
        // /Users/yanamakogon/RiderProjects/IOHomeTask/Task3/
        string directoryPath = Console.ReadLine();
        
        // Пошук файлу
        string foundFile = FindFile(directoryPath, fileName);

        if (foundFile != null)
        {
            Console.WriteLine($"Файл знайдень: {foundFile}");
            
            // Читання та перегляд вмісту файлу за допомогою FileStream
            Console.WriteLine("\nЗміст файлу: ");
            ReadFileWithFileStream(foundFile);
            
            // Стиснення файлу
            CompressFile(foundFile);
            Console.WriteLine($"Файл стиснуто: {foundFile}.gz");
        }
        else
        {
            Console.WriteLine("Файл не знайдено.");
        }
    }

    static string FindFile(string directory, string fileName)
    {
        try
        {
            foreach (string file in Directory.GetFiles(directory, fileName, SearchOption.AllDirectories))
            {
                return file;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка під час пошуку файлу: {ex.Message}");
        }
        return null;
    }
    
    static void ReadFileWithFileStream(string filePath)
    {
        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine(content);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка під час читання файлу: {ex.Message}");
        }
    }

    static void CompressFile(string filePath)
    {
        try
        {
            string compressedFile = filePath + ".gz";
            using (FileStream originalFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream compressedFileStream = new FileStream(compressedFile, FileMode.Create))
                {
                    using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressionStream);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка під час стиснення файлу: {ex.Message}");
        }
    }
}
