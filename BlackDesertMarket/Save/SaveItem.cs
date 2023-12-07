using BlackDesertMarket.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BlackDesertMarket.Items;

namespace BlackDesertMarket.Save
{
    internal class SaveItem
    {
        public string savePath = Path.Combine(Directory.GetCurrentDirectory(), "Save");

        List<Item> items = new List<Item>();

        public void Save(Item _toSave)
        {
            Load();
            items.Add(_toSave);
            string _fileName = Path.Combine(savePath, "Item.save");
            string _data = JsonConvert.SerializeObject(items);
            File.WriteAllText(_fileName, _data);
        }

      public void Load()
        {
            if(File.Exists(Path.Combine(savePath,"Item.save")))
            {
                string _path = File.ReadAllText(Path.Combine(savePath, "Item.save"));
                items = JsonConvert.DeserializeObject<Item[]>(_path).ToList();
            }
        }

        public SaveItem()
        {
            Directory.CreateDirectory(savePath);
        }

        public List<Item> GetItems() { return  items; }
    }
}
