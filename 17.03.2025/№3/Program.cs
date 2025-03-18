double a = double.Parse(Console.ReadLine());

Console.WriteLine($"z1: {Math.Cos(a) + Math.Cos(2 * a) + Math.Cos(6 * a) + Math.Cos(7 * a)}");
Console.WriteLine($"z2: {4 * Math.Cos(a / 2) * Math.Cos((5 / 2) * a) * Math.Cos(4 * a)}");