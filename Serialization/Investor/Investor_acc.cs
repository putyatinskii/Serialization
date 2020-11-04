using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Investor
{

    class Investor_acc
    {
        List<Security_paper> securities = new List<Security_paper>();

        public List<Security_paper> GetSecurities { get => securities; set => securities = value; }

        public void Add(Security_paper security)
        {
            GetSecurities.Add(security);
        }

        public void AddRange(List<Security_paper> security_list)
        {
            GetSecurities.AddRange(security_list);
        }

        public void Remove(Security_paper security)
        {
            GetSecurities.Remove(security);
        }
    }
}
