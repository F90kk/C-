public interface IUserObserver
{
    void Update(string userName, string status);
}

public class Messenger
{
    private List<IUserObserver> _observers = new List<IUserObserver>();
    private Dictionary<string, string> _userStatuses = new Dictionary<string, string>();

    public void RegisterObserver(IUserObserver observer)
    {
        _observers.Add(observer);
    }

    public void UnregisterObserver(IUserObserver observer)
    {
        _observers.Remove(observer);
    }

    private void NotifyObservers(string userName, string status)
    {
        foreach (var observer in _observers)
        {
            observer.Update(userName, status);
        }
    }

    public void UpdateUserStatus(string userName, string status)
    {
        if (_userStatuses.ContainsKey(userName))
        {
            _userStatuses[userName] = status;
        }
        else
        {
            _userStatuses.Add(userName, status);
        }

        NotifyObservers(userName, status);
    }
}

public class User : IUserObserver
{
    private string _name;

    public User(string name)
    {
        _name = name;
    }

    public void Update(string userName, string status)
    {
        Console.WriteLine($"{_name} получил уведомление: {userName} теперь {status}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Messenger messenger = new Messenger();

        User user1 = new User("Pavel");
        User user2 = new User("Ivan");
        User user3 = new User("Vladimir");

        messenger.RegisterObserver(user1);
        messenger.RegisterObserver(user2);
        messenger.RegisterObserver(user3);

        messenger.UpdateUserStatus("Pavel", "online");
        messenger.UpdateUserStatus("Ivan", "offline");
        messenger.UpdateUserStatus("Vladimr", "online");

        messenger.UnregisterObserver(user2);

        messenger.UpdateUserStatus("Pavel", "offline");
    }
}

