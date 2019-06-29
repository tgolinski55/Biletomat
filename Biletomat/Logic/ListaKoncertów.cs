using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletomat.Logic
{
    public class ListaKoncertów
    {
        public string Date { get; set; }
        public string Event { get; set; }
        public string Artists { get; set; }
        public string Place { get; set; }
        public string Link { get; set; }
        public ListaKoncertów(string date, string eventT, string artists, string place, string link)
        {
            this.Date = date;
            this.Event = eventT;
            this.Artists = artists;
            this.Place = place;
            this.Link = link;
        }
    }
}
