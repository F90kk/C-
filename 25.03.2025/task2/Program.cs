using System;
using System.IO;

public class ReportGenerationException : Exception
{
    public ReportGenerationException() : base()
    {
    }
    public ReportGenerationException(string message) : base(message)
    {
    }
    public ReportGenerationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

public class ReportGenerator
{
    public void GenerateReport()
    {
        throw new IOException("Диск заполнен. Невозможно сгенерировать отчет.");
    }
}

public class ReportManager
{
    private readonly ReportGenerator _reportGenerator;

    public ReportManager(ReportGenerator reportGenerator)
    {
        _reportGenerator = reportGenerator;
    }

    public void GenerateReport()
    {
        try
        {
            _reportGenerator.GenerateReport();
        }
        catch (IOException ex)
        {
            LogException(ex);

            throw new ReportGenerationException("Ошибка при генерации отчета", ex);
        }
    }

    private void LogException(Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");

        Console.WriteLine($"Стек вызовов: {ex.StackTrace}");

        if (ex.InnerException != null)
        {
            Console.WriteLine($"Внутреннее исключение: {ex.InnerException.Message}");
            Console.WriteLine($"Стек вызовов внутреннего исключения: {ex.InnerException.StackTrace}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ReportGenerator reportGenerator = new ReportGenerator();
        ReportManager reportManager = new ReportManager(reportGenerator);

        try
        {
            reportManager.GenerateReport();
            Console.WriteLine("Отчет успешно сгенерирован.");
        }
        catch (ReportGenerationException ex)
        {
            Console.WriteLine($"Ошибка при генерации отчета: {ex.Message}");
            Console.WriteLine($"Стек вызовов: {ex.StackTrace}");
            Console.WriteLine($"Внутреннее исключение: {ex.InnerException.Message}");
            Console.WriteLine($"Стек вызовов внутреннего исключения: {ex.InnerException.StackTrace}");
        }
    }
}