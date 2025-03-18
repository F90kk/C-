Console.WriteLine("Enter x (x < 0,5 or x > 0,5): ");
double x = double.Parse(Console.ReadLine());
if (x < 0.5)
{
    Console.WriteLine($"y = {(Math.Pow(Math.Log10(x), 3) + Math.Pow(x, 2)) / (Math.Sqrt(x + 2))}");
}
else if (x > 0.5)
{
    Console.WriteLine($"y = {Math.Cos(x) + 2 * Math.Pow(Math.Sin(x), 2)}");
}