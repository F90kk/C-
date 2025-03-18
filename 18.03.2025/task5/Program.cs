Console.Write("Введите трёзначное число: ");
int num = int.Parse(Console.ReadLine());
if (num % 111 == 0)
{
    Console.WriteLine("В трёхзначном числе все цифры одинаковые");
}
else
{
    Console.WriteLine("Не одинаковые");
}