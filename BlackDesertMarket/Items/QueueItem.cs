using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDesertMarket.Items
{
    internal class QueueItem
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

        public QueueItem()
        {

        }
        public override string ToString()
        {
            return Name + " ------> " + Count + " ------> " + BasePrice;
        }

    }
}
