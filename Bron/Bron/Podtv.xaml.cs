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
using System.Windows.Shapes;

namespace Bron
{
    /// <summary>
    /// Логика взаимодействия для Podtv.xaml
    /// </summary>
    public partial class Podtv : Window
    {
        public Podtv()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connect = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user132_db;persist security info=True;user id=user132_db;password=user132;MultipleActiveResultSets=True;App=EntityFramework";

            SqlConnection myConnection = new SqlConnection(@connect);

            myConnection.Open();

            string sInsSql = "Insert into mdk0701_bilet(id_seansa,Mesto,Email,Telefon) Values('{0}', '{1}', '{2}', '{3}')";

            // Считываем данные с формы 
            string a = Convert.ToString(App.Current.Resources["id"]);
            string n = me.Text;
            string s = ema.Text;
            string d = telef.Text;

            string sInsSotr = string.Format(sInsSql, a, n, s, d);

            SqlCommand cmdIns = new SqlCommand(sInsSotr, myConnection);

            cmdIns.ExecuteNonQuery();
            MessageBox.Show(string.Format("Спасибо за покупку"), "Сообщение");

            myConnection.Close();

            Spisok f = new Spisok();
            f.Show();
            this.Hide();
        }
    }
}
