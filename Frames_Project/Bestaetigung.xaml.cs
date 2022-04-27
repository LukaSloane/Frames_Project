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

namespace Frames_Project
{
    /// <summary>
    /// Interaktionslogik für Bestaetigung.xaml
    /// </summary>
    public partial class Bestaetigung : Page
    {
        public Bestaetigung()
        {
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

            XFont font = new XFont("Arial", 20);

            gfx.DrawString("First line of text", font, XBrushes.Black,
                new XRect(0, 0, page.Width, page.Height),
                XStringFormats.Center);

            gfx.DrawString("Second line of text", font, XBrushes.Violet,
                new XRect(0, 0, page.Width, page.Height),
                XStringFormats.BottomLeft);

            //gfx.DrawString("Third line of text", font, XBrushes.Tomato,
            //    new XRect(0, 0, page.Width, page.Height),
            //    XStringFormats.BaseLineRight);

            gfx.DrawString("Fourth line of text", font, XBrushes.Violet,
                new XPoint(100, 300));

            document.Save("C:\\Users\\lskessel\\Downloads\\testpdf.pdf");
        }
    }
}
