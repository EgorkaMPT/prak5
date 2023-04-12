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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        tovarTableAdapter tovar = new tovarTableAdapter();
        public Window2()
        {
            InitializeComponent();
        }

        private void t1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tovar.InsertQuery(t.Text, Convert.ToDecimal(t1.Text));
            w.ItemsSource = null;
            w.ItemsSource = tovar.GetData();
        }

        private void t_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (w.SelectedItem as DataRowView).Row[0];
            tovar.DeleteQuery(Convert.ToInt32(id));
            w.ItemsSource = tovar.GetData();
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            object id = (w.SelectedItem as DataRowView).Row[0];
            tovar.UpdateQuery(t.Text, Convert.ToDecimal(t1.Text), Convert.ToInt32(id));
            w.ItemsSource = tovar.GetData();
        }

        private void w_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (w.SelectedItem != null)
            {
                object selectedRow = (w.SelectedItem as DataRowView).Row[1];
                object selectedRow2 = (w.SelectedItem as DataRowView).Row[2];
                t.Text = Convert.ToString(selectedRow);
                t1.Text = Convert.ToString(selectedRow2);
            }
        }
    }
}
