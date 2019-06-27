using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletomat.Logic
{
    public class OptionsList
    {
        public string Name { get; set; }
        public bool Admin { get; set; }
        public OptionsList(string name, bool admin)
        {
            this.Name = name;
            this.Admin = admin;
        }
    }
}
