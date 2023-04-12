using praktika.pr2DataSetTableAdapters;
using System;
using System.Collections.Generic;
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

namespace praktika
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        shopTableAdapter shop = new shopTableAdapter();
        clientTableAdapter client = new clientTableAdapter();
        tovarTableAdapter tovar = new tovarTableAdapter();
        public Window1()
        {
            InitializeComponent();
            t2.ItemsSource = client.GetData();
            t3.ItemsSource = tovar.GetData();

            t2.DisplayMemberPath = "names";
            t2.SelectedValuePath = "client_id";
            t3.DisplayMemberPath = "names";
            t3.SelectedValuePath = "tovar_id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object cell1 = (t2.SelectedItem as DataRowView).Row[0];
            object cell2 = (t3.SelectedItem as DataRowView).Row[0];
            shop.InsertQuery(t.Text, t1.Text, Convert.ToInt32(cell1.ToString()), Convert.ToInt32(cell2.ToString()));
            w.ItemsSource = null;
            w.ItemsSource = shop.GetData();
        }

        private void t_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void t1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (w.SelectedItem as DataRowView).Row[0];
            shop.DeleteQuery(Convert.ToInt32(id));
            w.ItemsSource = shop.GetData();
        }
        private void b5_Click(object sender, RoutedEventArgs e)
        {
            object id = (w.SelectedItem as DataRowView).Row[0];
            shop.UpdateQuery(t.Text, t1.Text, Convert.ToInt32(t2.SelectedValue), Convert.ToInt32(t3.SelectedValue), Convert.ToInt32(id));
            w.ItemsSource = shop.GetData();
        }

        private void w_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (w.SelectedItem != null)
            {
                object selectedRow = (w.SelectedItem as DataRowView).Row[1];
                object selectedRow2 = (w.SelectedItem as DataRowView).Row[2];
                object selectedRow3 = (w.SelectedItem as DataRowView).Row[3];
                object selectedRow4 = (w.SelectedItem as DataRowView).Row[4];
                t.Text = Convert.ToString(selectedRow);
                t1.Text = Convert.ToString(selectedRow2);
                t2.SelectedValue = selectedRow3;
                t3.SelectedValue = selectedRow4;
            }
        }
    }
}
