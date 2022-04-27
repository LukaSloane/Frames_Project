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
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using Frames_Project.Klassen;

namespace Frames_Project
{
    /// <summary>
    /// Interaktionslogik für Bestaetigung.xaml
    /// </summary>
    public partial class Bestaetigung : Page
    {

        Person person;
        List<Product> products;
        Bankaccount konto;
        public Bestaetigung(Person person, List<Product> products, Bankaccount konto)
        {
            this.person = person;
            this.products = products;
            this.konto = konto;
            InitializeComponent();
        }

        private void btn_back_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void btn_weiter_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.RemoveBackEntry();
            this.NavigationService.Navigate(new Shop());
        }

        private void CreatePDF(object sender, RoutedEventArgs e)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Arial", 18);
            XFont fontHeading = new XFont("Arial", 36);
            XFont fontKonto = new XFont("Arial", 13);

            //gfx.DrawString("First line of text", font, XBrushes.Black,
            //    new XRect(0, 0, page.Width, page.Height),
            //    XStringFormats.Center);



            //gfx.DrawString("Third line of text", font, XBrushes.Tomato,
            //    new XRect(0, 0, page.Width, page.Height),
            //    XStringFormats.BaseLineRight);

            //gfx.DrawString("Fourth line of text", font, XBrushes.Violet,
            //    new XPoint(100, 300));

            gfx.DrawString(person.name, font, XBrushes.Black,
                new XPoint(400,80));
            gfx.DrawString(person.street, font, XBrushes.Black,
                new XPoint(400, 100));
            gfx.DrawString(person.plz + " " + person.town, font, XBrushes.Black,
                new XPoint(400, 120));           
            gfx.DrawString(person.email, font, XBrushes.Black,
                new XPoint(400, 140));
            gfx.DrawString(person.phone, font, XBrushes.Black,
                new XPoint(400, 160));
            gfx.DrawString("Rechnung", fontHeading, XBrushes.Black,
                new XPoint(200, 300));

            gfx.DrawString($"Kontoinhaber: {konto.name}, IBAN: {konto.IBAN}", fontKonto, XBrushes.Gray,
                new XRect(20, -10, page.Width, page.Height),
                XStringFormats.BottomLeft);

            int y = 350;

            for (int i = 0; i < products.Count; i++)
            {
                gfx.DrawString(products[i].count + " x " + products[i].name, font, XBrushes.Black,
                new XPoint(300, y));
                y += 20;
            }

            document.Save("C:\\Users\\lskessel\\Downloads\\Rechnung.pdf");
            //document.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }
    }
}
