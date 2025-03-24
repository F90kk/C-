public delegate void ItemMovedHandler(string itemName, int quality);

public class WarehouseMonitor
{
    public event ItemMovedHandler ItemMoved;

    public void MoveItem(string itemName, int quality)
    {
        Console.WriteLine($"Склад: {itemName} перемещён в кол-ве {quality} шт");
        OnItemMoved(itemName, quality);
    }

    protected virtual void OnItemMoved(string itemName, int quality)
    {
        ItemMoved?.Invoke(itemName, quality);
    }
}

public class InventorySystem
{
    public void UpdateInventory(string itemName, int quality)
    {
        Console.WriteLine($"Инвентарь: Данные о товаре {itemName} обновлены. Новое кол-во {quality}");
    }
}

public class SecuritySystem
{
    public void CheckPermission(string itemName, int quality)
    {
        Console.WriteLine($"Система безопасности: Разрешения для товара {itemName} проверены");
    }
}

class Program
{
    static void Main(string[] args)
    {
        WarehouseMonitor warehouseMonitor = new WarehouseMonitor();
        InventorySystem inventorySystem = new InventorySystem();
        SecuritySystem securitySystem = new SecuritySystem();

        warehouseMonitor.ItemMoved += inventorySystem.UpdateInventory;
        warehouseMonitor.ItemMoved += securitySystem.CheckPermission;

        Console.WriteLine($"Начало перемещения товаров...");
        warehouseMonitor.MoveItem("Ноутбук", 2);
        warehouseMonitor.MoveItem("Книги", 30);
    }
}