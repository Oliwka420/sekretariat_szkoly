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
using System.Data;

namespace sekretariat_szkoly
{

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


            String UImie, U2Imie, UNazwisko, UPesel, U2Nazwisko, UMatka, UOjciec, UKlasa, Ulaczona, UPlec, Udata;
            ComboBoxItem klasa = (ComboBoxItem)uczen_klasa.SelectedItem;
            ComboBoxItem laczona = (ComboBoxItem)uczen_laczona_klasa.SelectedItem;
            ComboBoxItem Plec = (ComboBoxItem)uczen_plec.SelectedItem;

            UImie = uczen_imie.Text;
            U2Imie = uczen2imie.Text;
            UNazwisko = uczen_nazwisko.Text;
            UPesel = uczen_pesel.Text;
            U2Nazwisko = uczen2nazwisko.Text;
            UMatka = uczen_matka.Text;
            UOjciec = uczen_ojciec.Text;
            UKlasa = klasa.Content.ToString();
            Ulaczona = laczona.Content.ToString();
            UPlec = Plec.Content.ToString();
            Udata = UczenData.SelectedDate.Value.Date.ToShortDateString();
            var rowGroup = table1.RowGroups.FirstOrDefault();

            if (rowGroup != null)
            {
                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.Blocks.Add(new Paragraph(new Run(UImie)));
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Blocks.Add(new Paragraph(new Run(U2Imie)));
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Blocks.Add(new Paragraph(new Run(UNazwisko)));
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Blocks.Add(new Paragraph(new Run(UPesel)));
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Blocks.Add(new Paragraph(new Run(UKlasa)));
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Blocks.Add(new Paragraph(new Run(Ulaczona)));
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Blocks.Add(new Paragraph(new Run(UPlec)));
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Blocks.Add(new Paragraph(new Run(U2Nazwisko)));
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Blocks.Add(new Paragraph(new Run(UMatka)));
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Blocks.Add(new Paragraph(new Run(UOjciec)));
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Blocks.Add(new Paragraph(new Run(Udata)));
                row.Cells.Add(cell);

                rowGroup.Rows.Add(row);
            }
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
        
        private void dodanie_nauczyciela(object sender, RoutedEventArgs e)
        {

            List<string> add_list = new List<string>();
            foreach (var item in lista.SelectedItems)
            {
                add_list.Add(item.ToString());
            }
            string report = string.Join(Environment.NewLine, add_list.Select(array => string.Join(" ", array)));
            test.Text = report;
        }

    }
}
