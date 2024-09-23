using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Shop.InterfaceAdapter;

namespace Shop.Infrastructur
{
    public class FileItemRepos : IItemRepository
    {
        private readonly string _filePath;

        public FileItemRepos(string filePath)
        {
            _filePath = filePath;
        }

        public List<Item> LoadItems()
        {
            var items = new List<Item>();

            if (!File.Exists(_filePath))
                return items;

            var lines = File.ReadAllLines(_filePath);

            foreach (var line in lines)
            {
                var fields = line.Split(',');

                if (fields.Length != 3) continue;

                int id = int.Parse(fields[0]);
                string description = fields[1];
                double price = double.Parse(fields[2]);

                var item = new Item(id, description, price);
                items.Add(item);
            }

            return items;
        }

        public void SaveItems(List<Item> items)
        {
            var lines = items.Select(item => $"{item.Id},{item.Description},{item.Price}");

            File.WriteAllLines(_filePath, lines);
        }
    }
}
