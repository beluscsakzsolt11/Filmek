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


namespace Filmek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Film
        {
            public string Cím { get; set; }
            public string Műfaj { get; set; }
            public int Hossz { get; set; }
            public double Értékelés { get; set; }


            public Film(string cim, string mufaj, int hossz, double ertekeles)
            {
                Cím = cim;
                Műfaj = mufaj;
                Hossz = hossz;
                Értékelés = ertekeles;
            }
        }
        List<Film> lista = new List<Film>();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void betolt_Click(object sender, RoutedEventArgs e)
        {
            lista.Clear();
            lista.Add(new Film("Csillagok háborúja", "sci-fi", 121, 10));
            lista.Add(new Film("Titanic", "dráma", 195, 7.8));
            lista.Add(new Film("A Gyűrűk Ura", "fantasy", 201, 8.8));
            lista.Add(new Film("Mátrix", "sci-fi", 136, 8.7));
            lista.Add(new Film("Shrek", "animáció", 90, 7.9));
            tabla.ItemsSource = lista;
            tabla.Items.Refresh();
        }

        //hány film van?
        private void hanyfilm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ennyi db film van: " + lista.Count());
        }

        private void hossz_Click(object sender, RoutedEventArgs e)
        {
            if (lista.Count == 0)
            {
                MessageBox.Show("Nincsenek betöltve a filmek");
                return;
            }
            Film leghosszabb = lista[0];
            foreach (Film f in lista)
            {
                if (f.Hossz > leghosszabb.Hossz)
                {
                    leghosszabb = f;
                }
            }
            MessageBox.Show("A leghosszabb film: " + leghosszabb.Cím + " (" + leghosszabb.Hossz + " perc)");
        }
        //átlag
        private void atlag_Click(object sender, RoutedEventArgs e)
        {
            double osszeg = 0;
            foreach(var item in lista)
            {
                osszeg += item.Értékelés;
            }
            double atlag = 0;
            foreach(var item in lista)
            {
                atlag = osszeg / lista.Count();
            }
            MessageBox.Show("Átlag: " + atlag);
        }

        private void scifi_Click(object sender, RoutedEventArgs e)
        {
            List<Film> scifi = new List<Film>();
            foreach(var item in lista)
            {
                if (item.Műfaj == "sci-fi".ToUpper())
                {
                    scifi.Add(item);
                }
            }
            tabla.ItemsSource = scifi;
            tabla.Items.Refresh();
        }

        private void cimrendezes(object sender, RoutedEventArgs e)
        {
            tabla.ItemsSource = lista.OrderBy(f => f.Cím).ToList();
        }
    }
}