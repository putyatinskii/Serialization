using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{

    class Invector_acc
    {
        List<Stock> securities = new List<Stock>();

        public List<Stock> Get_list
        {
            get
            {
                return securities;
            }
        }

        public void Add(Stock security)
        {
            securities.Add(security);
        }

        public void AddRange(List<Stock> security_list)
        {
            securities.AddRange(security_list);
        }

        public void Remove(Stock security)
        {
            securities.Remove(security);
        }
    }
}
