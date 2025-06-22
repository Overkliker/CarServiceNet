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
    /// Interaction logic for AddMasterPage.xaml
    /// </summary>
    public partial class AddMasterPage : Page
    {
        List<users> masters = new List<users>();
        requests _request = new requests();
        public AddMasterPage(requests request)
        {
            InitializeComponent();

            _request = request;

            foreach (users user in CarServiceDBEntities1.getContext().users.ToList())
            {
                if (user.type == "Автомеханик")
                {
                    masters.Add(user);
                }
            }
            masterCmb.ItemsSource = masters;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {

            users master = masterCmb.SelectedItem as users;

            if (master == null)
            {
                MessageBox.Show("Вы не выбрали мастера");
                return;
            }

            requests request = CarServiceDBEntities1.getContext().requests.Find(_request.requestID);

            changeStatusMessages message = new changeStatusMessages();

            message.timepoint = DateTime.Now.ToString();
            message.oldStatus = request.requestStatus;
            message.newStatus = "В процессе ремонта";
            message.requestID = request.requestID;
            message.id = CheckID.getNewMessageID();

            CarServiceDBEntities1.getContext().changeStatusMessages.Add(message);

            request.masterID = master.userID;
            request.requestStatus = "В процессе ремонта";

            try
            {
                CarServiceDBEntities1.getContext().SaveChanges();
                MessageBox.Show("Автомеханик был успешно добавлен");
                ((Application.Current.MainWindow as MainWindow).allFrame.Content as ManagerMainPage).operatorMainFrame.Content = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ((Application.Current.MainWindow as MainWindow).allFrame.Content as ManagerMainPage).operatorMainFrame.Content = null;
        }
    }
}
