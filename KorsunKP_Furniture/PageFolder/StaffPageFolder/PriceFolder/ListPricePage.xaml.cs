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
    /// Логика взаимодействия для ListPricePage.xaml
    /// </summary>
    public partial class ListPricePage : Page
    {
        public ListPricePage()
        {
            InitializeComponent();
            ListFurnitureLB.ItemsSource = DBEntities.GetContext().Furniture.ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListFurnitureLB.ItemsSource = DBEntities.GetContext().Furniture.Where(
                    u => u.FurnitureName.StartsWith(SearchTb.Text)).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void AddFurnitureBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PriceFolder.AddPricePage());
        }

        private void EditFurnitureMI_Click(object sender, RoutedEventArgs e)
        {
            Furniture furniture = ListFurnitureLB.SelectedItem as Furniture;
            VariableClass.IdFurniture = furniture.IdFurniture;
            NavigationService.Navigate(new EditPricePage(ListFurnitureLB.SelectedItem as Furniture));
        }

        private void DeleteFurnitureMI_Click(object sender, RoutedEventArgs e)
        {
            Furniture furniture = ListFurnitureLB.SelectedItem as Furniture;

            if (MBClass.QuestionMB($"Удалить мебель: \n" +
            $"{furniture.FurnitureName}?"))
            {
                DBEntities.GetContext().Furniture.Remove(ListFurnitureLB.SelectedItem as Furniture);

                DBEntities.GetContext().SaveChanges();
                ListFurnitureLB.ItemsSource = DBEntities.GetContext()
                    .Furniture.ToList().OrderBy(u => furniture.FurnitureName);

            }
        }
    }
}
