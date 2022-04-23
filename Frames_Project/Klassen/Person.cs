using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frames_Project.Klassen
{
    public class Person
    {
        public string name { get; private set;  }
        public string street { get; private set; }
        public string plz { get; private set; }
        public string town
        {
            get; private set;
         }
        public string email
        {
            get; private set;
         }
        public string phone { get; private set; }

        public Person(string name, string street, string plz, string town, string email, string phone)
        {
            this.name = name;
            this.street = street;
            this.plz = plz;
            this.town = town;
            this.email = email;
            this.phone = phone;
        }
    }
}
