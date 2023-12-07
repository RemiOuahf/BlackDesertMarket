using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlackDesertMarket.Json
{
    internal static class JsonConverter
    {


        public static T ConvertTo<T>(string json)
        {
            T _res = default(T);
            _res = JsonConvert.DeserializeObject<T>(json); 
            return _res;
        }

        public static List<T> ConvertToList<T>(string json)
        {
            List<T> _res = default(List<T>);
            _res = JsonConvert.DeserializeObject<T[]>(json).ToList();
            return _res;
        }
    }
}
