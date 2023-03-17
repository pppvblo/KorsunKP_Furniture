using KorsunKP_Furniture.ClassFolder;
using KorsunKP_Furniture.DataFolder;
using KorsunKP_Furniture.WindowFolder.AddFolder;
using MaterialDesignColors;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        Order order = new Order();
        Client client = new Client();
        Master master = new Master();
        Furniture furniture = new Furniture();
        Address address = new Address();
        OrderStatus orderStatus = new OrderStatus();
        public AddOrderPage()
        {
            InitializeComponent();

            ClientCB.ItemsSource = DBEntities.GetContext().Client.ToList();
            MasterCB.ItemsSource = DBEntities.GetContext().Master.ToList();
            FurnitureCB.ItemsSource = DBEntities.GetContext().Furniture.ToList();
            OrderStatusCB.ItemsSource = DBEntities.GetContext().OrderStatus.ToList();
            RegionCB.ItemsSource = DBEntities.GetContext().Region.ToList();
            CityCB.ItemsSource = DBEntities.GetContext().City.ToList();
            StreetCB.ItemsSource = DBEntities.GetContext().Street.ToList();
        }

        

        private void OrderAdd()
        {
            
                var addressADD = new Address()
                {

                    IdRegion = Int32.Parse(RegionCB.SelectedValue.ToString()),
                    IdCity = Int32.Parse(CityCB.SelectedValue.ToString()),
                    IdStreet = Int32.Parse(StreetCB.SelectedValue.ToString()),
                    House = HouseTB.Text,
                    Frame = FrameTB.Text,
                    Flat = FlatTB.Text
                };
                DBEntities.GetContext().Address.Add(addressADD);
                DBEntities.GetContext().SaveChanges();
                address.IdAddress = addressADD.IdAddress;
            

            var orderAdd = new Order()
            {
                IdClient = Int32.Parse(ClientCB.SelectedValue.ToString()),
                IdAddressClient = address.IdAddress,
                IdFurniture = Int32.Parse(FurnitureCB.SelectedValue.ToString()),
                IdOrderStatus = Int32.Parse(OrderStatusCB.SelectedValue.ToString()),
                IdMaster = Int32.Parse(MasterCB.SelectedValue.ToString()),
                OrderNumber = OrderNumberTB.Text,
                OrderTime = OrderTimeTB.Text,
                OrderDate = DateTime.Parse(OrderDateTB.Text),
                OrderNote = OrderNoteTB.Text
            };
            DBEntities.GetContext().Order.Add(orderAdd);
            DBEntities.GetContext().SaveChanges();
            order.IdOrder = orderAdd.IdOrder;
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
                    OrderAdd();
                    //AddAddress();

                    MBClass.InfoMB("Заказ добавлен");
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
