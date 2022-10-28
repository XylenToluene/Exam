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
using RulbWPF.Db;
using RulbWPF.View;

namespace RulbWPF.MyForms
{
    /// <summary>
    /// Interaction logic for UpdateProductWindow.xaml
    /// </summary>
    public partial class UpdateProductWindow : Window
    {
        public string Name = "";
        public UpdateProductWindow(string name)
        {
            InitializeComponent();
            Name = name;
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            MyContext Db = new MyContext();

            try
            {
                Product pr = new Product();
                pr = Db.Products.Single(x => x.Id == Convert.ToInt32(tbSearch.Text));


                if(pr != null)
                {
                    MessageBox.Show("Продукт найден!");
                    tbNamePrUpdate.Text = pr.Name;
                    tbDescrPrUpdate.Text = pr.Description;
                    tbDiscountPrUpdate.Text = pr.Discount.ToString() ;
                    tbPricePrUpdate.Text = pr.Price.ToString() ;
                    tbManufPrUpdate.Text = pr.Manufacturer;
                }

                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Продукт не найден!");
            }
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            MyContext Db = new MyContext();

            try
            {
                Product pr = new Product();
                pr = Db.Products.Single(x => x.Id == Convert.ToInt32(tbSearch.Text));


                if (pr != null)
                {
                    pr.Name = tbNamePrUpdate.Text;
                    pr.Description = tbDescrPrUpdate.Text;
                    pr.Discount = Convert.ToDouble(tbDiscountPrUpdate.Text);
                    pr.Manufacturer = tbManufPrUpdate.Text;
                    pr.Price = Convert.ToDouble(tbPricePrUpdate.Text);

                    Db.Products.Update(pr);
                    Db.SaveChanges();
                    MessageBox.Show("Продукт успешно обновлен");
                    Clear();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Продукт не найден!");
            }

        }

        public void Clear()
        {
            tbDescrPrUpdate.Clear();
            tbNamePrUpdate.Clear();
            tbManufPrUpdate.Clear();
            tbDiscountPrUpdate.Clear();
            tbPricePrUpdate.Clear();
            tbSearch.Clear();
        }

        private void tbExit_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.tbUserName.Text = Name;
            adminWindow.Show();
            Close();
            
        }
    }
    
}
