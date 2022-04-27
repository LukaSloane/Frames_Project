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

            UserDataOverview();
        }




        private void btn_back_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void UserDataOverview()
        {
            name.Content += person.name;
            street.Content += person.street;
            plz.Content += person.plz;
            town.Content += person.town;
            email.Content += person.email;
            phone.Content += person.phone;
            kontoinhaber.Content += konto.name;
            iban.Content += konto.IBAN;


            foreach (Product p in products)
            {

                itemList.Items.Add($"{p.count} x {p.name}");
                //lbxWaren.Items.Add($"{p.Anzahl}x {p.Bezeichnung}");
              
            }

        }

        private void btn_weiter_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Bestaetigung(person, products, konto));

        }
    }
}
