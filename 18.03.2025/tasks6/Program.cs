Console.Write("Введите номер спортсмена: ");
int num = int.Parse(Console.ReadLine());

switch (num)
{
    case int i when num == 1 || num == 2 || num == 9:
        Console.WriteLine("Баскетбол");
        break;

    case int i when num == 2 || num == 4 || num == 5:
        Console.WriteLine("Бег");
        break;

    case int i when num == 6 || num == 7 || num == 8:
        Console.WriteLine("Штанга");
        break;
}