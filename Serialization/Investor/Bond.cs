using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Investor
{
    [Serializable]
    public class Bond : Security_paper
    {
        private double yield;
        private bool amortization;

        public Bond()
        {

        }

        public Bond(string name, double cost, double yield, bool amortization) : base(name, cost)
        {
            this.Yield = yield;
            this.Amortization = amortization;
        }

        public double Yield
        {
            get => yield;
            set => yield = value;
        }
        public bool Amortization
        {
            get => amortization;
            set => amortization = value;
        }

        public override string ToString()
        {
            return "Bond: " + base.ToString() + " " + Yield + "% " + Amortization;
        }
    }
}
