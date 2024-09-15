using System;
using System.IO;
using System.IO.IsolatedStorage;

/*
 * Створіть програму WPF Application, яка дозволяє користувачам
 * зберігати дані в ізольованому сховищі.
 *
 * консольний застосунок для зберігання даних у ізольованому сховищі на Mac
 */
class Program
{
    static void Main()
    {
        // Створення або відкриття ізольованого сховища
        using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly())
        {
            string fileName = "UserData.txt";

            // Запис даних в ізольоване сховище
            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(fileName, FileMode.OpenOrCreate, isolatedStorage))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine("Привіт з ізольованого сховища!");
                    writer.WriteLine("Дані зберігаються у захищеній зоні.");
                    Console.WriteLine("Дані успішно збережені в ізольованому сховищі.");
                }
            }

            // Читання даних з ізольованого сховища
            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(fileName, FileMode.Open, isolatedStorage))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine("Зміст ізольованого сховища:");
                    Console.WriteLine(content);
                }
            }
        }
    }
}