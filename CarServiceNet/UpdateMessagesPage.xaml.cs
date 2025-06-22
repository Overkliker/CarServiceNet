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
    /// Interaction logic for UpdateMessagesPage.xaml
    /// </summary>
    public partial class UpdateMessagesPage : Page
    {
        public UpdateMessagesPage(List<String> requestsIDs)
        {
            InitializeComponent();

            List<changeStatusMessages> messages = new List<changeStatusMessages>();

            foreach (changeStatusMessages message in CarServiceDBEntities1.getContext().changeStatusMessages.ToList())
            {
                if (requestsIDs.Contains(message.requestID)){
                    messages.Add(message);
                }
            }

            messagesGrid.ItemsSource = messages.OrderBy(m => m.timepoint);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ((Application.Current.MainWindow as MainWindow).allFrame.Content as User_MainPage).userMainFrame.Content = null;
        }
    }
}
