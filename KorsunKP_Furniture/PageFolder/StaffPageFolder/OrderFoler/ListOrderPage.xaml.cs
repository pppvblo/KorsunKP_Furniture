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

namespace KorsunKP_Furniture.PageFolder.StaffPageFolder.OrderFoler
{
    /// <summary>
    /// Логика взаимодействия для ListOrderPage.xaml
    /// </summary>
    public partial class ListOrderPage : Page
    {
        public ListOrderPage()
        {
            InitializeComponent();
            ListOrderLB.ItemsSource = DBEntities.GetContext().Order.ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListOrderLB.ItemsSource = DBEntities.GetContext().Order.Where(
                    u => u.OrderNumber.StartsWith(SearchTb.Text)).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddOrderPage());
        }

        private void EditOrderMI_Click(object sender, RoutedEventArgs e)
        {
            Order order = ListOrderLB.SelectedItem as Order;
            VariableClass.IdOrder = order.IdOrder;
            NavigationService.Navigate(new EditOrderPage(ListOrderLB.SelectedItem as Order));
        }

        private void DeleteOrderMI_Click(object sender, RoutedEventArgs e)
        {
            Order order = ListOrderLB.SelectedItem as Order;

            if (MBClass.QuestionMB($"Удалить заказ: \n" +
            $"{order.OrderNumber}?"))
            {
                DBEntities.GetContext().Order.Remove(ListOrderLB.SelectedItem as Order);

                DBEntities.GetContext().SaveChanges();
                ListOrderLB.ItemsSource = DBEntities.GetContext().Order.ToList().OrderBy(u => u.OrderNumber);

            }
        }
    }
}
