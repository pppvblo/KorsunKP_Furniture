using KorsunKP_Furniture.ClassFolder;
using KorsunKP_Furniture.DataFolder;
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

namespace KorsunKP_Furniture.PageFolder.StaffPageFolder.ClientFolder
{
    /// <summary>
    /// Логика взаимодействия для ListClientPage.xaml
    /// </summary>
    public partial class ListClientPage : Page
    {
        public ListClientPage()
        {
            InitializeComponent();
            ListClientLB.ItemsSource = DBEntities.GetContext().Client.ToList();
        }

        private void AddClientBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientFolder.AddClientPage());
        }

        private void EditClientMI_Click(object sender, RoutedEventArgs e)
        {
            Client client = ListClientLB.SelectedItem as Client;
            VariableClass.IdClient = client.IdClient;
            NavigationService.Navigate(new EditClientPage(ListClientLB.SelectedItem as Client));
        }

        private void DeleteClientMI_Click(object sender, RoutedEventArgs e)
        {
            Client client = ListClientLB.SelectedItem as Client;

            if (MBClass.QuestionMB($"Удалить клиента: \n" +
            $"{client.LastNameClient} {client.FistNameClient} {client.MiddleNameClient}?"))
            {
                DBEntities.GetContext().Client.Remove(ListClientLB.SelectedItem as Client);

                DBEntities.GetContext().SaveChanges();
                ListClientLB.ItemsSource = DBEntities.GetContext().Client.ToList().OrderBy(u => u.LastNameClient);

            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListClientLB.ItemsSource = DBEntities.GetContext().Client.Where(
                    u => u.LastNameClient.StartsWith(SearchTb.Text) ||
                    u.FistNameClient.StartsWith(SearchTb.Text)).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
