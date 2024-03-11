using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Timers;
using System.ComponentModel;

namespace Bron
{
    /// <summary>
    /// Логика взаимодействия для Spisok.xaml
    /// </summary>
    public partial class Spisok : Window
    {

        public int d = 0;

        public int p = 0;
        System.Timers.Timer t;
        int s = 1;

        public Spisok()
        {
            InitializeComponent();
            LoadGrid();

            vrema.Content = DateTime.Now.ToString("dd.MM HH:mm:ss");

            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
            t.Start();

        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            s--;
            if (s == 0)
            {
                Dispatcher.Invoke((Action)(() => {
                    t.Start();
                    p = 0;
                    s = 1;

                    vrema.Content = DateTime.Now.ToString("dd.MM HH:mm:ss");

                }));
            }
        }


        SqlConnection con = new SqlConnection("Integrated Security = false;User Id = user132_db;Password = user132;Initial Catalog = user132_db;server = stud-mssql.sttec.yar.ru,38325;");

        private void LoadGrid()
        {
            if (mer.SelectedIndex == 0)
            {
                SqlCommand cmd = new SqlCommand("select m.Nazvanie as 'Мероприятие', s.Nazvanie as 'Сеанс', Vrema_Nachala as 'Время начала', Vrema_Okonchaniya as 'Время окончания', kol_vo_mest as 'Количество мест', Chena as 'Цена' from mdk0701_seans as s join mdk0701_meropriatie as m on s.id_meropriatia = m.id_meropriatia where s.Nazvanie like '%" + filtr.Text + "%' or m.Nazvanie like '%" + filtr.Text + "%' ", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                con.Close();
            }
            else if (mer.SelectedIndex == 1)
            {
                SqlCommand cmd = new SqlCommand("select m.Nazvanie as 'Мероприятие', s.Nazvanie as 'Сеанс', Vrema_Nachala as 'Время начала', Vrema_Okonchaniya as 'Время окончания', kol_vo_mest as 'Количество мест', Chena as 'Цена' from mdk0701_seans as s join mdk0701_meropriatie as m on s.id_meropriatia = m.id_meropriatia where m.id_meropriatia = 1 and (s.Nazvanie like '%" + filtr.Text + "%' or m.Nazvanie like '%" + filtr.Text + "%') ", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                con.Close();
            }
            else if (mer.SelectedIndex == 2)
            {
                SqlCommand cmd = new SqlCommand("select m.Nazvanie as 'Мероприятие', s.Nazvanie as 'Сеанс', Vrema_Nachala as 'Время начала', Vrema_Okonchaniya as 'Время окончания', kol_vo_mest as 'Количество мест', Chena as 'Цена' from mdk0701_seans as s join mdk0701_meropriatie as m on s.id_meropriatia = m.id_meropriatia where m.id_meropriatia = 2 and (s.Nazvanie like '%" + filtr.Text + "%' or m.Nazvanie like '%" + filtr.Text + "%') ", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                con.Close();
            }
            else if (mer.SelectedIndex == 3)
            {
                SqlCommand cmd = new SqlCommand("select m.Nazvanie as 'Мероприятие', s.Nazvanie as 'Сеанс', Vrema_Nachala as 'Время начала', Vrema_Okonchaniya as 'Время окончания', kol_vo_mest as 'Количество мест', Chena as 'Цена' from mdk0701_seans as s join mdk0701_meropriatie as m on s.id_meropriatia = m.id_meropriatia where m.id_meropriatia = 3 and (s.Nazvanie like '%" + filtr.Text + "%' or m.Nazvanie like '%" + filtr.Text + "%') ", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                con.Close();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mer.SelectedIndex == 0)
            {
                SqlCommand cmd = new SqlCommand("select m.Nazvanie as 'Мероприятие', s.Nazvanie as 'Сеанс', Vrema_Nachala as 'Время начала', Vrema_Okonchaniya as 'Время окончания', kol_vo_mest as 'Количество мест', Chena as 'Цена' from mdk0701_seans as s join mdk0701_meropriatie as m on s.id_meropriatia = m.id_meropriatia where s.Nazvanie like '%" + filtr.Text + "%' or m.Nazvanie like '%" + filtr.Text + "%' ", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                con.Close();
            }
            else if (mer.SelectedIndex == 1)
            {
                SqlCommand cmd = new SqlCommand("select m.Nazvanie as 'Мероприятие', s.Nazvanie as 'Сеанс', Vrema_Nachala as 'Время начала', Vrema_Okonchaniya as 'Время окончания', kol_vo_mest as 'Количество мест', Chena as 'Цена' from mdk0701_seans as s join mdk0701_meropriatie as m on s.id_meropriatia = m.id_meropriatia where m.id_meropriatia = 1 and (s.Nazvanie like '%" + filtr.Text + "%' or m.Nazvanie like '%" + filtr.Text + "%') ", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                con.Close();
            }
            else if (mer.SelectedIndex == 2)
            {
                SqlCommand cmd = new SqlCommand("select m.Nazvanie as 'Мероприятие', s.Nazvanie as 'Сеанс', Vrema_Nachala as 'Время начала', Vrema_Okonchaniya as 'Время окончания', kol_vo_mest as 'Количество мест', Chena as 'Цена' from mdk0701_seans as s join mdk0701_meropriatie as m on s.id_meropriatia = m.id_meropriatia where m.id_meropriatia = 2 and (s.Nazvanie like '%" + filtr.Text + "%' or m.Nazvanie like '%" + filtr.Text + "%') ", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                con.Close();
            }
            else if (mer.SelectedIndex == 3)
            {
                SqlCommand cmd = new SqlCommand("select m.Nazvanie as 'Мероприятие', s.Nazvanie as 'Сеанс', Vrema_Nachala as 'Время начала', Vrema_Okonchaniya as 'Время окончания', kol_vo_mest as 'Количество мест', Chena as 'Цена' from mdk0701_seans as s join mdk0701_meropriatie as m on s.id_meropriatia = m.id_meropriatia where m.id_meropriatia = 3 and (s.Nazvanie like '%" + filtr.Text + "%' or m.Nazvanie like '%" + filtr.Text + "%') ", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                con.Close();
            }
        }

        private void mer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (mer.SelectedIndex == 0)
            {
                if (d >= 1)
                {
                    SqlCommand cmd = new SqlCommand("select m.Nazvanie as 'Мероприятие', s.Nazvanie as 'Сеанс', Vrema_Nachala as 'Время начала', Vrema_Okonchaniya as 'Время окончания', kol_vo_mest as 'Количество мест', Chena as 'Цена' from mdk0701_seans as s join mdk0701_meropriatie as m on s.id_meropriatia = m.id_meropriatia where s.Nazvanie like '%" + filtr.Text + "%' or m.Nazvanie like '%" + filtr.Text + "%' ", con);
                    DataTable dt = new DataTable();
                    con.Open();
                    SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                    sdr.Fill(dt);
                    dataGrid.ItemsSource = dt.DefaultView;
                    con.Close();
                }
                d = d + 1;
            }
            else if (mer.SelectedIndex == 1)
            {
                SqlCommand cmd = new SqlCommand("select m.Nazvanie as 'Мероприятие', s.Nazvanie as 'Сеанс', Vrema_Nachala as 'Время начала', Vrema_Okonchaniya as 'Время окончания', kol_vo_mest as 'Количество мест', Chena as 'Цена' from mdk0701_seans as s join mdk0701_meropriatie as m on s.id_meropriatia = m.id_meropriatia where m.id_meropriatia = 1 and (s.Nazvanie like '%" + filtr.Text + "%' or m.Nazvanie like '%" + filtr.Text + "%') ", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                con.Close();
            }
            else if (mer.SelectedIndex == 2)
            {
                SqlCommand cmd = new SqlCommand("select m.Nazvanie as 'Мероприятие', s.Nazvanie as 'Сеанс', Vrema_Nachala as 'Время начала', Vrema_Okonchaniya as 'Время окончания', kol_vo_mest as 'Количество мест', Chena as 'Цена' from mdk0701_seans as s join mdk0701_meropriatie as m on s.id_meropriatia = m.id_meropriatia where m.id_meropriatia = 2 and (s.Nazvanie like '%" + filtr.Text + "%' or m.Nazvanie like '%" + filtr.Text + "%') ", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                con.Close();
            }
            else if (mer.SelectedIndex == 3) {
                SqlCommand cmd = new SqlCommand("select m.Nazvanie as 'Мероприятие', s.Nazvanie as 'Сеанс', Vrema_Nachala as 'Время начала', Vrema_Okonchaniya as 'Время окончания', kol_vo_mest as 'Количество мест', Chena as 'Цена' from mdk0701_seans as s join mdk0701_meropriatie as m on s.id_meropriatia = m.id_meropriatia where m.id_meropriatia = 3 and (s.Nazvanie like '%" + filtr.Text + "%' or m.Nazvanie like '%" + filtr.Text + "%') ", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                con.Close();
            }
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView rowview = dataGrid.SelectedItem as DataRowView;
            string mero = rowview.Row[0].ToString();
            string sean = rowview.Row[1].ToString();

            string Connect = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user132_db;persist security info=True;user id=user132_db;password=user132;MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection myConnection = new SqlConnection(@Connect);
            myConnection.Open();
            string CommandText1 = "Select id_seansa from mdk0701_seans where Nazvanie = '" + sean + "'";
            SqlCommand myCommand1 = new SqlCommand(CommandText1, myConnection);
            myCommand1.ExecuteNonQuery();
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(myCommand1);
            DataTable dt1 = new DataTable();
            dataAdapter1.Fill(dt1);
            App.Current.Resources["id"] = Convert.ToInt32(dt1.Rows[0][0].ToString());
            myConnection.Close();
 
                Podtv f = new Podtv();
                f.Show();
                this.Hide();

        }
    }
}
