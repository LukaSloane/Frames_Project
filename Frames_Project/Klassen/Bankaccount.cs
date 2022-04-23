using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frames_Project.Klassen
{
    public class Bankaccount
    {
        public string IBAN { get; private set; }
        public string name { get; private set; }

        public Bankaccount(string name, string iban)
        {
            this.name = name;
            this.IBAN = iban;
        }

        
    }
}
