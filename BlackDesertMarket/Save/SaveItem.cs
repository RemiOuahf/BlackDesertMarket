using BlackDesertMarket.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BlackDesertMarket.Items;
using System.DirectoryServices;

namespace BlackDesertMarket.Save
{ 
    }
    internal class SaveItem
    {
        public string savePath = Path.Combine(Directory.GetCurrentDirectory(), "Save");

        List<Item> items = new List<Item>();
        List<Item> filter = new List<Item>();

        public void Save(Item _toSave)
        {
            Load();
            items.Add(_toSave);
            string _fileName = Path.Combine(savePath, "Item.save");
            string _data = JsonConvert.SerializeObject(items);
            File.WriteAllText(_fileName, _data);
        }
        ~SaveItem()
        {
            items.Clear();
            filter.Clear();
        }
      public void Load()
        {
            if(File.Exists(Path.Combine(savePath,"Item.save")))
            {
                string _path = File.ReadAllText(Path.Combine(savePath, "Item.save"));
                items = JsonConvert.DeserializeObject<Item[]>(_path).ToList();
            }
        }

        public List<Item> LoadFilter()
        {
            if (File.Exists(Path.Combine(savePath, "Filter.save")))
            {
                string _path = File.ReadAllText(Path.Combine(savePath, "Filter.save"));
                filter = JsonConvert.DeserializeObject<Item[]>(_path).ToList();
            }
            return filter;
        }

        public SaveItem()
        {
            Directory.CreateDirectory(savePath);
        }

        public List<Item> GetItems() { return  items; }

        public Item GetItemFromID(long id)
        {
            Load();
            
            for(int i =0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                    return items[i];
            }
            return null;
        }

        public void SaveFilter(List<Item> _filter)
        {
            string _fileName = Path.Combine(savePath, "Filter.save");
            string _data = JsonConvert.SerializeObject(_filter);
            File.WriteAllText(_fileName, _data);
        }
        public void RemoveItem(Item _item)
        {
            items.Remove(_item);
            string _fileName = Path.Combine(savePath, "Item.save");
            string _data = JsonConvert.SerializeObject(items);
            File.WriteAllText(_fileName, _data);
        }
        public void Save(List<Item> _items)
        {
            string _fileName = Path.Combine(savePath, "Item.save");
            string _data = JsonConvert.SerializeObject(items);
            File.WriteAllText(_fileName, _data);
        }

    public string GetWebHook()
    {
        string _res = "";
        if(File.Exists(Path.Combine(savePath,"WebHook.save")))
        {
            _res = File.ReadAllText(Path.Combine(savePath, "WebHook.save"));
        }
        return _res;
    }

}
