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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using RulbWPF.Db;
using RulbWPF.MyForms;

namespace RulbWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btLogIn_Click(object sender, RoutedEventArgs e)
        {
            MyContext Db = new MyContext();


            try
            {
                var user = Db.Users.Include(x => x.Status).Single(x => x.Login == tbLogin.Text 
                && x.Password == tbPassword.Password.ToString() 
                && x.Login.Length == tbLogin.Text.Length 
                && x.Password.Length == tbPassword.Password.Length);


                switch (user.StatusId)
                {
                    case 1:
                        {
                            MessageBox.Show("Успешный вход");
                            UserWindow u = new UserWindow();
                            u.UserName.Text = user.Name;
                            u.Show();
                            Close();
                            break;
                        }
                    case 2:
                        {
                            MessageBox.Show("Успешный вход");
                            ManagerWindow m = new ManagerWindow();
                            m.UserName.Text = user.Name;
                            m.Show();
                            Close();
                            break;
                        }
                    case 3:
                        {
                            MessageBox.Show("Успешный вход");
                            AdminWindow a = new AdminWindow();
                            a.tbUserName.Text = user.Name;
                            a.Show();
                            Close();
                            break;
                        }

                    default:
                        break;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Пользователь не найден");
            }
        }

        private void btLogInGuest_Click(object sender, RoutedEventArgs e)
        {
            GuestWindow g = new GuestWindow();
            g.Show();
            Close();
        }
    }
}
