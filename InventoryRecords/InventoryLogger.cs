using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// The generic constraint `where T : IInventoryEntity` is essential
public class InventoryLogger<T> where T : IInventoryEntity
{
    private List<T> _log = new List<T>();
    private string _filePath;

    public InventoryLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void Add(T item)
    {
        _log.Add(item);
    }

    public List<T> GetAll()
    {
        return _log;
    }

    public void SaveToFile()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var item in _log)
                {
                    // Simple plain text serialization
                    writer.WriteLine($"{item.Id},{item.Name},{item.Quantity},{item.DateAdded}");
                }
            }
            Console.WriteLine($"Successfully saved inventory log to '{_filePath}'");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }

    public void LoadFromFile()
    {
        _log.Clear(); // Clear current log to load fresh data
        if (!File.Exists(_filePath))
        {
            Console.WriteLine($"File not found: '{_filePath}'. Starting with an empty log.");
            return;
        }

        try
        {
            using (StreamReader reader = new StreamReader(_filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    if (fields.Length == 4)
                    {
                        if (int.TryParse(fields[0], out int id) &&
                            int.TryParse(fields[2], out int quantity) &&
                            DateTime.TryParse(fields[3], out DateTime dateAdded))
                        {
                            // Using a temporary variable to construct the item
                            var item = (T)(IInventoryEntity)new InventoryItem(id, fields[1], quantity, dateAdded);
                            _log.Add(item);
                        }
                    }
                }
            }
            Console.WriteLine($"Successfully loaded inventory log from '{_filePath}'");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading from file: {ex.Message}");
        }
    }
}