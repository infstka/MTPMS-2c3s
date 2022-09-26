using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace oop_lab14
{
    public interface IFormatter
    {
        SerializationBinder Binder { get; set; }
        StreamingContext Context { get; set; }
        ISurrogateSelector SurrogateSelector { get; set; }
        object Deserialize(Stream serializationStream);
        void Serialize(Stream serializationStream, object graph);
    }
    [Serializable]
    public class Goods
    {
        public string name { get; set; } = "bag of sweets";

        [NonSerialized] 
        public string color;

        public void info()
        {
            Console.WriteLine($" -- you have a new good in the shop: {name} -- ");
        }
        public Goods() { }
        public Goods(string good_name, string good_color)
        {
            this.name = good_name;
            this.color = good_color;

        }

    }
    [Serializable]
    class Flowers : Goods
    {
        public Flowers() {}
        public Flowers(string flower_name, string flower_color)
        {
            this.name = flower_name;
            this.color = flower_color;

        }

        public override int GetHashCode()
        {
            Console.WriteLine($"\nHASHCODE of car {this.name} is: {name.GetHashCode()}\n-------------------\n");
            return name.GetHashCode();
        }

        public override string ToString()
        {
            return $"{name}\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Flowers el = obj as Flowers;
            if (el as Flowers == null)
                return false;

            return el.name == this.name;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Flowers flower1 = new Flowers("rose", "red");
            Flowers flower2 = new Flowers("grass", "green");
            Flowers flower3 = new Flowers("daisy_pink", "pink");
            Flowers flower4 = new Flowers("daisy_white", "white");

            Flowers[] flower_shop = new[] {flower1, flower2, flower3, flower4 };


            Goods good = new Goods("candy", "choco");
            Goods good2 = new Goods("chocolate", "dark");
            Goods good3 = new Goods("car", "red");

            BinaryFormatter bin = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("flowers.dat", FileMode.OpenOrCreate))
            {
                bin.Serialize(fs, flower1);
                Console.WriteLine("flower1 сериализован");
            }

            // десериализация из файла flowers.dat
            using (FileStream fs = new FileStream("flowers.dat", FileMode.OpenOrCreate))
            {
                Flowers flower1_d = (Flowers)bin.Deserialize(fs);

                Console.WriteLine("flower1 десериализован");
                Console.WriteLine($"name: {flower1_d.name} - color: {flower1_d.color}"); //колор не выводится потому что запретили сериализацию
            }

            SoapFormatter soap = new SoapFormatter();
            using (FileStream fs = new FileStream("flower_soap.soap", FileMode.OpenOrCreate))
            {
                soap.Serialize(fs, flower2);
                Console.WriteLine("flower2 сериализован");
            }

            // десериализация из файла flower_soap.soap
            using (FileStream fs = new FileStream("flower_soap.soap", FileMode.OpenOrCreate))
            {
                Flowers flower2_d = (Flowers)soap.Deserialize(fs);

                Console.WriteLine("flower2 десериализован");
                Console.WriteLine($"name: {flower2_d.name} - color: {flower2_d.color}"); //колор не выводится потому что запретили сериализацию
            }


            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(Path.Combine(@"D:\Саша Комкова", "flowers.json")))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, flower3);
                Console.WriteLine("flower3 сериализован");
            }

            using (StreamReader sr = new StreamReader(Path.Combine(@"D:\Саша Комкова", "flowers.json")))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                serializer.Deserialize(reader);
                Console.WriteLine("flower3 десериализован");
            }
            string output = JsonConvert.SerializeObject(flower3);
            Console.WriteLine(output);


           
            string pathXML = Path.Combine(@"D:\Саша Комкова", "flowers.xml");
            XmlSerializer xml = new XmlSerializer(typeof(Goods));

            try
            {
                using (FileStream fs = new FileStream(pathXML, FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, good);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }


            using (FileStream fs = new FileStream(pathXML, FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, good);
                Console.WriteLine("goods сериализован");
            }

            // десериализация
            using (FileStream fs = new FileStream(pathXML, FileMode.OpenOrCreate))
            {
                Goods good_d = (Goods)xml.Deserialize(fs);

                Console.WriteLine("goods десериализован");
                Console.WriteLine(good_d.name);

            }



            BinaryFormatter bin_m = new BinaryFormatter();

            using (FileStream fs = new FileStream("flowers.dat", FileMode.OpenOrCreate))
            {
                // сериализуем весь массив flower_shop
                bin_m.Serialize(fs, flower_shop);

                Console.WriteLine("flower_shop сериализован");
            }

            // десериализация
            using (FileStream fs = new FileStream("flowers.dat", FileMode.OpenOrCreate))
            {
                Flowers[] deserilizePeople = (Flowers[])bin_m.Deserialize(fs);

                foreach (Flowers f in deserilizePeople)
                {
                    Console.WriteLine($"name: {f.name} - color: {f.color}");
                }
            }




            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"D:\Саша Комкова\flowers.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            // выбор всех дочерних узлов
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
            {
                Console.WriteLine(n.OuterXml);
            }

            XmlNodeList childnodes_2 = xRoot.SelectNodes("//good/name");
            foreach (XmlNode n in childnodes_2)
                Console.WriteLine(n.InnerText);

            XDocument xdoc = XDocument.Load(@"D:\Саша Комкова\flowersLINQ.xml");
            foreach (XElement flowerElement in xdoc.Element("flowers").Elements("flower"))
            {
                XElement nameElement = flowerElement.Element("name");
                XElement colorElement = flowerElement.Element("color");
                

                if (nameElement != null && colorElement != null )
                {
                    Console.WriteLine($"name: {nameElement.Value}");
                    Console.WriteLine($"color: {colorElement.Value}");
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("pink flowers: ");
            var result1 = from xe in xdoc.Descendants("flower")
                          where xe.Element("color").Value == "pink"
                          select new
                          {
                              name = xe.Element("name").Value,
                              color = xe.Element("color").Value,
                          };
            foreach (var item in result1)
            {
                Console.WriteLine($"name: {item.name}  color: {item.color}");
            }
            Console.WriteLine("roses: ");
            var result2 = from xe in xdoc.Descendants("flower")
                          where xe.Element("name").Value == "rose"
                          select new
                          {
                              name = xe.Element("name").Value,
                              color = xe.Element("color").Value,
                          };
            foreach (var item in result2)
            {
                Console.WriteLine($"name: {item.name}  color: {item.color}");
            }

            Console.ReadKey();
        }
    }
}
