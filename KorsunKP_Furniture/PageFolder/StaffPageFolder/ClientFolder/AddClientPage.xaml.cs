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
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        Client client = new Client();
        public AddClientPage()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientFolder.ListClientPage());
        }

        private void SaveClientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LastNameClientTB.Text))
            {
                MBClass.ErrorMB("Вы оставили поле пустым");
                LastNameClientTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(FirstNameClientTB.Text))
            {
                MBClass.ErrorMB("Вы оставили поле пустым");
                FirstNameClientTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(MiddleNameClientTB.Text))
            {
                MBClass.ErrorMB("Вы оставили поле пустым");
                MiddleNameClientTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PhoneNumberClientTB.Text))
            {
                MBClass.ErrorMB("Вы оставили поле пустым");
                PhoneNumberClientTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(EmailClientTB.Text))
            {
                MBClass.ErrorMB("Вы оставили поле пустым");
                EmailClientTB.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().Client.Add(new Client()
                    {
                        LastNameClient = LastNameClientTB.Text,
                        FistNameClient = FirstNameClientTB.Text,
                        MiddleNameClient = MiddleNameClientTB.Text,
                        PhoneNumberClient = PhoneNumberClientTB.Text,
                        EmailClient = EmailClientTB.Text,
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Клиент успешно добавлен");
                    NavigationService.Navigate(new ClientFolder.ListClientPage());
                }
                catch (Exception ex)
                {

                    MBClass.ErrorMB(ex);
                }
            }
        }
    }
}
