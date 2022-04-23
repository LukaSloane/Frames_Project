﻿using System;
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
    /// Interaktionslogik für Lieferdaten.xaml
    /// </summary>
    public partial class Lieferdaten : Page
    {
       private List<Product> products;
        private List<TextBox> userData;

        public Lieferdaten(List<Product> products)
        {
            this.products = products;
            InitializeComponent();

            userData = new List<TextBox>();
            userData.Add(input_Name);
            userData.Add(input_Street);
            userData.Add(input_PLZ);
            userData.Add(input_Town);
            userData.Add(input_Email);
            userData.Add(input_Phone);
        }

        private void btn_weiter_click(object sender, RoutedEventArgs e)
        {
            if(validateUserInput())
            {
                Person person = new Person(input_Name.ToString(), input_Street.ToString(), input_PLZ.ToString(), input_Town.ToString(), input_Email.ToString(), input_Phone.ToString());
                
                MessageBox.Show("Hat geklappt");
            }
        }

        private void btn_back_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private bool validateUserInput()
        {
            Regex rxName = new Regex(@"^[a-zA-Z]{2,12}\s[a-zA-Z]{2,12}(\s[a-zA-Z]{2,12})?$");
            Regex rxStreet = new Regex(@"^[a-zA-Zß]{5,25}\s([a-zA-Z]{3,9}\s)?[0-9]{1,2}(\s?[a-zA-Z])?$");
            Regex rxPLZ = new Regex(@"^[0-9]{5}$");
            Regex rxTown = new Regex(@"^[a-zA-Z]{3,20}(\s[a-zA-Z]{3,20})?$");
            Regex rxPhone = new Regex(@"^[0-9]{10,15}$");
            Regex rxEmail = new Regex(@"^[a-zA-Z0-9_\-\.]{4,20}@[a-zA-Z]{3,15}[\.][a-z]{2,5}([\.][a-z]{2})?$");


            if(!rxName.IsMatch(input_Name.Text))
            {
                MessageBox.Show("Bitte gib einen richtigen Namen ein.");
                return false;
            }
            if(!rxStreet.IsMatch(input_Street.Text))
            {
                MessageBox.Show("Bitte gib eine richtige Straße mit Hausnummer ein");
                return false;
            }
            if(!rxPLZ.IsMatch(input_PLZ.Text))
            {
                MessageBox.Show("Bitte gib eine richtige Postleitzahl ein.");
                return false;
            }
            if(!rxTown.IsMatch(input_Town.Text))
            {
                MessageBox.Show("Bitte gib einen richtigen Ort ein.");
                return false;
            }
            if(!rxEmail.IsMatch(input_Email.Text))
            {
                MessageBox.Show("Bitte gib eine valide Email Adresse ein.");
                return false;
            }
            if(!rxPhone.IsMatch(input_Phone.Text))
            {
                MessageBox.Show("Bitte gib eine richtige Telefonnumer ein.");
                return false;
            }

            return true;

        }
    }
}
