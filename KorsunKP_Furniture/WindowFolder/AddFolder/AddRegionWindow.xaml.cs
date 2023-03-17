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
    /// Логика взаимодействия для AddRegionWindow.xaml
    /// </summary>
    public partial class AddRegionWindow : Window
    {
        public AddRegionWindow()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddRegionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RegionTB.Text))
            {
                MBClass.ErrorMB("Поле осталось пустым");
                RegionTB.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().Region.Add(new Region()
                    {
                        RegionName = RegionTB.Text
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Регион успешно добавлен");
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
