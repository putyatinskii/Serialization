using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using Serialization.All_Serialization;

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
            Invector_acc invector = new Invector_acc();
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
                            if (sec.Length == 3) invector.Add(new Stock(sec[0], int.Parse(sec[1]), bool.Parse(sec[2])));
                        }
                    }
                    Serializable.Serializable_Binary(invector.Get_list);
                    Serializable.Serializable_XML(invector.Get_list);
                    Serializable.Serializable_Json(invector.Get_list);
                    break;
                case Operation.d_dat:
                    Deserializable.Binary(invector);
                    break;
                case Operation.d_json:
                    Deserializable.Json(invector);
                    break;
                case Operation.d_xml:
                    Deserializable.XML(invector);
                    break;
            }
            foreach (Stock elem in invector.Get_list)
            {
                Console.WriteLine(elem.ToString());
            }
        }
    }
}
