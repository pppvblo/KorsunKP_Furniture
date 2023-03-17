using KorsunKP_Furniture.ClassFolder;
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
using System.Windows.Shapes;

namespace KorsunKP_Furniture.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для MainStaffWindow.xaml
    /// </summary>
    public partial class MainStaffWindow : Window
    {
        public MainStaffWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new PageFolder.StaffPageFolder.OrderFoler.ListOrderPage());
        }


        private void ListOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.StaffPageFolder.OrderFoler.ListOrderPage());
        }

        private void ListMasterBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.StaffPageFolder.MasterFolder.ListMasterPage());
        }



        private void ListFurnitureBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.StaffPageFolder.PriceFolder.ListPricePage());
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ExitBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void ListClientBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.StaffPageFolder.ClientFolder.ListClientPage());
        }
    }
}
