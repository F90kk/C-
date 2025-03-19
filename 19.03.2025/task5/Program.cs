using System;

int m = 3; 
int[][] jaggedArray = new int[m][];

Random rand = new Random();
for (int i = 0; i < m; i++)
{
    int n = rand.Next(3, 6);
    jaggedArray[i] = new int[n];
    for (int j = 0; j < n; j++)
    {
        jaggedArray[i][j] = rand.Next(1, 10);
    }
}

Console.WriteLine("Исходный массив:");
for (int i = 0; i < m; i++)
{
    for (int j = 0; j < jaggedArray[i].Length; j++)
    {
        Console.Write(jaggedArray[i][j] + " ");
    }
    Console.WriteLine();
}

int totalSum = 0;
foreach (int[] row in jaggedArray)
{
    foreach (int num in row)
    {
        totalSum += num;
    }
}

int targetSum = totalSum / m;
bool canMakeEqualSums = CanFormEqualSums(jaggedArray, targetSum);

if (canMakeEqualSums)
{
    Console.WriteLine("Можно сделать все строки одинаковой суммы.");
}
else
{
    Console.WriteLine("Нельзя сделать все строки одинаковой суммы.");
}

bool CanFormEqualSums(int[][] array, int targetSum)
{
    int m = array.Length;
    int[] sums = new int[m];
    int[] allElements = new int[totalSum];
    int index = 0;

    foreach (int[] row in array)
    {
        foreach (int num in row)
        {
            allElements[index++] = num;
        }
    }

    Array.Sort(allElements);

    return CanPartition(allElements, sums, 0, targetSum);
}

bool CanPartition(int[] elements, int[] sums, int index, int targetSum)
{
    if (index == elements.Length)
    {
        for (int i = 0; i < sums.Length; i++)
        {
            if (sums[i] != targetSum)
            {
                return false;
            }
        }
        return true;
    }

    for (int i = 0; i < sums.Length; i++)
    {
        if (sums[i] + elements[index] > targetSum)
        {
            continue;
        }

        sums[i] += elements[index];

        if (CanPartition(elements, sums, index + 1, targetSum))
        {
            return true;
        }

        sums[i] -= elements[index];
    }

    return false;
}