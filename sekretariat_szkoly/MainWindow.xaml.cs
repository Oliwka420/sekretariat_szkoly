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
        int number;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void uczen1a(object sender, RoutedEventArgs e)
        {
            meni.Header = "1a";
        }
        private void uczen1b(object sender, RoutedEventArgs e)
        {
            meni.Header = "1b";
        }
        private void uczen1c(object sender, RoutedEventArgs e)
        {
            meni.Header = "1c";
        }
        private void uczen2a(object sender, RoutedEventArgs e)
        {
            meni.Header = "2a";
        }
        private void uczen2b(object sender, RoutedEventArgs e)
        {
            meni.Header = "2b";
        }
        private void uczen2c(object sender, RoutedEventArgs e)
        {
            meni.Header = "2c";
        }
        private void uczen3a(object sender, RoutedEventArgs e)
        {
            meni.Header = "3a";
        }
        private void uczen3b(object sender, RoutedEventArgs e)
        {
            meni.Header = "3b";
        }
        private void uczen3c(object sender, RoutedEventArgs e)
        {
            meni.Header = "3c";
        }
        private void uczen4a(object sender, RoutedEventArgs e)
        {
            meni.Header = "4a";
        }
        private void uczen4b(object sender, RoutedEventArgs e)
        {
            meni.Header = "4b";
        }
        private void uczen4c(object sender, RoutedEventArgs e)
        {
            meni.Header = "4c";
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
    }
}
