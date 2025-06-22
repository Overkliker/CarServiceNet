using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace CarServiceNet
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

        private void authBtn_Click(object sender, RoutedEventArgs e)
        {
            //List<users> users = CarServiceDBEntities1.getContext().users.ToList();

            //foreach (users user in  users)
            //{
            //    if (user.login == loginBox.Text && user.password == passwBox.Password) { 
            //        allFrame.Content = new User_MainPage(user.userID);
            //        return;
            //    }
            //}

            //MessageBox.Show("Неверный логин или пароль");

            //allFrame.Content = new ManagerMainPage();
            allFrame.Content = new User_MainPage("8");
        }

        private void regBtn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            allFrame.Content = new RegistrationPage();

        }       
    }
}
