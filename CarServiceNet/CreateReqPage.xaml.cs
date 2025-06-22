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
    /// Interaction logic for CreateReqPage.xaml
    /// </summary>
    public partial class CreateReqPage : Page
    {
        String _userID;
        requests _request = new requests();
        public CreateReqPage(String userID)
        {
            InitializeComponent();
            DataContext = _request;
            _userID = userID;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {

            String newID = CheckID.getNewRequestID();


            _request.requestID = newID;
            _request.clientID = _userID;
            _request.startDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            _request.requestStatus = "Новая заявка";
            CarServiceDBEntities1.getContext().requests.Add(_request);

            try
            {
                CarServiceDBEntities1.getContext().SaveChanges();
                MessageBox.Show("Заявка успешно сохранена");
                ((Application.Current.MainWindow as MainWindow).allFrame.Content as User_MainPage).userMainFrame.Content = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ((Application.Current.MainWindow as MainWindow).allFrame.Content as User_MainPage).userMainFrame.Content = null;
        }
    }
}
