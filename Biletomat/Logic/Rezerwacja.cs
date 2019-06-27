using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletomat.Logic
{
    public class Rezerwacja
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Rezerwacja(string name, DateTime date)
        {
            this.Name = name;
            this.Date = date;
        }
    }
}
