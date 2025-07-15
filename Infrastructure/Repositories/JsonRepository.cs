using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Core.Models;

namespace Infrastructure.Repositories
{
    public class JsonRepository<T> : IRepository<T>
    {
        private readonly string _filePath;
        private List<T> _items;

        public JsonRepository(string filePath)
        {
            _filePath = filePath;
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _items = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            else
            {
                _items = new List<T>();
            }
        }

        public IEnumerable<T> GetAll() => _items;

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Delete(int id)
        {
            var itemToRemove = _items.Find(x =>
            {
                var idProperty = x?.GetType().GetProperty("Id");
                if (idProperty == null) return false;

                var value = idProperty.GetValue(x);
                return value != null && value.Equals(id);
            });

            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
            }
        }

        public void Save()
        {
            var json = JsonSerializer.Serialize(_items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}