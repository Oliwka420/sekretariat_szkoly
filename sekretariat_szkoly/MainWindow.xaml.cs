using Microsoft.Win32;
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
using System.Linq;

namespace sekretariat_szkoly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //int number;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        
        private void dodanie_ucznia(object sender, RoutedEventArgs e)
        {
            /*bool isNumber = int.TryParse(uczen_pesel.Text, out number);

            if (isNumber)
            {
                //są same liczby
            }
            else
            {
                //pojawiła sie litera

            }*/
            /*char[] char_nazwisko = uczen_nazwisko.Text.ToCharArray();
            bool isString = char_nazwisko.Any(char.IsDigit);
            if (isString)
            {
                //są liczby
            }
            else
            {
                //nie ma liczb

            }*/
        }

        private void przesylanie_zdjecia_uczen(object sender, RoutedEventArgs e)
        {

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;";
                if (openFileDialog.ShowDialog() == true)
                {
                    string fullPath = openFileDialog.FileName;
                    string fileName = openFileDialog.SafeFileName;
                    string path = fullPath.Replace(fileName, "");

                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(fullPath, UriKind.Absolute));
                    //testowe.Content = img;
                    sciezkapliku.Content = fileName;
                }
        }
    }
}
