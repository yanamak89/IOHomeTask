/*
 * Завдання 2
 * Створіть файл, запишіть у нього довільні дані та закрийте файл.
 * Потім знову відкрийте цей файл, прочитайте дані і виведіть їх
 * на консоль.
 */


class Program
{
    public static void Main(string[] args)
    {
        string fileName = "example.txt";
        string fullPath = Path.GetFullPath(fileName); // Отримуємо повний шлях до файлу
        string textToWrite = "Це приклад тексту, який записується у файл.";
        
        // Створюємо файл та записуємо у нього дані
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(textToWrite);
        }

        Console.WriteLine("Данні записано у файл");
        Console.WriteLine($"Файл розташований за шляхом: {fullPath}");

        
        // Читаємо дані з файлу та виводимо на консоль
        using (StreamReader reader = new StreamReader(fileName))
        {
            string fileContent = reader.ReadToEnd();
            Console.WriteLine("Зміст файлу:");
            Console.WriteLine(fileContent);
        }
        
    }
}