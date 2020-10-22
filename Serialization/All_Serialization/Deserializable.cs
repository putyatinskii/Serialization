using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text.Json;

namespace Serialization.All_Serialization
{
    class Deserializable
    {
        public static void Binary(Invector_acc invector)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("stock.dat", FileMode.OpenOrCreate))
            {
                List<Stock> stocks = new List<Stock>((List<Stock>)formatter.Deserialize(fs));
                invector.AddRange(stocks);
                Console.WriteLine("Объект десериализован");
            }
        }

        public static void Json(Invector_acc invector)
        {
            string jsonString = File.ReadAllText("stock.json");
            List<Stock> stocks = JsonSerializer.Deserialize<List<Stock>>(jsonString);
            invector.AddRange(stocks);
            Console.WriteLine("Объект десериализован");

        }

        public static void XML(Invector_acc invector)
        {
            using (FileStream fs = new FileStream("stock.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Stock>));
                List<Stock> stocks = new List<Stock>((List<Stock>)formatter.Deserialize(fs));
                invector.AddRange(stocks);
                Console.WriteLine("Объект десериализован");
            }
        }
    }
}
