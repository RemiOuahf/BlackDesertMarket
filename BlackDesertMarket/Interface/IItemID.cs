using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDesertMarket.Interface
{
    internal interface IItemID
    {
        public long ID { get; set; }
        public int EnhancementLevelInt { get;}
    }
}
