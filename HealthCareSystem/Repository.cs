using System;
using System.Collections.Generic;
using System.Linq;

public class Repository<T>
{
    private List<T> _items = new List<T>();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public List<T> GetAll()
    {
        return _items;
    }

    public T? GetByID(Func<T, bool> predicate)
    {
        return _items.FirstOrDefault(predicate);
    }

    public bool Remove(Func<T, bool> predicate)
    {
        T? itemToRemove = _items.FirstOrDefault(predicate);
        if (itemToRemove != null)
        {
            _items.Remove(itemToRemove);
            return true;
        }
        return false;
    }
}