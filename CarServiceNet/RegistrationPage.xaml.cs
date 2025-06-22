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

namespace CarServiceNet
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        users _user = new users();
        public RegistrationPage()
        {
            InitializeComponent();
            DataContext = _user;
        }

        private void reghBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_user.login == null)
            {
                errors.AppendLine("Некорректное значение логина");
            }
            if (_user.password == null)
            {
                errors.AppendLine("Некорректное значение пароля");
            }
            if (_user.phone == null || _user.phone.Length > 12 || _user.phone.Length < 12)
            {
                errors.AppendLine("Некорректное значение номера телефона");
            }
            if (_user.fio == null)
            {
                errors.AppendLine("Некорректное значение ФИО");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            _user.type = "Заказчик";

            _user.userID = CheckID.getNewUserID();
            CarServiceDBEntities1.getContext().users.Add(_user);

            try
            {
                CarServiceDBEntities1.getContext().SaveChanges();
                (Application.Current.MainWindow as MainWindow).allFrame.Content = null;
                MessageBox.Show("Вы успешно зарегистрировались");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void athBtn_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).allFrame.Content = null;
        }

    }


}
