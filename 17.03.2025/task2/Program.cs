string x = Console.ReadLine();
int result = int.Parse(new string(new char[] { x[3], x[1], x[2], x[0] }));
Console.WriteLine($"число, образуемое при перестановке первой и последней цифр: {result}");