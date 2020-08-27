using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DRRSS.Kerne
{
    public class Nyhed
    {
        public string Titel;
        public string Beskrivelse;
        public string Link;
        public DateTime Dato;

        public static List<Nyhed> HentNyheder(string url)
        {
            try
            {
                List<Nyhed> lst = new List<Nyhed>();
                XmlDocument doc = new XmlDocument();

                doc.Load(url);
                var items = doc.SelectNodes("//item");
                foreach (XmlNode item in items)
                {
                    lst.Add(new Nyhed()
                    {
                        Titel = item.SelectSingleNode("title").InnerText,
                        Beskrivelse = item.SelectSingleNode("description").InnerText,
                        Link = item.SelectSingleNode("link").InnerText,
                        Dato = Convert.ToDateTime(item.SelectSingleNode("pubDate").InnerText)
                    });
                }
                return lst.OrderByDescending(i => i.Dato).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception("Kan ikke deserialisere" + url, ex);
            }
        }
    }
}
