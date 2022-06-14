// See https://aka.ms/new-console-template for more information
using System;
using System.Xml;
using System.IO;

//Console.WriteLine("Hello, World");

namespace xmlreader
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalc = 0;

            XmlDocument xmlDoc = new XmlDocument();
            string XMLpath = Directory.GetCurrentDirectory() + @"\info.xml";
            xmlDoc.Load(XMLpath);

            XmlNodeList Clist = xmlDoc.GetElementsByTagName("last-connected");
            Console.WriteLine("Lsst connected VIN: " + Clist[0]?.Attributes?["vin"]?.InnerText.ToString() + " MFR: " + Clist[0]?.Attributes?["mfr"]?.InnerText.ToString());

            Clist = xmlDoc.GetElementsByTagName("licenses");
            Console.WriteLine("Total Licenses: " + Clist[0]?.Attributes?["available"]?.InnerText.ToString() + " Total Tuned Vehicles: " + Clist[0]?.Attributes?["tuned"]?.InnerText.ToString());

            Clist = xmlDoc.GetElementsByTagName("license");
            totalc = Clist.Count;
            for (int i = 0; i < Clist.Count; i++)
            {
                
                Console.WriteLine("Tuned VIN: " + Clist[i]?.Attributes?["vin"]?.InnerText.ToString() + " MFR: " + Clist[i]?.Attributes?["mfr"]?.InnerText.ToString());
                //System.Threading.Thread.Sleep(1000);
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(totalc.ToString() + " version inXML File.");
            Console.WriteLine(Clist);
            Console.ReadLine();
        }
    }
}

