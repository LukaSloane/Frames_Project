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

        private List<TextBox> textboxList;
        private List<Label> productLabels;
        
        public Shop()
        {
            
            InitializeComponent();
            product1.Content = "Koriander";
            product2.Content = "Mais";
            product3.Content = "Kidneybohnen";
            product4.Content = "Tomate";
            product5.Content = "Avocado";
            product6.Content = "Paprika";

            productLabels = new List<Label>();
            productLabels.Add(product1);
            productLabels.Add(product2);
            productLabels.Add(product3);
            productLabels.Add(product4);
            productLabels.Add(product5);
            productLabels.Add(product6);

            textboxList = new List<TextBox>();
            textboxList.Add(product1_count);
            textboxList.Add(product2_count);
            textboxList.Add(product3_count);
            textboxList.Add(product4_count);
            textboxList.Add(product5_count);
            textboxList.Add(product6_count);
        }

        private void btn_weiter_click(object sender, RoutedEventArgs e)
        {
           

            List<Product> products = new List<Product>();

            if(validateUserInput())
            {
                for (int i = 0; i < textboxList.Count; i++)
                {
                    if(textboxList[i].Text != "0")
                    {
                        products.Add(new Product(productLabels[i].Content.ToString()) { count = Convert.ToInt32(textboxList[i].Text) });
                    }
                }
                MessageBox.Show("" + products.Count);
                if(products.Count > 0)
                {
                    this.NavigationService.Navigate(new Lieferdaten(products));
                }
                
            }

        }



        private bool validateUserInput()
        {
            Regex rx = new Regex(@"^[0-9]{1,3}$");
            //Regex rx2 = new Regex(@"^[1-9]{1}([0-9]{1,2})?$");
            
            bool valid = true;

            for (int i = 0; i < textboxList.Count; i++)
            {
                if(!rx.IsMatch(textboxList[i].Text))
                {
                    MessageBox.Show($"Es ist ein Fehler aufgetreten. Bitte überprüfe deine Eingaben.");
                    valid = false;
                    break;
                    
                }
            }

            return valid;
        }

        private void btn_reset_click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < textboxList.Count; i++)
            {
                textboxList[i].Text = "0";
            }
        }
    }
}
