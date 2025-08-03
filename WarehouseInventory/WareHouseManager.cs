using System;
using System.Collections.Generic;

public class WareHouseManager
{
    private InventoryRepository<ElectronicItem> _electronics = new InventoryRepository<ElectronicItem>();
    private InventoryRepository<GroceryItem> _groceries = new InventoryRepository<GroceryItem>();

    // Public properties to access the repositories
    public InventoryRepository<ElectronicItem> Electronics => _electronics;
    public InventoryRepository<GroceryItem> Groceries => _groceries;

    public void SeedData()
    {
        _electronics.AddItem(new ElectronicItem(1, "Smartphone", 50, "Apple", 12));
        _electronics.AddItem(new ElectronicItem(2, "Laptop", 25, "Dell", 24));
        
        _groceries.AddItem(new GroceryItem(101, "Milk", 100, DateTime.Today.AddDays(7)));
        _groceries.AddItem(new GroceryItem(102, "Bread", 75, DateTime.Today.AddDays(3)));
    }

    public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
    {
        Console.WriteLine($"\n--- Inventory Items ({typeof(T).Name}) ---");
        foreach (var item in repo.GetAllItems())
        {
            Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}");
        }
    }

    public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
    {
        try
        {
            var item = repo.GetItemById(id);
            repo.UpdateQuantity(id, item.Quantity + quantity);
            Console.WriteLine($"Successfully increased stock for {item.Name} (ID: {id}). New quantity: {item.Quantity}");
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine($"Error increasing stock: {ex.Message}");
        }
        catch (InvalidQuantityException ex)
        {
            Console.WriteLine($"Error increasing stock: {ex.Message}");
        }
    }

    public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
    {
        try
        {
            repo.RemoveItem(id);
            Console.WriteLine($"Successfully removed item with ID {id}.");
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine($"Error removing item: {ex.Message}");
        }
    }
    
    public void AddItemWithExceptionHandling()
    {
        try
        {
            _groceries.AddItem(new GroceryItem(101, "Yogurt", 20, DateTime.Today.AddDays(14)));
        }
        catch (DuplicateItemException ex)
        {
            Console.WriteLine($"\n--- Handling Duplicate Item Exception ---");
            Console.WriteLine($"Error adding item: {ex.Message}");
        }
    }
}