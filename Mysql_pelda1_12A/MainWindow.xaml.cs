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
    public partial class MainWindow : Window {

        List<Konyv> konyvek = new List<Konyv>();
        List<Szerzo> szerzok = new List<Szerzo>();
        string kapcsolatistring = "server = localhost;database = konyvek_12a; uid = root; password = '';";
        MySqlConnection kapcs;
        public MainWindow() {
            InitializeComponent();
            kapcs = new MySqlConnection(kapcsolatistring);
            kapcs.Open();
            var sql = "SELECT * FROM konyv";
            var parancs = new MySqlCommand(sql, kapcs);
            var lekerdezes = parancs.ExecuteReader();
            while (lekerdezes.Read()) {
                // A)
                //var temp = new Konyv();
                //temp.Id = (int)lekerdezes[0];
                //temp.Cim = (string)lekerdezes[1];
                //temp.SzerzoId = (int)lekerdezes[2];
                //temp.Helyezes = (int)lekerdezes[3];
                // B)
                var temp = new Konyv((int)lekerdezes[0], (string)lekerdezes[1], (int)lekerdezes[2], (int)lekerdezes[3]);
                // C)
                //var temp = new Konyv(lekerdezes.GetInt16(0), lekerdezes.GetString(1), lekerdezes.GetInt16(2), lekerdezes.GetInt16(3));
                konyvek.Add(temp);
            }
            kapcs.Close();
            dtgLista.ItemsSource = konyvek;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            //var rendezett = konyvek.OrderBy(item => item.Cim); //LINQ
            //var rendezett = konyvek.OrderByDescending(item => item.Cim);
            var rendezett = konyvek.OrderBy(item => item.SzerzoId).ThenBy(item => item.Cim);

            dtgLista.ItemsSource = rendezett;
        }
    }
}
