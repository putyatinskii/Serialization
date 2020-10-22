using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text.Json;

namespace Serialization
{
    class Serializable
    {

        public static void Serializable_Binary(List<Stock> stock)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("stock.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, stock);
                Console.WriteLine("Объект сериализован в dat");
            }
        }

        public static void Serializable_Json(List<Stock> stock)
        {
            using (FileStream fs = new FileStream("stock.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync(fs, stock);
                Console.WriteLine("Объект сериализован в json");
            }
        }

        public static void Serializable_XML(List<Stock> stock)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Stock>));

            using (FileStream fs = new FileStream("stock.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, stock);

                Console.WriteLine("Объект сериализован в XML");
            }
        }
    }
}
