using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDesertMarket.API
{
    internal class APIRequest<T>
    {
        public string code;
        public List<T> data;

        public APIRequest(string statut, List<T> items)
        {
            this.code = statut;
            this.data = items;
        }

        public List<T> GetList()
        {
            return data;
        }

        ~APIRequest()
        {
            data.Clear();
        }
    }
}
