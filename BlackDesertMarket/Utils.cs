using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using BlackDesertMarket.Items;

namespace BlackDesertMarket
{
    internal class Utils
    {


        public static List<T> RemoveItemsFromList<T,Y>(List<Y> _toRemove, List<T> _toConserve) where T : IItem where Y : IItem
        {
            List<T> list = new List<T>();
            for(int i =0; i < _toConserve.Count; i++)
            {
                for(int y =0; y < _toRemove.Count;y++)
                {

                    if (_toConserve[i]?.ID == _toRemove[y].ID)
                    {
                        list.Add(_toConserve[i]);

                    }
                }
            }
            return list;
        }
        public static bool IsRequestValid(string _request)
        {
            return !_request.Contains("Error");
        }

        public static Item GetItemWithIDFromList(List<Item> _list, long _id)
        {
            for(int i =0; i < _list.Count; i++)
            {
                if(_list[i].ID == _id)
                { return _list[i]; }
            }
            return null;
        }
    }
}
