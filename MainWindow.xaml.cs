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
using System.Windows.Navigation;
using System.Windows.Shapes;
using praktika.pr2DataSetTableAdapters;

namespace praktika
{

    public partial class MainWindow : Window
    {
        clientTableAdapter ffx = new clientTableAdapter();
        shopTableAdapter fxx = new shopTableAdapter();
        tovarTableAdapter xxx = new tovarTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            PrrComboBox.ItemsSource = ffx.GetData();
            PrrComboBox.DisplayMemberPath = "names";
            PrxDaraGrid.ItemsSource = ffx.GetData();
        }

        private void PrrComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (PrrComboBox.SelectedItem as DataRowView).Row[0];
            MessageBox.Show(cell.ToString());
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            window1.w.ItemsSource = fxx.GetData();
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
            window2.w.ItemsSource = xxx.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ffx.InsertQuery(tx.Text, tx1.Text, tx2.Text, tx3.Text);
            PrxDaraGrid.ItemsSource = null;
            PrxDaraGrid.ItemsSource = ffx.GetData();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (PrxDaraGrid.SelectedItem as DataRowView).Row[0];
            ffx.DeleteQuery(Convert.ToInt32(id));
            PrxDaraGrid.ItemsSource = ffx.GetData();
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            object id = (PrxDaraGrid.SelectedItem as DataRowView).Row[0];
            ffx.UpdateQuery(tx.Text, tx1.Text, tx2.Text, tx3.Text, Convert.ToInt32(id));
            PrxDaraGrid.ItemsSource = ffx.GetData();
        }
     

        private void PrxDaraGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PrxDaraGrid.SelectedItem != null)
            {
                object selectedRow = (PrxDaraGrid.SelectedItem as DataRowView).Row[1];
                object selectedRow2 = (PrxDaraGrid.SelectedItem as DataRowView).Row[2];
                object selectedRow3 = (PrxDaraGrid.SelectedItem as DataRowView).Row[3];
                object selectedRow4 = (PrxDaraGrid.SelectedItem as DataRowView).Row[4];
                tx.Text = Convert.ToString(selectedRow);
                tx1.Text = Convert.ToString(selectedRow2);
                tx2.Text = Convert.ToString(selectedRow3);
                tx3.Text = Convert.ToString(selectedRow4);
            }
        }
    }
}
