using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Frames_Project.Klassen;

namespace Frames_Project
{
    /// <summary>
    /// Interaktionslogik für Uebersicht.xaml
    /// </summary>
    public partial class Uebersicht : Page
    {

        List<Product> products;
        Person person;
        Bankaccount konto;
        public Uebersicht(List<Product> products, Person person, Bankaccount konto)
        {
            this.products = products;
            this.person = person;
            this.konto = konto;
            InitializeComponent();
        }
    }
}
