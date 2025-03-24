public class OrderStatusManager
{
    public event EventHandler<string> StatusChanged;

    public void ChangeStatus(string newStatus)
    {
        Console.WriteLine($"Менеджер заказов: Статус заказа изменен на '{newStatus}'");
        OnStatusChanged(newStatus);
    }

    protected virtual void OnStatusChanged(string newStatus)
    {
        StatusChanged?.Invoke(this, newStatus);
    }
}

public class CustomerNotifier
{
    public void NotifyCustomer(object sender, string newStatus)
    {
        Console.WriteLine($"Уведомление клиента: Ваш заказ теперь имеет статус '{newStatus}'");
    }
}

public class AdminLogger
{
    public void LogStatusChange(object sender, string newStatus)
    {
        Console.WriteLine($"Логирование администратора: Статус заказа изменен на '{newStatus}'");

    }
}

public class StatusObserver
{
    public static void Subscribe(OrderStatusManager orderStatusManager, CustomerNotifier customerNotifier, AdminLogger adminLogger)
    {
        orderStatusManager.StatusChanged += customerNotifier.NotifyCustomer;
        orderStatusManager.StatusChanged += adminLogger.LogStatusChange;
    }
}

class Program
{
    static void Main(string[] args)
    {
        OrderStatusManager orderStatusManager = new OrderStatusManager();
        CustomerNotifier customerNotifier = new CustomerNotifier();
        AdminLogger adminLogger = new AdminLogger();

        StatusObserver.Subscribe(orderStatusManager, customerNotifier, adminLogger);

        Console.WriteLine("Начало изменения статуса заказа:");
        orderStatusManager.ChangeStatus("Обработан");
        orderStatusManager.ChangeStatus("Отправлен");
    }
}