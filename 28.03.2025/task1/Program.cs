using System.Runtime.CompilerServices;

public class AchievementsManager
{
    private static AchievementsManager _instance;

    private static readonly object _lock = new object();

    private List<string> _achievements;

    private AchievementsManager()
    {
        _achievements = new List<string>();
    }

    public static AchievementsManager Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new AchievementsManager();
                    }
                }
            }
            return _instance;
        }
    }

    public void UnlockArchievement (string name)
    {
        if (!_achievements.Contains(name))
        {
            _achievements.Add(name);
            Console.WriteLine($"Достижение |{name}| разблокировано");
        }
        else
        {
            Console.WriteLine($"Достижение |{name}| уже разблокировано");
        }
    }

    public List<string> GetArchievement()
    {
        return new List<string>(_achievements);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var manager = AchievementsManager.Instance;

        manager.UnlockArchievement("Новичок");
        manager.UnlockArchievement("Опытный игрок");

        manager.UnlockArchievement("Новичок");

        var archievements = manager.GetArchievement();
        Console.WriteLine($"Список достижений: ");
        foreach (var archievement in archievements)
        {
            Console.WriteLine(archievement);
        }
    }
}