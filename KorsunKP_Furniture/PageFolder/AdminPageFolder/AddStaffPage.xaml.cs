using KorsunKP_Furniture.ClassFolder;
using KorsunKP_Furniture.DataFolder;
using KorsunKP_Furniture.WindowFolder;
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

namespace KorsunKP_Furniture.PageFolder.AdminPageFolder
{
    /// <summary>
    /// Логика взаимодействия для AddStaffPage.xaml
    /// </summary>
    public partial class AddStaffPage : Page
    {
        public AddStaffPage()
        {
            InitializeComponent();
            AddRoleCB.ItemsSource = DBEntities.GetContext().Role.ToList();
        }

        private void AddtStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddLoginTB.Text))
            {
                MBClass.ErrorMB("Введите логин");
                AddLoginTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(AddPasswordTB.Text))
            {
                MBClass.ErrorMB("Введите пароль");
                AddPasswordTB.Focus();
            }
            else if (AddRoleCB.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Выберите роль");
                AddRoleCB.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().User.Add(new User()
                    {
                        Login = AddLoginTB.Text,
                        Password = AddPasswordTB.Text,
                        IdRole = Int32.Parse(AddRoleCB.SelectedValue.ToString())
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Пользователь успешно добавлен");
                    NavigationService.Navigate(new PageFolder.AdminPageFolder.ListStaffPage());
                }
                catch (Exception ex)
                {

                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void Grid_DpiChanged(object sender, DpiChangedEventArgs e)
        {

        }
    }
}
