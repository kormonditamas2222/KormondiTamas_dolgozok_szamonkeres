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
    }
}