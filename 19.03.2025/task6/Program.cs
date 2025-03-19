using System;

string input = Console.ReadLine();
char[] allowedChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };

bool isValid = true;
foreach (char c in input)
{
    if (Array.IndexOf(allowedChars, c) == -1)
    {
        isValid = false;
        break;
    }
}
if (isValid)
{
    Console.WriteLine("Строка состоит только из допустимых символов.");
}
else
{
    Console.WriteLine("Строка содержит недопустимые символы.");
}