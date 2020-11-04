using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization.Investor
{
    [Serializable]
    [XmlInclude(typeof(Stock)),
        XmlInclude(typeof(Bond))]
    public class Security_paper
    {
        private string name;
        private double cost;

        public Security_paper()
        {

        }

        public override string ToString()
        {
            return Name + " " + Cost;
        }


        public Security_paper(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public double Cost
        {
            get => cost;
            set => cost = value;
        }
    }
}
