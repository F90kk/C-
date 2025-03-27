using System;
using System.IO;

class FileManager
{
    public void CreateFile(string filePath, string content)
    {
        File.WriteAllText(filePath, content);
        Console.WriteLine($"Файл {filePath} успешно создан.");
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        if (!File.Exists(sourcePath))
        {
            throw new FileNotFoundException($"Файл {sourcePath} не найден.");
        }
        File.Copy(sourcePath, destinationPath, true);
        Console.WriteLine($"Файл {sourcePath} скопирован в {destinationPath}");
    }

    public void DeleteFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Файл {filePath} не найден.");
        }
        File.Delete(filePath);
        Console.WriteLine($"Файл {filePath} успешно удален.");
    }

    public void RenameFile(string oldFilePath, string newFileName)
    {
        string directory = Path.GetDirectoryName(oldFilePath);
        string newFilePath = Path.Combine(directory, newFileName);

        if (!File.Exists(oldFilePath))
        {
            throw new FileNotFoundException($"Файл {oldFilePath} не найден.");
        }
        File.Move(oldFilePath, newFilePath);
        Console.WriteLine($"Файл {oldFilePath} переименован в {newFilePath}");
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        if (!File.Exists(sourcePath))
        {
            throw new FileNotFoundException($"Файл {sourcePath} не найден.");
        }
        File.Move(sourcePath, destinationPath);
        Console.WriteLine($"Файл {sourcePath} перемещен в {destinationPath}");
    }
}

class FileInfoProvider
{
    public void GetFileInfo(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Файл {filePath} не найден.");
        }

        FileInfo fileInfo = new FileInfo(filePath);
        Console.WriteLine($"Имя файла: {fileInfo.Name}");
        Console.WriteLine($"Размер файла: {fileInfo.Length} байт");
        Console.WriteLine($"Дата создания: {fileInfo.CreationTime}");
        Console.WriteLine($"Дата последнего изменения: {fileInfo.LastWriteTime}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        string fileName = "Kovchick.va"; // Фамилия + инициалы имени и отчества
        string filePath = Path.Combine(Environment.CurrentDirectory, fileName); // Путь к файлу

        FileManager fileManager = new FileManager();
        FileInfoProvider fileInfoProvider = new FileInfoProvider();

        try
        {
            fileManager.CreateFile(filePath, "Пример содержимого файла.");
            Console.WriteLine("Содержимое файла:");
            Console.WriteLine(File.ReadAllText(filePath));

            if (File.Exists(filePath))
            {
                Console.WriteLine($"Файл {filePath} существует.");
            }
            else
            {
                Console.WriteLine($"Файл {filePath} не существует.");
            }

            fileInfoProvider.GetFileInfo(filePath);

            string copyPath = Path.Combine(Environment.CurrentDirectory, "copy_" + fileName);
            fileManager.CopyFile(filePath, copyPath);
            if (File.Exists(copyPath))
            {
                Console.WriteLine($"Копия файла {copyPath} успешно создана.");
            }

            string newPath = Path.Combine(Environment.CurrentDirectory, "new_folder", fileName);
            Directory.CreateDirectory(Path.GetDirectoryName(newPath)); // Создаем директорию, если она не существует
            fileManager.MoveFile(filePath, newPath);

            string renamedPath = Path.Combine(Path.GetDirectoryName(newPath), "familiya.io");
            fileManager.RenameFile(newPath, "familiya.io");

            try
            {
                fileManager.DeleteFile("nonexistent_file.va");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            string secondFilePath = Path.Combine(Environment.CurrentDirectory, "another_file.ii");
            File.WriteAllText(secondFilePath, "Другой текст");

            long fileSize1 = new FileInfo(filePath).Length;
            long fileSize2 = new FileInfo(secondFilePath).Length;

            Console.WriteLine($"Размер первого файла: {fileSize1} байт");
            Console.WriteLine($"Размер второго файла: {fileSize2} байт");

            if (fileSize1 > fileSize2)
            {
                Console.WriteLine("Первый файл больше.");
            }
            else if (fileSize1 < fileSize2)
            {
                Console.WriteLine("Второй файл больше.");
            }
            else
            {
                Console.WriteLine("Файлы равны по размеру.");
            }

            string folderPath = Environment.CurrentDirectory;
            string[] iiFiles = Directory.GetFiles(folderPath, "*.ii");
            foreach (var file in iiFiles)
            {
                File.Delete(file);
                Console.WriteLine($"Файл {file} удален.");
            }

            string[] filesInDirectory = Directory.GetFiles(folderPath);
            Console.WriteLine("\nСписок файлов в директории:");
            foreach (var file in filesInDirectory)
            {
                Console.WriteLine(file);
            }

            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                try
                {
                    File.WriteAllText(filePath, "Новый текст"); // Это вызовет исключение
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Ошибка записи в файл: {ex.Message}");
                }
            }

            string testFilePath = Path.Combine(folderPath, "test_file.txt");
            File.WriteAllText(testFilePath, "Тестовый текст");

            if (File.Exists(testFilePath))
            {
                Console.WriteLine($"Права доступа к файлу {testFilePath}:");
                Console.WriteLine($"Можно читать: {File.Exists(testFilePath)}");
                Console.WriteLine($"Можно записывать: {true}"); 
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}