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
using System.Text.RegularExpressions;
using Frames_Project.Klassen;

namespace Frames_Project
{
    /// <summary>
    /// Interaktionslogik für Shop.xaml
    /// </summary>
    public partial class Shop : Page
    {
        public Shop()
        {
            InitializeComponent();
        }

        private void btn_weiter_click(object sender, RoutedEventArgs e)
        {
            bool allIsValid = true;

            List<Product> products = new List<Product>();

            if(validateUserInput(product1_count.Text, product1.Content.ToString()) && product1_count.Text != "0")
            {
                products.Add(new Product(product1.Content.ToString()) { count = Convert.ToInt32(product1_count.Text) });
            }
            else
            {
                allIsValid = false;
            }

            if (validateUserInput(product2_count.Text, product2.Content.ToString()) && product2_count.Text != "0")
            {
                products.Add(new Product(product2.Content.ToString()) { count = Convert.ToInt32(product2_count.Text) });
            }
            else
            {
                allIsValid = false;
            }

            if (validateUserInput(product3_count.Text, product3.Content.ToString()) && product3_count.Text != "0")
            {
                products.Add(new Product(product3.Content.ToString()) { count = Convert.ToInt32(product3_count.Text) });
            }
            else
            {
                allIsValid = false;
            }

            if (validateUserInput(product4_count.Text, product4.Content.ToString()) && product4_count.Text != "0")
            {
                products.Add(new Product(product4.Content.ToString()) { count = Convert.ToInt32(product4_count.Text) });
            }
            else
            {
                allIsValid = false;
            }

            if (validateUserInput(product5_count.Text, product5.Content.ToString()) && product5_count.Text != "0")
            {
                products.Add(new Product(product5.Content.ToString()) { count = Convert.ToInt32(product5_count.Text) });
            }
            else
            {
                allIsValid = false;
            }

            if (validateUserInput(product6_count.Text, product6.Content.ToString()) && product6_count.Text != "0")
            {
                products.Add(new Product(product6.Content.ToString()) { count = Convert.ToInt32(product6_count.Text) });
            }
            else
            {
                allIsValid = false;
            }

            MessageBox.Show("" + products.Count);
            for (int i = 0; i < products.Count; i++)
            {
                MessageBox.Show("" + products[i].name);
            }

            if(allIsValid)
            {
                this.NavigationService.Navigate(new Lieferdaten(products));
            }

        }



        private bool validateUserInput(string input, string content)
        {
            Regex rx = new Regex(@"^[0-9]{1,3}$");
            //Regex rx2 = new Regex(@"^[1-9]{1}([0-9]{1,2})?$");
            
            bool valide = false;
            
            if(rx.IsMatch(input)) {
                valide = true;
            }
            else
            {
                MessageBox.Show($"Bitte überprüfe die Anzahl von { content } versuche es erneut.");
            }

            return valide;
        }
    }
}
