int[] arr = new int[] { 15, 30, 24, 45, 67, 23, 12, 45, 13 };
int count = 0;
Console.WriteLine("Исходный массив:");
foreach (int num in arr)
{
    Console.Write(num + " ");
}
Console.WriteLine();
Array.Sort(arr);
Console.WriteLine("Отсортированный массив:");
foreach (int num in arr)
{
    Console.Write(num + " ");
}
Console.WriteLine();
Console.Write("Введите число k для поиска: ");
if (!int.TryParse(Console.ReadLine(), out int k))
{
    Console.WriteLine("Некорректный ввод. Введите целое число.");
    return;
}
int index = Array.BinarySearch(arr, k);
if (index >= 0)
{
    Console.WriteLine($"Число {k} найдено в массиве на позиции {index}.");
}
else
{
    Console.WriteLine($"Число {k} не найдено в массиве.");
}
for (int i = 0; i < arr.Length; i++)
{
    if (arr[i] % 3 == 0 && arr[i] % 5 != 0)
    {
        count++;
    }
}
Console.WriteLine("Количество чисел, кратных 3 и не кратных 5: " + count);