public delegate void AccountManager(string accountID);

public class AccountService
{
    public void DeleteAccount(string accountID)
    {
        Console.WriteLine($"Аккаунт с ID {accountID} удалён");
    }

    public void RestoreAccount(string accountID)
    {
        Console.WriteLine($"Аккаунт с ID {accountID} восстановлен");
    }

    public void ManageAccount(string accountID, AccountManager action)
    {
        Console.WriteLine($"Выполняются работы с аккаунтом {accountID}");
        action?.Invoke(accountID);
    }
}

class Program
{
    static void Main(string[] args)
    {
        AccountService accountService = new AccountService();

        Console.WriteLine("Удаление аккаунта...");
        accountService.ManageAccount(Convert.ToString(Guid.NewGuid()), accountService.DeleteAccount);

        Console.WriteLine("\nВосстановление аккаунта...");
        accountService.ManageAccount(Convert.ToString(Guid.NewGuid()), accountService.RestoreAccount);
    }
}