using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text.Json;
using Serialization.Investor;
using Newtonsoft.Json;

namespace Serialization.All_Serialization
{
    class Serializable
    {

        public static void Serializable_Binary(List<Security_paper> security_papers)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("security_papers.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, security_papers);
                Console.WriteLine("Объект сериализован в dat");
            }
        }

        public static void Serializable_Json(List<Security_paper> security_papers)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            string jsonString = JsonConvert.SerializeObject(security_papers, settings);
            File.WriteAllText("security_papers.json", jsonString);
            Console.WriteLine("Объект сериализован в json");

        }

        public static void Serializable_XML(List<Security_paper> security_papers)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Security_paper>));

            using (FileStream fs = new FileStream("security_papers.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, security_papers);

                Console.WriteLine("Объект сериализован в XML");
            }
        }
    }
}
