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

namespace KorsunKP_Furniture.PageFolder.StaffPageFolder.PriceFolder
{
    /// <summary>
    /// Логика взаимодействия для AddPricePage.xaml
    /// </summary>
    public partial class AddPricePage : Page
    {
        Furniture furniture = new Furniture();
        public AddPricePage()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PriceFolder.ListPricePage());
        }

        private void SaveFurnitureBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FurnitureNameTB.Text))
            {
                MBClass.ErrorMB("Вы оставили поле пустым");
                FurnitureNameTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(FurniturePriceTB.Text))
            {
                MBClass.ErrorMB("Вы оставили поле пустым");
                FurniturePriceTB.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().Furniture.Add(new Furniture()
                    {
                        FurnitureName = FurnitureNameTB.Text,
                        FurniturePrice = Convert.ToDecimal(FurniturePriceTB.Text)
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Мебель успешно добавлена");
                    NavigationService.Navigate(new PriceFolder.ListPricePage());
                }
                catch (Exception ex)
                {

                    MBClass.ErrorMB(ex);
                }
            }
        }
    }
}
