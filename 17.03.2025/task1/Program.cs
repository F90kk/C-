double x = double.Parse(Console.ReadLine());
int y = int.Parse(Console.ReadLine());
Console.WriteLine($"Округлённный с точностью до 4 знаков: {Math.Round((3 * x) / y, 4)}");