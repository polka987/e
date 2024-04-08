using ef.plushlanDataSetTableAdapters;
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

namespace ef
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CategoriesTableAdapter categoriesTableAdapter = new CategoriesTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            BuyerDgr.ItemsSource = categoriesTableAdapter.GetData();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow OneWindow = new MainWindow();
            OneWindow.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (!(BuyerDgr.SelectedItem is DataRowView rowView))
            {
                MessageBox.Show("Вы не выбрали ID!!");
            }
            else
            {
                try
                {
                    int id_buyer = (int)rowView["CategoryID"];
                    categoriesTableAdapter.DeleteQuery(id_buyer);
                    BuyerDgr.ItemsSource = categoriesTableAdapter.GetData();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при удалении");
                }

            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                categoriesTableAdapter.InsertQuery(NameTxB.Text.ToString());
                BuyerDgr.ItemsSource = categoriesTableAdapter.GetData();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при добавлении");
            }

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (!(BuyerDgr.SelectedItem is DataRowView rowView))
            {
                MessageBox.Show("Вы не выбрали ID!!");
            }
            else
            {
                try
                {
                    int id_buyer = (int)rowView["CategoryID"];
                    categoriesTableAdapter.UpdateQuery(NameTxB.Text.ToString(),id_buyer);
                    BuyerDgr.ItemsSource = categoriesTableAdapter.GetData();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при изменении!");
                }

            }
        }
    }
}
