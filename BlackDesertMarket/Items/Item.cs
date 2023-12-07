using BlackDesertMarket.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDesertMarket.Items
{
    internal class Item :  IToString
    {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Count { get; set; }
            public int Grade { get; set; }
            public long BasePrice { get; set; }
            public int MainCategory { get; set; }
            public int SubCategory { get; set; }
            public int Enhancement { get; set; }
            public long TradeCount { get; set; }

            public Item(int _id, string _name, int _count, int _grade, long _basePrice, int _mainCategory, int _subCategory, int _enhancement, long _tradeCount)
            {
                ID = _id;
                Name = _name;
                Count = _count;
                Grade = _grade;
                BasePrice = _basePrice;
                MainCategory = _mainCategory;
                SubCategory = _subCategory;
                Enhancement = _enhancement;
                TradeCount = _tradeCount;
            }

        public string InterfaceToString()
        {
            return Name;
        }
    }
}
