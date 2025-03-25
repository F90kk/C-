using System;
public class ExcessLuggageException : Exception
{
    public ExcessLuggageException() : base()
    {
    }

    public ExcessLuggageException(string message) : base(message)
    {
    }

    public ExcessLuggageException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

public class LuggageChecker
{
    public const int MaxWeight = 23;

    public void CheckWeight(int weight)
    {
        if (weight > MaxWeight)
        {
            throw new ExcessLuggageException($"Вес багажа ({weight} кг) превышает допустимый ({MaxWeight} кг)");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        LuggageChecker luggageChecker = new LuggageChecker();

        int luggageWeight = 25;
        int luggageWeight2 = 20;

        try
        {
            luggageChecker.CheckWeight(luggageWeight);
            Console.WriteLine("Вес в норме");
        }
        catch (ExcessLuggageException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        try
        {
            luggageChecker.CheckWeight(luggageWeight2);
            Console.WriteLine("Вес в норме");
        }
        catch (ExcessLuggageException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}