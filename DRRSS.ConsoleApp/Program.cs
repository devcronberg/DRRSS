using System;
using System.Linq;

namespace DRRSS.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var res = DRRSS.Kerne.Nyhed.HentNyheder(@"https://www.dr.dk/nyheder/service/feeds/allenyheder/");
            foreach (var item in res)
            {
                Console.WriteLine(item.Titel);
            }
        }
    }
}
