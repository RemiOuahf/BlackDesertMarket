using BlackDesertMarket.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace BlackDesertMarket.Items
{
    enum EGrade
    {
        White,
        Green,
        Blue,
        Yellow,
        Red


    }

    internal class Item : IToString, IItemID
    {
            public long ID { get; set; }
            public string Name { get; set; }
            public int Count { get; set; }
            public int Grade { get; set; }
            public long BasePrice { get; set; }
            public int MainCategory { get; set; }
            public int SubCategory { get; set; }
            public int Enhancement { get; set; }
            public long TradeCount { get; set; }
        public int EnhancementLevelInt { get => ConvertEnhancementLevel() ;}

        public string NameEnhancement { get => ((AccessoryLevel)EnhancementLevelInt).ToString(); }

        public Item(long _id, string _name, int _count, int _grade, long _basePrice, int _mainCategory, int _subCategory, int _enhancement, long _tradeCount)
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

        public override string ToString()
        {
            return "ID : " + ID + "\n"
                + "Name : " + Name + "\n"
                + "Grade : " + (EGrade)Grade + "\n"
                + "Enhancement : " + Enhancement + "\n"
                + "Price : " + BasePrice + "\n"
                + "Count :" + Count;
        }

        private int ConvertEnhancementLevel()
        {
            if (Enhancement < 10)
            {
                return ((int)(AccessoryLevel)Enhancement);
            }
            else
            {
                return ((int)(AccessoryLevel)Enhancement - 15);
            }
        }
    }
}
