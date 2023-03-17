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
    /// Логика взаимодействия для AddStreetWindow.xaml
    /// </summary>
    public partial class AddStreetWindow : Window
    {
        public AddStreetWindow()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddStreetBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StreetTB.Text))
            {
                MBClass.ErrorMB("Поле осталось пустым");
                StreetTB.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().Street.Add(new Street()
                    {
                        StreetName = StreetTB.Text
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Улица успешно добавлена");
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
