Console.Write("Enter A: ");
int a = int.Parse(Console.ReadLine());
Console.Write("Enter B: ");
int b = int.Parse(Console.ReadLine());

for (int i = a; i <= b; i++)
{
    if (i % 2 == 0 & i % 5 == 0)
    {
        Console.WriteLine(i);
    }
}

int i = a;
while (i <= b)
{
    if (i % 2 == 0 && i % 5 == 0)
    {
        Console.WriteLine(i);
    }
    i++;
}

int i = a;
do
{
    if (i % 2 == 0 && i % 5 == 0)
    {
        Console.WriteLine(i);
    }
    i++;
} while (i <= b);