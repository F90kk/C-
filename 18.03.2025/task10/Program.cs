Console.Write("Введите число: ");
string input = Console.ReadLine();

if (!int.TryParse(input, out int number))
{
    Console.WriteLine("Некорректный ввод. Введите целое число.");
    return;
}

int result = 0;
int multiplier = 1;

while (number != 0)
{
    int digit = number % 10; 

    if (digit % 2 != 0) 
    {
        result += digit * multiplier; 
        multiplier *= 10; 
    }

    number /= 10; 
}

Console.WriteLine("Результат: " + result);