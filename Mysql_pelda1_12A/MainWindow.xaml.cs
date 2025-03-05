using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Mysql_pelda1_12A {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Datagridhez {
        public int Helyezes { get; set; }
        public string Cim { get; set; }
        public string Nev { get; set; }
        public string Nemzetiseg { get; set; }
        public Datagridhez(int helyezes, string cim, string nev, string nemzetiseg) {
            Helyezes = helyezes;
            Cim = cim;
            Nev = nev;
            Nemzetiseg = nemzetiseg;
        }
    }
    public partial class MainWindow : Window {

        List<Konyv> konyvek = new List<Konyv>();
        List<Szerzo> szerzok = new List<Szerzo>();
        List<Datagridhez> datagridhez = new List<Datagridhez>();

        string kapcsolatistring = "server = localhost;database = konyvek_12a; uid = root; password = '';";
        MySqlConnection kapcs;
        public MainWindow() {
            InitializeComponent();
            kapcs = new MySqlConnection(kapcsolatistring);
            kapcs.Open();
            var sql = "SELECT helyezes, cim, nev, nemzetiseg FROM konyv,szerzo WHERE konyv.szerzoId = szerzo.id";
            var parancs = new MySqlCommand(sql, kapcs);
            var lekerdezes = parancs.ExecuteReader();
            while (lekerdezes.Read()) {
                var temp = new Datagridhez((int)lekerdezes[0], (string)lekerdezes[1], (string)lekerdezes[2], (string)lekerdezes[3]);
                datagridhez.Add(temp);
            }
            kapcs.Close();
            dtgLista.ItemsSource = datagridhez;
        }
    }
}
