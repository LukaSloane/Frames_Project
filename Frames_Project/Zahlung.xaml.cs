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
using System.Text.RegularExpressions;

namespace Frames_Project
{
    /// <summary>
    /// Interaktionslogik für Zahlung.xaml
    /// </summary>
    public partial class Zahlung : Page
    {
        List<Product> products;
        Person person;
        public Zahlung(List<Product> products, Person person)
        {
            this.products = products;
            this.person = person;
            InitializeComponent();
        }

        private void btn_back_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void btn_weiter_click(object sender, RoutedEventArgs e)
        {
            if(validateKonto())
            {
                Bankaccount konto = new Bankaccount(input_Name.Text.ToString(), input_IBAN.Text.ToString()); ;
                this.NavigationService.Navigate(new Uebersicht(products, person, konto));
            }
        }

        private bool validateKonto()
        {
            Regex rx = new Regex(@"^DE[0-9]{2}(\s)?[0-9]{4}(\s)?[0-9]{4}(\s)?[0-9]{4}(\s)?[0-9]{4}(\s)?[0-9]{2}$");
            Regex rxName = new Regex(@"^[a-zA-ZäöüÄÖÜß]{2,12}\s[a-zA-ZäöüÄÖÜß]{2,12}(\s[a-zA-ZäöüÄÖÜß]{2,12})?$");

            if (!rx.IsMatch(input_IBAN.Text))
            {
                MessageBox.Show("Deine IBAN ist inkorrekt. Bitte überprüfe sie und versuche es erneut.");
                return false;
            }
            if (!rxName.IsMatch(input_Name.Text))
            {
                MessageBox.Show("Bitte gib einen gültigen Namen ein.");
                return false;
            }
            return true;
        }
    }
}
