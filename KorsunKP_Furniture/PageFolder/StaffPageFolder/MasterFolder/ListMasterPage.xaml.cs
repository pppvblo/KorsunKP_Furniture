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

namespace KorsunKP_Furniture.PageFolder.StaffPageFolder.MasterFolder
{
    /// <summary>
    /// Логика взаимодействия для ListMasterPage.xaml
    /// </summary>
    public partial class ListMasterPage : Page
    {
        public ListMasterPage()
        {
            InitializeComponent();
            ListMasterLB.ItemsSource = DBEntities.GetContext().Master.ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListMasterLB.ItemsSource = DBEntities.GetContext().Master.Where(
                    u => u.LastNameMaster.StartsWith(SearchTb.Text) ||
                    u.FirstNameMaster.StartsWith(SearchTb.Text)).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void EditMasterMI_Click(object sender, RoutedEventArgs e)
        {
            Master master = ListMasterLB.SelectedItem as Master;
            VariableClass.IdMaster = master.IdMaster;
            NavigationService.Navigate(new EditMasterPage(ListMasterLB.SelectedItem as Master));
        }

        private void DeleteMasterMI_Click(object sender, RoutedEventArgs e)
        {
            Master master = ListMasterLB.SelectedItem as Master;

            if (MBClass.QuestionMB($"Удалить мастера: \n" +
            $"{master.LastNameMaster} {master.FirstNameMaster} {master.MiddleNameMaster}?"))
            {
                DBEntities.GetContext().Master.Remove(ListMasterLB.SelectedItem as Master);

                DBEntities.GetContext().SaveChanges();
                ListMasterLB.ItemsSource = DBEntities.GetContext().Master.ToList().OrderBy(u => u.LastNameMaster);

            }
        }

        private void AddMasterBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MasterFolder.AddMasterPage());
        }
    }
}
