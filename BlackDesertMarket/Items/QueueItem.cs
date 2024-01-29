using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDesertMarket.Items
{

    enum ArmorWeaponLevel
    {
        BASE,
        one,
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine,
        ten,
        eleven,
        twelve,
        thirteen,
        fourteen,
        fifteen,
        PRI,
        DUO,
        TRI,
        TET,
        PEN,
    };

    enum AccessoryLevel
    {
        BASE,
        PRI,
        DUO,
        TRI,
        TET,
        PEN,
    }

    internal class QueueItem : IItem
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Grade { get; set; }
        public long BasePrice { get; set; }
        public int MainCategory { get; set; }
        public int SubCategory { get; set; }
        public int Enhancement { get; set; }
        public long EndTime { get; set; }

        public string EnhancementLevel { get => ConvertEnhancementLevel(Enhancement); }

        public string EndFormat { get => ConvertTimestampToDate(EndTime); }

        public string PriceFormat { get => BasePrice.ToString("N0"); }

        public QueueItem()
        {

        }
        public override string ToString()
        {
            return Name + " ------> " + ConvertEnhancementLevel(Enhancement) + " ---------> " + BasePrice.ToString("N0") + " ---------> " + ConvertTimestampToDate(EndTime);
        }


        private string ConvertTimestampToDate(long _timestamp)
        {
            DateTime _date = DateTime.UnixEpoch;
            _date = _date.AddMilliseconds(_timestamp);
           _date = _date.AddHours(1);
            return _date.ToString();
        }

        private string ConvertEnhancementLevel(int _level)
        {
            if(_level < 10)
            {
                return ((AccessoryLevel)_level).ToString();
            }
            else
            {
                return ((ArmorWeaponLevel)_level).ToString();
            }

        }

        public string ToDiscordString()
        {
            return Name + " ------> " + ConvertEnhancementLevel(Enhancement) + " ---------> " + BasePrice.ToString("N0") + " ---------> " + "<t:" + EndTime/1000 + ":R>";
        }

    }
}
