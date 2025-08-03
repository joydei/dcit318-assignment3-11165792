using System;

class Program
{
    static void Main(string[] args)
    {
        // i. Instantiate WareHouseManager
        var manager = new WareHouseManager();

        // ii. Call SeedData()
        manager.SeedData();

        // iii. Print all grocery items
        manager.PrintAllItems(manager.Groceries);

        // iv. Print all electronic items
        manager.PrintAllItems(manager.Electronics);
        
        // v. Demonstrate exception handling
        
        // Add a duplicate item (ID 101 already exists)
        manager.AddItemWithExceptionHandling();

        // Try to remove a non-existent item (ID 999)
        Console.WriteLine("\n--- Handling Item Not Found Exception ---");
        manager.RemoveItemById(manager.Groceries, 999);
        
        // Try to update with an invalid quantity
        Console.WriteLine("\n--- Handling Invalid Quantity Exception ---");
        try
        {
            manager.Electronics.UpdateQuantity(1, -10);
        }
        catch (InvalidQuantityException ex)
        {
            Console.WriteLine($"Error updating quantity: {ex.Message}");
        }

        // Demonstrate a successful operation
        Console.WriteLine("\n--- Demonstrating a successful operation ---");
        manager.IncreaseStock(manager.Groceries, 101, 50);
        manager.PrintAllItems(manager.Groceries);
    }
}