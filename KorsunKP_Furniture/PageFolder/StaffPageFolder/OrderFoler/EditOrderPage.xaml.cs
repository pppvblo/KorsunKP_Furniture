using KorsunKP_Furniture.ClassFolder;
using KorsunKP_Furniture.DataFolder;
using KorsunKP_Furniture.WindowFolder.AddFolder;
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
    /// Логика взаимодействия для EditOrderPage.xaml
    /// </summary>
    public partial class EditOrderPage : Page
    {
        DataFolder.Order order = new DataFolder.Order();
        Address address = new Address();
        public EditOrderPage(Order order)
        {
            InitializeComponent();
            DataContext = order;
            ClientCB.ItemsSource = DBEntities.GetContext().Client.ToList();
            MasterCB.ItemsSource = DBEntities.GetContext().Master.ToList();
            FurnitureCB.ItemsSource = DBEntities.GetContext().Furniture.ToList();
            OrderStatusCB.ItemsSource = DBEntities.GetContext().OrderStatus.ToList();
            RegionCB.ItemsSource = DBEntities.GetContext().Region.ToList();
            CityCB.ItemsSource = DBEntities.GetContext().City.ToList();
            StreetCB.ItemsSource = DBEntities.GetContext().Street.ToList();
            OrderDateTB.Text = order.OrderDate.ToString();
            LoadAddress();
        }

        private void LoadAddress()
        {
            order = DBEntities.GetContext().Order.FirstOrDefault(u => u.IdOrder == VariableClass.IdOrder);
            address = DBEntities.GetContext().Address.FirstOrDefault(a => a.IdAddress == order.IdAddressClient);
            //MessageBox.Show($"Редактирование студента Id" +
            //    $"{order.IdAddressClient}");
            RegionCB.SelectedValue = address.IdRegion;
            CityCB.SelectedValue = address.IdCity;
            StreetCB.SelectedValue = address.IdStreet;
            HouseTB.Text = address.House;
            FrameTB.Text = address.Frame;
            FlatTB.Text = address.Flat;
        }

        private void EditOrder()
        {                     
            order = DBEntities.GetContext().Order.FirstOrDefault(u => u.IdOrder == VariableClass.IdOrder);
            order.IdClient = (int)ClientCB.SelectedValue;
            address = DBEntities.GetContext().Address.FirstOrDefault(a => a.IdAddress == order.IdAddressClient);
            address.IdRegion = (int)RegionCB.SelectedValue;
            address.IdCity = (int)CityCB.SelectedValue;
            address.IdStreet = (int)StreetCB.SelectedValue;
            address.House = HouseTB.Text;
            address.Frame = FrameTB.Text;
            address.Flat = FlatTB.Text;
            order.IdFurniture = (int)FurnitureCB.SelectedValue;
            order.IdMaster = (int)MasterCB.SelectedValue;
            order.OrderNumber = OrderNumberTB.Text;
            order.OrderTime = OrderTimeTB.Text;
            order.OrderDate = (DateTime)OrderDateTB.SelectedDate;
            order.OrderNote = OrderNoteTB.Text;

            DBEntities.GetContext().SaveChanges();

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderFoler.ListOrderPage());
        }

        private void SaveMasterBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((ClientCB.SelectedIndex == -1) ||
               RegionCB.SelectedIndex == -1 ||
               CityCB.SelectedIndex == -1 ||
               StreetCB.SelectedIndex == -1 ||
               FurnitureCB.SelectedIndex == -1 ||
               OrderStatusCB.SelectedIndex == -1 ||
               MasterCB.SelectedIndex == -1 ||
               string.IsNullOrWhiteSpace(OrderNumberTB.Text) ||
               string.IsNullOrWhiteSpace(OrderTimeTB.Text) ||
               string.IsNullOrWhiteSpace(OrderDateTB.Text) ||
               string.IsNullOrWhiteSpace(OrderNoteTB.Text))
            {
                MBClass.ErrorMB("Заполните все поля");
            }
            else
            {
                try
                {

                    EditOrder();

                    MBClass.InfoMB("Сохранено");
                    NavigationService.Navigate(new OrderFoler.ListOrderPage());
                }
                catch (Exception ex)
                {
                    //MBClass.ErrorMB(ex.Message);
                    throw;
                }
            }
        }

        private void RegionPIC_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AddRegionWindow().ShowDialog();
            RegionCB.ItemsSource = DBEntities.GetContext().Region.ToList();
        }

        private void CityPIC_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AddCityWindow().ShowDialog();
            CityCB.ItemsSource = DBEntities.GetContext().City.ToList();
        }

        private void StreetPIC_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AddStreetWindow().ShowDialog();
            StreetCB.ItemsSource = DBEntities.GetContext().Street.ToList();
        }
    }
}
