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
    /// Interaction logic for ManagerMainPage.xaml
    /// </summary>
    public partial class ManagerMainPage : Page
    {
        public ManagerMainPage()
        {
            InitializeComponent();

            CatalogGrid.ItemsSource = CarServiceDBEntities1.getContext().requests.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).allFrame.Content = null;
        }

        private void AddMasterBtn_Click(object sender, RoutedEventArgs e)
        {

            requests request = CatalogGrid.SelectedItem as requests;
            if (request == null)
            {
                MessageBox.Show("Вы не выбрали заявку для привязки Автомеханика");
                return;
            }

            operatorMainFrame.Content = new AddMasterPage(request);
        }

        private void operatorMainFrame_ContentRendered(object sender, EventArgs e)
        {
            CatalogGrid.ItemsSource = CarServiceDBEntities1.getContext().requests.ToList();
        }
    }
}
