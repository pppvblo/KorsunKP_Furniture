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
using System.Windows.Shapes;

namespace KorsunKP_Furniture.WindowFolder.AddFolder
{
    /// <summary>
    /// Логика взаимодействия для AddCityWindow.xaml
    /// </summary>
    public partial class AddCityWindow : Window
    {
        public AddCityWindow()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddCityBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CityTB.Text))
            {
                MBClass.ErrorMB("Поле осталось пустым");
                CityTB.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().City.Add(new City()
                    {
                        CityName = CityTB.Text,
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Город успешно добавлен");
                    Close();
                }
                catch (Exception ex)
                {

                    MBClass.ErrorMB(ex);
                }
            }
        }
    }
}
