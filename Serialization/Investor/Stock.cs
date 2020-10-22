using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    public class Stock
    {
        public string name { get; set; }
        public double cost { get; set; }
        public bool divident { get; set; }

        public Stock()
        {

        }

        public Stock(string name, double cost, bool divident)
        {
            this.name = name;
            this.cost = cost;
            this.divident = divident;
        }

        public override string ToString()
        {
            return name + "  " + cost + "  " + divident;
        }
    }
}
