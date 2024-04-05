using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using BlackDesertMarket.Items;
using BlackDesertMarket.Interface;

namespace BlackDesertMarket
{
    internal class Utils
    {


        public static List<T> RemoveItemsFromList<T,Y>(List<Y> _toRemove, List<T> _toConserve) where T : IItemID where Y : IItemID
        {
            List<T> list = new List<T>();
            if (_toRemove.Count <= 0)
                return _toConserve;
            for(int i =0; i < _toConserve.Count; i++)
            {
                for(int y =0; y < _toRemove.Count;y++)
                {

                    if (_toConserve[i]?.ID == _toRemove[y].ID && _toConserve[i]?.EnhancementLevelInt == _toRemove[y].EnhancementLevelInt)
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


    public static class ListExtension
    {

        public static bool ContainsID<T>(this List<T> _list, long _ID, long _endTime) where T : IItem
        {
            for(int i =0 ; i < _list.Count; i++)
            {
                if (_list[i].ID == _ID && _list[i].EndTime == _endTime )
                    return true;
            }
            return false;
        }
    }
}
