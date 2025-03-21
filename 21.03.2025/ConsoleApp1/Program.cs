public static class MathUtilities
{
    public static int SumOfDigits(int number)
    {
        int sum = 0;
        number = Math.Abs(number);

        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }

        return sum;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        int sum = MathUtilities.SumOfDigits(number);
        Console.WriteLine($"The sum of the digits or {number} is {sum}");

    }
}