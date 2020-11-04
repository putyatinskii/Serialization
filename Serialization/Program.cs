using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using Serialization.All_Serialization;
using Serialization.Investor;

namespace Serialization
{
    class Program
    {
        enum Operation
        {
            get_txt = 1,
            d_dat,
            d_json,
            d_xml,

        }

        static void Main(string[] args)
        {
            Investor_acc investor = new Investor_acc();
            Operation op;
            Console.WriteLine("Press 1 to read txt file");
            Console.WriteLine("Press 2 to deserialize dat file");
            Console.WriteLine("Press 3 to deserialize json file");
            Console.WriteLine("Press 4 to deserialize xml file");
            op = (Operation)Enum.Parse(typeof(Operation), Console.ReadLine());
            switch (op)
            {
                case Operation.get_txt:
                    using (StreamReader fileIn = new StreamReader("input.txt", Encoding.GetEncoding(1251)))
                    {
                        string[] str = fileIn.ReadToEnd().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string str_elem in str)
                        {
                            string[] sec = str_elem.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (sec.Length == 3) investor.Add(new Stock(sec[0], double.Parse(sec[1]), bool.Parse(sec[2])));
                            else if (sec.Length == 4) investor.Add(new Bond(sec[0], double.Parse(sec[1]), double.Parse(sec[2]), bool.Parse(sec[3])));
                        }
                    }
                    Serializable.Serializable_Binary(investor.GetSecurities);
                    Serializable.Serializable_XML(investor.GetSecurities);
                    Serializable.Serializable_Json(investor.GetSecurities);
                    Console.WriteLine();
                    break;
                case Operation.d_dat:
                    Deserializable.Binary(investor);
                    break;
                case Operation.d_json:
                    Deserializable.Json(investor);
                    break;
                case Operation.d_xml:
                    Deserializable.XML(investor);
                    break;
            }
            foreach (Security_paper elem in investor.GetSecurities)
            {
                Console.WriteLine(elem);
            }
        }
    }
}
