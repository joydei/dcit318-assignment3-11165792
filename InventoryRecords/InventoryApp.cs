using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class InventoryApp
{
    private InventoryLogger<InventoryItem> _logger;

    public InventoryApp(string filePath)
    {
        _logger = new InventoryLogger<InventoryItem>(filePath);
    }

    public void SeedSampleData()
    {
        Console.WriteLine("Seeding sample data...");
        _logger.Add(new InventoryItem(1, "Laptop", 10, DateTime.Now));
        _logger.Add(new InventoryItem(2, "Mouse", 50, DateTime.Now));
        _logger.Add(new InventoryItem(3, "Keyboard", 30, DateTime.Now));
    }

    public void SaveData()
    {
        _logger.SaveToFile();
    }

    public void LoadData()
    {
        _logger.LoadFromFile();
    }

    public void PrintAllItems()
    {
        Console.WriteLine("\n--- Current Inventory Items ---");
        var items = _logger.GetAll();
        if (!items.Any())
        {
            Console.WriteLine("No items in inventory.");
            return;
        }
        foreach (var item in items)
        {
            Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}, Date Added: {item.DateAdded:d}");
        }
    }
}