using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MCD_SystemXMLKullanimi
{
    class Program
    {
        static void Main(string[] args)
        {
            #region XML Data Yazma
            
            XmlTextWriter xmlTest = new XmlTextWriter(@"C:\XML\Personellerim.xml", System.Text.UTF8Encoding.UTF8);
            // <----YORUMLAR---->
            xmlTest.WriteComment("Yorumlar buraya yazılır");

            // root oluşturma
            xmlTest.WriteStartElement("Personellerim");

            // child oluşturma
            xmlTest.WriteStartElement("Personel");
            xmlTest.WriteAttributeString("ID", "1");

            // subchild oluşturma
            xmlTest.WriteElementString("İsim", "Emre");
            xmlTest.WriteElementString("Soyisim", "Gemici");
            xmlTest.WriteElementString("Emailadres", "emre.gemici@gmail.com");
            xmlTest.WriteEndElement();  // Child elementini kapatma

            //2.Personeli ekleyelim.
            xmlTest.WriteStartElement("Personel");
            xmlTest.WriteAttributeString("ID", "2");
            xmlTest.WriteElementString("İsim", "Serkan");
            xmlTest.WriteElementString("Soyisim", "Yurttapan");
            xmlTest.WriteElementString("Emailadres", "serkan.yurttapan@gmail.com");
            xmlTest.WriteEndElement();



            xmlTest.WriteEndElement();  // Root elementini kapatma
            xmlTest.Close();
            
            #endregion

            #region XML Data Okuma

            XmlReader reader = XmlReader.Create(@"C:\XML\Personellerim.xml");
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    if (reader.MoveToFirstAttribute())
                    {
                        Console.WriteLine();
                        Console.WriteLine("ID : " + reader.Value.ToString());
                    }
                    //return only when you have START 
                    switch (reader.Name.ToString())
                    {
                        case "İsim":
                            Console.WriteLine("İsim : " + reader.ReadString());
                            break;
                        case "Soyisim":
                            Console.WriteLine("Soyisim : " + reader.ReadString());
                            break;
                        case "EmailAdres":
                            Console.WriteLine("EmailAdres : " + reader.ReadString());
                            Console.WriteLine("");
                            break;
                    }
                }
            }

            Console.ReadLine();
            #endregion
        }
    }
}
