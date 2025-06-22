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
    /// Interaction logic for UpdateRequstPage.xaml
    /// </summary>
    public partial class UpdateRequstPage : Page
    {
        requests _request = new requests();
        public UpdateRequstPage(requests request)
        {
            InitializeComponent();
            _request = request;
            DataContext = _request;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ((Application.Current.MainWindow as MainWindow).allFrame.Content as User_MainPage).userMainFrame.Content = null;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            requests req = CarServiceDBEntities1.getContext().requests.Find(_request.requestID);

            req.carModel = _request.carModel;
            req.carType = _request.carType;
            req.problemDescryption = _request.problemDescryption;

            try
            {
                CarServiceDBEntities1.getContext().SaveChanges();
                MessageBox.Show("Изменения сохранены");
                ((Application.Current.MainWindow as MainWindow).allFrame.Content as User_MainPage).userMainFrame.Content = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
