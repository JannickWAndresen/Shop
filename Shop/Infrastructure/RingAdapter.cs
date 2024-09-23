using Shop.Entities;
using Shop.InterfaceAdapter;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Shop.Infrastructure
{
    public class RingAdapter : IJewelryAdapter
    {
        private readonly string _filePath = "Files\\Rings.txt"; // Might need to insert full path to retrieve the txt file.

        public List<Item> GetJewelryItems()
        {
            var items = new List<Item>();

            if (File.Exists(_filePath))
            {
                string[] lines = File.ReadAllLines(_filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    items.Add(new Item(int.Parse(parts[0]), parts[1], double.Parse(parts[2])));
                }
            }

            return items;
        }
    }
}
