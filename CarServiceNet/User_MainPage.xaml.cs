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

namespace CarServiceNet
{
    /// <summary>
    /// Interaction logic for User_MainPage.xaml
    /// </summary>
    public partial class User_MainPage : Page
    {
        List<requests> user_requests = new List<requests>();
        users _user = new users();

        public User_MainPage(String userId)
        {
            InitializeComponent();
            List<users> users = CarServiceDBEntities1.getContext().users.ToList();

            
            foreach (users user in users)
            {
                if (user.userID == userId)
                {
                    _user = user;
                }
            }
        }


        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).allFrame.Content = null;
        }

        private void createRequstBtn_Click(object sender, RoutedEventArgs e)
        {
            userMainFrame.Content = new CreateReqPage(_user.userID);
        }

        private void updateRequstBtn_Click(object sender, RoutedEventArgs e)
        {
            requests selectedRequest = CatalogGrid.SelectedItem as requests;
            userMainFrame.Content = new UpdateRequstPage(selectedRequest);
            
        }

        private void messagesBtn_Click(object sender, RoutedEventArgs e)
        {

            List<String> requestsIDs = new List<String>();

            foreach (requests req in user_requests)
            {
                requestsIDs.Add(req.requestID);
            }

            userMainFrame.Content = new UpdateMessagesPage(requestsIDs);
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            List<requests> requests = CarServiceDBEntities1.getContext().requests.ToList();
            foreach (requests request in requests)
            {
                if (request.clientID == _user.userID)
                {
                    user_requests.Add(request);
                }
            }

            CatalogGrid.ItemsSource = null;
            CatalogGrid.ItemsSource = user_requests;
        }


        private void userMainFrame_ContentRendered(object sender, EventArgs e)
        {
            List<requests> requests = CarServiceDBEntities1.getContext().requests.ToList();
            user_requests.Clear();
            foreach (requests request in requests)
            {
                if (request.clientID == _user.userID)
                {
                    user_requests.Add(request);
                }
            }

            CatalogGrid.ItemsSource = null;
            CatalogGrid.ItemsSource = user_requests;
        }
    }
}
