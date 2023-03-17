using KorsunKP_Furniture.ClassFolder;
using KorsunKP_Furniture.DataFolder;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для EditClientPage.xaml
    /// </summary>
    public partial class EditClientPage : Page
    {
        DataFolder.Client client = new DataFolder.Client();
        public EditClientPage(Client client)
        {
            InitializeComponent();
            DataContext = client;
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
                    client = DBEntities.GetContext()
                    .Client
                    .FirstOrDefault(u => u.IdClient == VariableClass.IdClient);
                    client.LastNameClient = LastNameClientTB.Text;
                    client.FistNameClient = FirstNameClientTB.Text;
                    client.MiddleNameClient = MiddleNameClientTB.Text;
                    client.PhoneNumberClient = PhoneNumberClientTB.Text;
                    client.EmailClient = EmailClientTB.Text;
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Сохранено");
                    NavigationService.Navigate(new ClientFolder.ListClientPage());
                }
                catch (DbEntityValidationException ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientFolder.ListClientPage());
        }
    }
}
