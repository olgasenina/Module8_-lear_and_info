using System;
using System.IO;

namespace Module8_Сlear_and_info
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите путь к каталогу ");

            // Сохраним указанный путь
            DirectoryInfo dirInfo = new DirectoryInfo(Console.ReadLine());

            long SizeBefore = 0;    // размер до
            long SizeAfter = 0;     // размер после

            // Показать, сколько весит папка до очистки.
            try
            {
                SizeBefore = FolderSettings.SizeFolder(dirInfo);
                Console.WriteLine($"Исходный размер папки: {SizeBefore} байт");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Не удалось рассчитать исходный размер: {e.Message}");
            }

            // Выполнить очистку.
            try
            {
                DirectoryWork.DeleteOldFiles(dirInfo);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Не удалось очистить папку: {e.Message}");
            }

            // Показать, сколько папка весит после очистки.
            try
            {
                SizeAfter = FolderSettings.SizeFolder(dirInfo);
                Console.WriteLine($"Освобождено: {SizeBefore- SizeAfter}");
                Console.WriteLine($"Текущий размер папки: {SizeAfter} байт");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Не удалось рассчитать текущий размер: {e.Message}");
            }

            Console.ReadKey();
        }
    }
}
