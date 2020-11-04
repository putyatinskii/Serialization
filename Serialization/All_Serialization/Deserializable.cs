using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text.Json;
using Serialization.Investor;
using Newtonsoft.Json;

namespace Serialization.All_Serialization
{
    class Deserializable
    {
        public static void Binary(Investor_acc investor)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("security_papers.dat", FileMode.OpenOrCreate))
            {
                List<Security_paper> security_papers = new List<Security_paper>((List<Security_paper>)formatter.Deserialize(fs));
                investor.AddRange(security_papers);
                Console.WriteLine("Объект десериализован");
            }
        }

        public static void Json(Investor_acc investor)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            string jsonString = File.ReadAllText("security_papers.json");
            List<Security_paper> security_papers = JsonConvert.DeserializeObject<List<Security_paper>>(jsonString, settings);
            investor.AddRange(security_papers);
            Console.WriteLine("Объект десериализован");

        }

        public static void XML(Investor_acc investor)
        {
            using (FileStream fs = new FileStream("security_papers.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Security_paper>));
                List<Security_paper> security_papers = new List<Security_paper>((List<Security_paper>)formatter.Deserialize(fs));
                investor.AddRange(security_papers);
                Console.WriteLine("Объект десериализован");
            }
        }
    }
}
