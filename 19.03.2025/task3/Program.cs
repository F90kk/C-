using System;

int N;
Console.Write("Введите размер матрицы N (N < 10): ");
if (!int.TryParse(Console.ReadLine(), out N) || N <= 0 || N >= 10)
{
    Console.WriteLine("Некорректное значение N. Введите число от 1 до 9.");
    return;
}

int a, b;
Console.Write("Введите нижний диапазон a: ");
if (!int.TryParse(Console.ReadLine(), out a))
{
    Console.WriteLine("Некорректное значение a.");
    return;
}

Console.Write("Введите верхний диапазон b: ");
if (!int.TryParse(Console.ReadLine(), out b) || a > b)
{
    Console.WriteLine("Некорректное значение b. b должно быть больше или равно a.");
    return;
}

Random rand = new Random();
int[,] matrix = new int[N, N];

Console.WriteLine("Исходная матрица:");
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        matrix[i, j] = rand.Next(a, b + 1);
        Console.Write(matrix[i, j].ToString().PadLeft(4));
    }
    Console.WriteLine();
}

int[] flatArray = new int[N * N];
int index = 0;
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        flatArray[index++] = matrix[i, j];
    }
}

Array.Sort(flatArray);

Console.WriteLine("Отсортированный массив:");
for (int i = 0; i < flatArray.Length; i++)
{
    Console.Write(flatArray[i].ToString().PadLeft(4));
    if ((i + 1) % N == 0)
    {
        Console.WriteLine();
    }
}

Console.Write("Введите число k для поиска: ");
if (!int.TryParse(Console.ReadLine(), out int k))
{
    Console.WriteLine("Некорректное значение k.");
    return;
}

int searchIndex = Array.BinarySearch(flatArray, k);

if (searchIndex >= 0)
{
    Console.WriteLine($"Число {k} найдено в массиве на позиции {searchIndex}.");
}
else
{
    Console.WriteLine($"Число {k} не найдено в массиве.");
}