using ef.plushlanDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace ef
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ProductCategoriesTableAdapter productCategoriesTableAdapter = new ProductCategoriesTableAdapter();
        ProductsTableAdapter productsTableAdapter = new ProductsTableAdapter();
        CategoriesTableAdapter categoriesTableAdapter = new CategoriesTableAdapter();
        public Window1()
        {
            InitializeComponent();
            ProdDgr.Loaded += (sender, e) =>
            {
                Hidden();
                ProdNameTxB.ItemsSource = productsTableAdapter.GetData();
                ProdNameTxB.DisplayMemberPath = "Name";
                ProdNameTxB.SelectedValuePath = "ProductID";
                ProdDescTxB.ItemsSource = categoriesTableAdapter.GetData();
                ProdDescTxB.DisplayMemberPath = "Name";
                ProdDescTxB.SelectedValuePath = "CategoryID";

            };
        }
        private void Hidden()
        {
            plushlanDataSet.ProductCategoriesDataTable dataTable = new plushlanDataSet.ProductCategoriesDataTable();
            ProdDgr.ItemsSource = productCategoriesTableAdapter.GetDataBy3();
            ProdDgr.Columns[1].Visibility = Visibility.Collapsed;
            ProdDgr.Columns[2].Visibility = Visibility.Collapsed;
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
            if (!(ProdDgr.SelectedItem is DataRowView rowView))
            {
                MessageBox.Show("Вы не выбрали ID!!");
            }
            else
            {
                try
                {
                    int id_prod = (int)rowView["ProductCategoryID"];
                    productCategoriesTableAdapter.DeleteQuery(id_prod);
                    Hidden();
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
                productCategoriesTableAdapter.InsertQuery((int)ProdNameTxB.SelectedValue, (int)ProdDescTxB.SelectedValue);
                Hidden();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при добавлении!");
            }

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (!(ProdDgr.SelectedItem is DataRowView rowView))
            {
                MessageBox.Show("Вы не выбрали ID!");
            }
            else
            {
                try
                {

                    int id_prod = (int)rowView["ProductCategoryID"];
                    productCategoriesTableAdapter.UpdateQuery((int)ProdNameTxB.SelectedValue, (int)ProdDescTxB.SelectedValue, id_prod);
                    Hidden();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при изменении!");
                }

            }
        }
    }
}
