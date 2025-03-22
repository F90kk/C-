using System.Threading.Tasks;

public interface ITAskScheduler
{
    void Shedule(string taskName);
}

public interface IAlarmScheduler
{
    void Shedule(string taskName);
}

public class Scheduler : ITAskScheduler, IAlarmScheduler
{
    void ITAskScheduler.Shedule(string taskName)
    {
       Console.WriteLine($"Task scheduled via ITaskScheduler: {taskName}");
    }

    void IAlarmScheduler.Shedule(string taskName)
    {
        Console.WriteLine($"Alarm scheduled via IAlarmScheduler: {taskName}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Scheduler scheduler = new Scheduler();

        ITAskScheduler tAskScheduler = scheduler;
        IAlarmScheduler alarmScheduler = scheduler;

        tAskScheduler.Shedule("Daily Backup");

        alarmScheduler.Shedule("Mornin Alarm");
    }
}