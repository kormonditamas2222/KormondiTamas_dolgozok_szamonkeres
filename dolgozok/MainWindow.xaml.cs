using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dolgozok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Dolgozo> dolgozok = [];
        public MainWindow()
        {
            InitializeComponent();
            Beolvasas();
            ListBoxFeltoltes();
            ComboBoxFeltoltes();
        }
        private void Beolvasas()
        {
            StreamReader sr = new("dolgozok.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] reszek = sr.ReadLine().Trim().Split(";");
                Dolgozo dolgozo = new(reszek[0], reszek[1], reszek[2], reszek[3], int.Parse(reszek[4]), reszek[5]);
                dolgozok.Add(dolgozo);
            }
        }
        private void ListBoxFeltoltes()
        {
            List<string> nevek = [];
            foreach (Dolgozo dolgozo in dolgozok)
            {
                if (!nevek.Contains(dolgozo.Nev))
                nevek.Add(dolgozo.Nev);
            }
            lb_dolgozok.ItemsSource = nevek;
        }
        private void ComboBoxFeltoltes()
        {
            List<string> beosztasok = [];
            foreach (Dolgozo dolgozo in dolgozok)
            {
                if (!beosztasok.Contains(dolgozo.Beosztas))
                {
                    beosztasok.Add(dolgozo.Beosztas);
                }
            }
            cb_beosztas.ItemsSource = beosztasok;
        }

        private void lb_dolgozok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string kivalasztott = lb_dolgozok.SelectedItem.ToString() ?? "";
            foreach (Dolgozo dolgozo in dolgozok)
            {
                if (kivalasztott == dolgozo.Nev)
                {
                    lbl_dolgozonev.Content = dolgozo.ToString();
                }
            }
        }

        private void btn_be_Click(object sender, RoutedEventArgs e)
        {
            if (tb_nev.Text == "Név:" || string.IsNullOrEmpty(tb_nev.Text) || tb_email.Text == "Email:" || string.IsNullOrEmpty(tb_email.Text) || tb_telefon.Text == "Telefonszám:" || string.IsNullOrEmpty(tb_telefon.Text) || tb_fizetes.Text == "Fizetés:" || string.IsNullOrEmpty(tb_fizetes.Text) || cb_beosztas.SelectedIndex == -1 || (rb_ferfi.IsChecked == false && rb_no.IsChecked == false))
            {
                MessageBox.Show(this, "Hibás bevitel", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string nemErtek;
                if (rb_ferfi.IsChecked == true)
                {
                    nemErtek = "Férfi";
                }
                else
                {
                    nemErtek = "Nő";
                }
                Dolgozo uj_dolgozo = new(tb_nev.Text, cb_beosztas.SelectedItem.ToString(), tb_email.Text, tb_telefon.Text, int.Parse(tb_fizetes.Text), nemErtek);
                dolgozok.Add(uj_dolgozo);
                StreamWriter sw = new("dolgozok.txt", append: true); // az appendet a chatgpt mondta meg nekem, tudtam hogy van ilyen csak nem jutott eszembe hogyan kell implementálni
                sw.WriteLine($"{tb_nev.Text};{cb_beosztas.SelectedItem.ToString()};{tb_email.Text};{tb_telefon.Text};{int.Parse(tb_fizetes.Text)};{nemErtek}");
                sw.Close();
                MessageBox.Show(this, "A bevitel sikeres.", "Információ", MessageBoxButton.OK, MessageBoxImage.Information);
                ListBoxFeltoltes();
            }
        }
    }
}