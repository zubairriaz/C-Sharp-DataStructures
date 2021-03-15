using System;
using System.Linq;
using System.Xml.Linq;

namespace LinqToXml
{
    class Program
    {
        static void Main(string[] args)
        {
            var document = XDocument.Load("sample.xml");
            var xmlCollection = document.Element("catalog").Elements("book");
            var nodes = xmlCollection.Where(x => x.Attribute("id").Value == "bk101");
            

            foreach(var res in nodes)
            {
                Console.WriteLine($"{res.Element("author").Value}");
            }
        }
    }
}
