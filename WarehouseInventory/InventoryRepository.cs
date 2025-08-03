using System;
using System.Collections.Generic;

public class InventoryRepository<T> where T : IInventoryItem
{
    private Dictionary<int, T> _items = new Dictionary<int, T>();

    public void AddItem(T item)
    {
        if (_items.ContainsKey(item.Id))
        {
            throw new DuplicateItemException($"Item with ID {item.Id} already exists.");
        }
        _items.Add(item.Id, item);
    }

    public T GetItemById(int id)
    {
        if (!_items.ContainsKey(id))
        {
            throw new ItemNotFoundException($"Item with ID {id} not found.");
        }
        return _items[id];
    }

    public void RemoveItem(int id)
    {
        if (!_items.ContainsKey(id))
        {
            throw new ItemNotFoundException($"Item with ID {id} not found.");
        }
        _items.Remove(id);
    }

    public List<T> GetAllItems()
    {
        return new List<T>(_items.Values);
    }

    public void UpdateQuantity(int id, int newQuantity)
    {
        if (!_items.ContainsKey(id))
        {
            throw new ItemNotFoundException($"Item with ID {id} not found.");
        }
        if (newQuantity < 0)
        {
            throw new InvalidQuantityException($"Cannot set quantity to a negative value: {newQuantity}");
        }
        _items[id].Quantity = newQuantity;
    }
}