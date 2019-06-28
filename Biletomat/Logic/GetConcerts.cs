using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletomat.Logic
{
    public class GetConcerts
    {
        public string GetConcertList()
        {
            var webContent = "http://www.efest.pl/kalendarz/";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(webContent);
            return doc.Text;
        }

    }
}
