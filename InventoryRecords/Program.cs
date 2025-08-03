using System;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "inventory_log.txt";

        // Create an instance of InventoryApp.
        var app = new InventoryApp(filePath);
        
        // Seed some sample data.
        app.SeedSampleData();

        // Save data to disk.
        app.SaveData();

        Console.WriteLine("\n--- Simulating new application session ---");

        // Clear the in-memory log to simulate a new session.
        // This is a test to ensure data is truly loaded from the file.
        app = new InventoryApp(filePath); 

        // Load data from file.
        app.LoadData();

        // Print all items to confirm data was recovered.
        app.PrintAllItems();
    }
}