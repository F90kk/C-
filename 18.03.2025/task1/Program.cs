Console.Write("Enter a: ");
int a = int.Parse(Console.ReadLine());
Console.Write("Enter b: ");
int b = int.Parse(Console.ReadLine());
Console.WriteLine($"Arithmetic mean: {(a+b) / 2}");
Console.WriteLine($"Geometric mean of their modules: {Math.Sqrt(Math.Abs(a * b))}");