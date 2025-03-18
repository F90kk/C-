Console.Write("Enter A: ");
double n = double.Parse(Console.ReadLine());
double sum = 0;

for (int i = 0; i < n; i++)
{
    sum += Math.Pow(n, i);
    Console.WriteLine(Math.Round(sum, 4));
}