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
    /// Логика взаимодействия для AddStatusWorkMasterWindow.xaml
    /// </summary>
    public partial class AddStatusWorkMasterWindow : Window
    {
        public AddStatusWorkMasterWindow()
        {
            InitializeComponent();
        }

        private void BackAddStatusWorkMasterBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddStatusWorkMasterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddStatusTB.Text))
            {
                MBClass.ErrorMB("Поле осталось пустым");
                AddStatusTB.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().StatusWorkMaster.Add(new StatusWorkMaster()
                    {
                        StatusWorkMasterName = AddStatusTB.Text
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Статус добавлен");
                    Close();
                }
                catch(Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }
    }
}
