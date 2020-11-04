using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Investor
{
    [Serializable]
    public class Stock : Security_paper
    {
        private bool presense_divident;

        public Stock()
        {
            
        }

        public bool Presense_divident
        {
            get => presense_divident;
            set => presense_divident = value;
        }

        public Stock(string name, double cost, bool presense_divident) : base(name, cost)
        {
            this.Presense_divident = presense_divident;
        }

        public override string ToString()
        {
            return "Stock: " + base.ToString() + " " + presense_divident;
        }
    }
}
