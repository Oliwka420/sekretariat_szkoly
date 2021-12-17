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
            table1.RowGroups[0].Rows.Add(new TableRow());
            TableRow currentRow = table1.RowGroups[0].Rows[2];

            // Global formatting for the footer row.
            currentRow.Background = Brushes.LightGray;
            currentRow.FontSize = 18;
            currentRow.FontWeight = System.Windows.FontWeights.Normal;

            // Add the header row with content,


            String UImie, U2Imie, UNazwisko, UPesel, U2Nazwisko, UMatka, UOjciec, UKlasa, Ulaczona, UPlec;
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

            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(UImie))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(U2Imie))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(UNazwisko))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(UPesel))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(UKlasa))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(Ulaczona))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(UPlec))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(U2Nazwisko))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(UMatka))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(UOjciec))));


            // and set the row to span all 6 columns.
            currentRow.Cells[0].ColumnSpan = 1;
            //testowe.Content = UImie + U2Imie + UNazwisko + UPesel + U2Nazwisko + UMatka + UOjciec + UKlasa + Ulaczona + UPlec;
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
