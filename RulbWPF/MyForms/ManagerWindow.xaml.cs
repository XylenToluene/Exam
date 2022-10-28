using System;
using System.Collections.Generic;
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
using RulbWPF.View;
using RulbWPF.Db;
using System.Collections.ObjectModel;

namespace RulbWPF.MyForms
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ObservableCollection<ProductView> ProductViews { get; set; }
        public ManagerWindow()
        {
            InitializeComponent();
            AddProductsInListBox();
        }

        public void AddProductsInListBox()
        {
            MyContext Db = new MyContext();
            ProductViews = new ObservableCollection<ProductView>();

            foreach (var i in Db.Products)
            {
                ProductViews.Add(new ProductView()
                {
                    Name = i.Name,
                    Description = i.Description,
                    Discount = i.Discount,
                    Manufacturer = i.Manufacturer,
                    Price = i.Price,
                    ImagePath = $"\\Images\\{i.ImagePath}",
                    PriceWithSale = i.Price - (i.Price * i.Discount / 100)
                });
            }

            LbProducts.ItemsSource = ProductViews;
        }

        private void tbExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
