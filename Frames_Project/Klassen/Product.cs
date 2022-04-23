using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frames_Project.Klassen
{
    public class Product
    {
        public string name { get; private set; }
        public int count { get;  set; }
        
        public Product(string name)
        {
            this.name = name;
        }

    }
}
