Console.Write("Enter a number between -999 and 999: ");
string input = Console.ReadLine();

if (int.TryParse(input, out int num) && num >= -999 && num <= 999)
{
    switch (num)
    {
        case 0:
            Console.WriteLine("Нулевое число");
            break;

        case int i when num > 0 && num < 10:
            Console.WriteLine("Положительное однозначное число");
            break;

        case int i when num >= 10 && num < 100:
            Console.WriteLine("Положительное двузначное число");
            break;

        case int i when num >= 100 && num <= 999:
            Console.WriteLine("Положительное трехзначное число");
            break;

        case int i when num <= -1 && num >= -9:
            Console.WriteLine("Отрицательное однозначное число");
            break;

        case int i when num <= -10 && num >= -99:
            Console.WriteLine("Отрицательное двузначное число");
            break;

        case int i when num <= -100 && num >= -999:
            Console.WriteLine("Отрицательное трехзначное число");
            break;

        default:
            Console.WriteLine("Число вне диапазона");
            break;
    }
}
else
{
    Console.WriteLine("Число должно быть в диапазоне от -999 до 999");
}