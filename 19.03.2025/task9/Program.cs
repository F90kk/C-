using System;
using System.Text.RegularExpressions;

string text = "Уругвай чиф-киф хахаха бамбалейла";
Console.Write("Введите букву: ");
char letter = Console.ReadLine()[0];
string pattern = $@"\b{letter}[а-яА-Я]*";
Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
MatchCollection matches = regex.Matches(text);

if (matches.Count > 0)
{
    Console.WriteLine("Найденные слова:");
    foreach (Match match in matches)
    {
        Console.WriteLine(match.Value);
    }
}
else
{
    Console.WriteLine($"Нет слов, начинающихся на букву {letter}");
}