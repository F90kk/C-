using Microsoft.VisualBasic;
using System;

public static class DateTimeExtensions
{
    public static string GetDayOfWeek(this DateTime date)
    {
        switch (date.DayOfWeek)
        {
            case DayOfWeek.Monday:
                return "понедельник";
            case DayOfWeek.Tuesday:
                return "вторник";
            case DayOfWeek.Wednesday:
                return "среда";
            case DayOfWeek.Thursday:
                return "четверг";
            case DayOfWeek.Friday:
                return "пятница";
            case DayOfWeek.Saturday:
                return "суббота";
            case DayOfWeek.Sunday:
                return "воскресенье";
            default:
                throw new InvalidOperationException("Invalid day of week.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        DateTime currentTime = DateTime.Now;
        Console.WriteLine($"Current date: {currentTime}");
        Console.WriteLine($"Day of week: {currentTime.GetDayOfWeek()}");

        DateTime specificDate = new DateTime(2023, 10, 15);
        Console.WriteLine($"\nSpecific date: {specificDate}");
        Console.WriteLine($"Day of week: {specificDate.GetDayOfWeek()}");
    }
}