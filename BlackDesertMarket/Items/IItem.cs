using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDesertMarket.Items
{
    public interface IItem
    {
        public long ID { get; set; }
        public long EndTime { get; set; }
    }
}
