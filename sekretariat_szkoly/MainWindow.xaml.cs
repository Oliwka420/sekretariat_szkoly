﻿using Microsoft.Win32;
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
        public void dodanierekordu(string x, TableRow s)
        {
            TableCell cell = new TableCell();
            cell.Blocks.Add(new Paragraph(new Run(x)));
            s.Cells.Add(cell);
        }

        /*public void sprawdzenie_poprawnosc(string co, string skad, bool poprawnosc)
        {

        }*/
        public void dodanie_ucznia(object sender, RoutedEventArgs e)
        {
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

            bool git_pesel = false, git_nazwisko = false, git_imie = false, git2imie = false, git2Nazwisko = false, git_matka = false, gitOjciec = false, gitData = false;
            int number;
            bool isNumber = int.TryParse(UPesel, out number);
            if (isNumber)
            {
                git_pesel = true;
            }
            else
            {
                MessageBox.Show("nieprawidlowy pesel");
                git_pesel = false;

            }
            char[] char_imie = UImie.ToCharArray();
            bool isString = char_imie.Any(char.IsDigit);
            if (isString || String.IsNullOrEmpty(UImie))
            {
                MessageBox.Show("nieprawidlowe imie");
                git_imie = false;
            }
            else
            {
                git_imie = true;
            }

            char[] char_2imie = U2Imie.ToCharArray();
            isString = char_2imie.Any(char.IsDigit);
            if (isString || String.IsNullOrEmpty(U2Imie))
            {
                MessageBox.Show("nieprawidlowe drugie imie");
                git2imie = false;
            }
            else
            {
                git2imie = true;
            }

            char[] char_nazwisko = UNazwisko.ToCharArray();
            isString = char_nazwisko.Any(char.IsDigit);
            if (isString || String.IsNullOrEmpty(UNazwisko))
            {
                MessageBox.Show("nieprawidlowe nazwisko");
                git_nazwisko = false;
            }
            else
            {
                git_nazwisko = true;
            }
            char[] char_2nazwisko = U2Nazwisko.ToCharArray();
            isString = char_2nazwisko.Any(char.IsDigit);
            if (isString || String.IsNullOrEmpty(U2Nazwisko))
            {
                MessageBox.Show("nieprawidlowe nazwisko panienskie");
                git2Nazwisko = false;
            }
            else
            {
                git2Nazwisko = true;
            }
            char[] char_matka = UMatka.ToCharArray();
            isString = char_matka.Any(char.IsDigit);
            if (isString || String.IsNullOrEmpty(UMatka))
            {
                MessageBox.Show("nieprawidlowe imie matki");
                git_matka = false;
            }
            else
            {
                git_matka = true;
            }
            char[] char_ojciec = UOjciec.ToCharArray();
            isString = char_ojciec.Any(char.IsDigit);
            if (isString || String.IsNullOrEmpty(UOjciec))
            {
                MessageBox.Show("nieprawidlowe imie ojca");
                gitOjciec = false;
            }
            else
            {
                gitOjciec = true;
            }
            if (UczenData.SelectedDate == null)
            {
                gitData = false;
                MessageBox.Show("wybierz date urodzenia! ");
            }
            else
            {
                Udata = UczenData.SelectedDate.Value.Date.ToShortDateString();
                gitData = true;
                if (git_nazwisko && git_pesel && git_imie && git2imie && git2Nazwisko && git_matka && gitOjciec && gitData)
                {
                    var rowGroup = table1.RowGroups.FirstOrDefault();
                    if (rowGroup != null)
                    {
                        TableRow row = new TableRow();
                        dodanierekordu(UImie, row);
                        dodanierekordu(U2Imie, row);
                        dodanierekordu(UNazwisko, row);
                        dodanierekordu(UPesel, row);
                        dodanierekordu(UKlasa, row);
                        dodanierekordu(Ulaczona, row);
                        dodanierekordu(UPlec, row);
                        dodanierekordu(U2Nazwisko, row);
                        dodanierekordu(UMatka, row);
                        dodanierekordu(UOjciec, row);
                        dodanierekordu(Udata, row);
                        TableCell cell = new TableCell();
                        cell.Blocks.Add(zdjecieUcznia);
                        row.Cells.Add(cell);
                        rowGroup.Rows.Add(row);
                    }
                }
            }
        }
        BlockUIContainer zdjecieUcznia;
        BlockUIContainer zdjecieNauczyciela;
        BlockUIContainer ZdjeciePracownika;
        public void przesylanie_zdjecia_uczen(object sender, RoutedEventArgs e)
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
                zdjecieUcznia = new BlockUIContainer(img);

                }
        }
        private void przesylanie_zdjecia_nauczyciel(object sender, RoutedEventArgs e)
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
                zdjecieNauczyciela = new BlockUIContainer(img);
            }
        }

        private void przesylanie_zdjecia_pracownik(object sender, RoutedEventArgs e)
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
                ZdjeciePracownika = new BlockUIContainer(img);
            }
        }
        private void dodanie_nauczyciela(object sender, RoutedEventArgs e)
        {
            List<string> add_list = new List<string>();
            foreach (var item in lista.SelectedItems)
            {
                add_list.Add(item.ToString());
            }
            for (int i = 0; i < add_list.Count; i++)
            {
                add_list[i] = add_list[i].Substring(add_list[i].Length - 2);
            } 

            List<string> add_list2 = new List<string>();
            foreach (var item in lista2.SelectedItems)
            {
                add_list2.Add(item.ToString());
            }
            for (int i = 0; i < add_list2.Count; i++)
            {
                add_list2[i] = add_list2[i].Substring(36);
            }
            string klasy_ktore_uczy = string.Join(" ", add_list);
            string przedmioty_ktore_uczy = string.Join(" ", add_list2);


            String NImie, N2Imie, NNazwisko, N2Nazwisko, NMatka, NOjciec, NData, NData_zatr, NPesel, NPlec, NWychowastwo;
            //ComboBoxItem klasa = (ComboBoxItem)uczen_klasa.SelectedItem;
            ComboBoxItem wychowastwo = (ComboBoxItem)NauczycielWychowawca.SelectedItem;
            ComboBoxItem Plec = (ComboBoxItem)NauczycielPlec.SelectedItem;

            NImie = NauczycielImie.Text;
            N2Imie = Nauczyciel2Imie.Text;
            NNazwisko = NauczycielNazwisko.Text;
            N2Nazwisko = Nauczyciel2Nazwisko.Text;
            NMatka = NauczycielMatka.Text;
            NOjciec = NauczycielOjciec.Text;
            NPesel = NauczycielPesel.Text;
            NPlec = Plec.Content.ToString();
            NWychowastwo = wychowastwo.Content.ToString();
            NData = NauczycielUrodzenie.SelectedDate.Value.Date.ToShortDateString();
            NData_zatr = NauczycielZatrudnienie.SelectedDate.Value.Date.ToShortDateString();

            var rowGroup = table2.RowGroups.FirstOrDefault();
            if (rowGroup != null)
            {
                TableRow row = new TableRow();
                dodanierekordu(NImie, row);
                dodanierekordu(N2Imie, row);
                dodanierekordu(NNazwisko, row);
                dodanierekordu(NWychowastwo, row);
                dodanierekordu(NPesel, row);
                dodanierekordu(NPlec, row);
                dodanierekordu(N2Nazwisko, row);
                dodanierekordu(NMatka, row);
                dodanierekordu(NOjciec, row);
                dodanierekordu(przedmioty_ktore_uczy, row);
                dodanierekordu(NData, row);
                dodanierekordu(NData_zatr, row);
                dodanierekordu(klasy_ktore_uczy, row);
                TableCell cell = new TableCell();
                cell.Blocks.Add(zdjecieNauczyciela);
                row.Cells.Add(cell);
                rowGroup.Rows.Add(row);
            }

        }

        private void dodanie_pracownika(object sender, RoutedEventArgs e)
        {
            String PImie, P2Imie, PNazwisko, P2Nazwisko, Pmatka, POjciec, PData, PPesel, PPlec, PEtat, POpis, PPDataZatr;

            //ComboBoxItem klasa = (ComboBoxItem)uczen_klasa.SelectedItem;
            ComboBoxItem etat = (ComboBoxItem)Pracownikletat.SelectedItem;
            ComboBoxItem Plec = (ComboBoxItem)PracowniklPlec.SelectedItem;

            PImie = PracownikImie.Text;
            P2Imie = Pracownik2Imie.Text;
            PNazwisko = PracownikNazwisko.Text;
            P2Nazwisko = Pracownik2Nazwisko.Text;
            Pmatka = PracownikMatka.Text;
            POjciec = PracownikOjciec.Text;
            PData = Pracownik_urodzenie.SelectedDate.Value.Date.ToShortDateString();
            PPesel = PracownikPesel.Text;
            PPlec = Plec.Content.ToString();
            PEtat = etat.Content.ToString();
            POpis = PracownikOpis.Text;
            PPDataZatr = Pracownikzatr.SelectedDate.Value.Date.ToShortDateString();

            var rowGroup = table3.RowGroups.FirstOrDefault();
            if (rowGroup != null)
            {
                TableRow row = new TableRow();
                dodanierekordu(PImie, row);
                dodanierekordu(P2Imie, row);
                dodanierekordu(PNazwisko, row);
                dodanierekordu(P2Nazwisko, row);
                dodanierekordu(Pmatka, row);
                dodanierekordu(POjciec, row);
                dodanierekordu(PData, row);
                dodanierekordu(PPesel, row);
                dodanierekordu(PPlec, row);
                dodanierekordu(PEtat, row);
                dodanierekordu(POpis, row);
                dodanierekordu(PPDataZatr, row);
                TableCell cell = new TableCell();
                cell.Blocks.Add(ZdjeciePracownika);
                row.Cells.Add(cell);
                rowGroup.Rows.Add(row);
            }

        }


    }
}
