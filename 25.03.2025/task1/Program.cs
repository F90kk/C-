using System;

public class ExpiredProductException : Exception
{
    public ExpiredProductException() : base()
    {
    }

    public ExpiredProductException(string message) : base(message)
    {
    }

    public ExpiredProductException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
public class Product
{
    public void CheckExpiration(DateTime expirationDate)
    {
        if (DateTime.Now > expirationDate)
        {
            throw new ExpiredProductException("Продукт просрочен!");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Product product = new Product();
        DateTime expirationDate = DateTime.Now.AddDays(-1); 
        DateTime expirationDate2 = DateTime.Now.AddDays(+3);
        try
        {
            product.CheckExpiration(expirationDate);
            Console.WriteLine($"Продукт в порядке. Срок годноости до {expirationDate}");
        }
        catch (ExpiredProductException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}. Срок годноости до {expirationDate}");
        }

        try
        {
            product.CheckExpiration(expirationDate2);
            Console.WriteLine($"Продукт в порядке. Срок годноости до {expirationDate2}");
        }
        catch (ExpiredProductException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}. Срок годноости до {expirationDate2}");
        }
    }
}