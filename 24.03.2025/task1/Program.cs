using System.ComponentModel.Design;

public delegate bool AccessControl(string userRole);

public class AdminAccess
{
    public bool CheckAcces(string userRole)
    {
        if (userRole.Equals("admin", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Доступ разрешен");
            return true;
        }
        else
        {
            Console.WriteLine("Доступ запрещён: необходимы права администратора");
            return false;
        }
    }
}

public class UserAccess
{
    public bool CheckAccess(string userRole)
    {
        if (!string.IsNullOrEmpty(userRole))
        {
            Console.WriteLine($"Доступ разрешён: Пользователь с ролью: {userRole}");
            return true;
        }
        else
        {
            Console.WriteLine($"Доступ запрещён: Необходима роль пользователя");
            return false;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        AdminAccess adminAccess = new AdminAccess();
        UserAccess userAccess = new UserAccess();

        AccessControl accessDelegate;

        Console.WriteLine("Проверка прав администратора");
        accessDelegate = adminAccess.CheckAcces;
        accessDelegate("admin");
        accessDelegate("user");


        Console.WriteLine("Проверка прав пользователя");
        accessDelegate = userAccess.CheckAccess;
        accessDelegate("user");
        accessDelegate("");
    }
}