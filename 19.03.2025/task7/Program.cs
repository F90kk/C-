using System;
using System.Collections.Generic;

List<string> list = new List<string> { "Apple", "Banana", "Cherry", "Date", "Elderberry" };
string input = Console.ReadLine();

bool contains = false;
foreach (string item in list)
{
    if (item.Equals(input, StringComparison.OrdinalIgnoreCase))
    {
        contains = true;
        break;
    }
}

if (contains)
{
    Console.WriteLine("Строка содержится в списке.");
}
else
{
    Console.WriteLine("Строка не содержится в списке.");
}