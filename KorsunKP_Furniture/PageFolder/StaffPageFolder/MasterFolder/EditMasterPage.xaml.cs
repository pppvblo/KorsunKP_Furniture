using KorsunKP_Furniture.ClassFolder;
using KorsunKP_Furniture.DataFolder;
using Microsoft.Win32;
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

namespace KorsunKP_Furniture.PageFolder.StaffPageFolder.MasterFolder
{
    /// <summary>
    /// Логика взаимодействия для EditMasterPage.xaml
    /// </summary>
    public partial class EditMasterPage : Page
    {
        DataFolder.Master master = new DataFolder.Master();
        public EditMasterPage(Master master)
        {
            InitializeComponent();
            DataContext = master;
            DateOfBirthMasterTB.Text = master.DateOfBirthMaster.ToString();
            StatusWorkMasterCB.ItemsSource = DataFolder.DBEntities.GetContext().StatusWorkMaster.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MasterFolder.ListMasterPage());
        }

        private void PhotoMasterPIC_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.InitialDirectory = "";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                    "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                    "Portable Network Graphic (*.png)|*.png";

                if (op.ShowDialog() == true)
                {
                    selectedFileName = op.FileName;
                    master.PhotoMaster = ImageClass.ConvertImageToByteArray(selectedFileName);
                    ImageMaster.Source = ImageClass.ConvertByteArrayToImage(master.PhotoMaster);
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void SaveMasterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LastNameMasterTB.Text) ||
              string.IsNullOrWhiteSpace(FirstNameMasterTB.Text) ||
              string.IsNullOrWhiteSpace(PhoneNumberMasterTB.Text) ||
              string.IsNullOrWhiteSpace(EmailMasterTB.Text) ||
              (StatusWorkMasterCB.SelectedIndex == -1) ||
              string.IsNullOrWhiteSpace(DateOfBirthMasterTB.Text))
            {
                MBClass.ErrorMB("Заполните все поля");
            }
            else
            {
                try
                {
                    master = DBEntities.GetContext()
                        .Master
                        .FirstOrDefault(u => u.IdMaster == VariableClass.IdMaster);

                    master.LastNameMaster = LastNameMasterTB.Text;
                    master.FirstNameMaster = FirstNameMasterTB.Text;
                    master.MiddleNameMaster = MiddleNameMasterTB.Text;
                    master.DateOfBirthMaster = DateTime.Parse(DateOfBirthMasterTB.Text);
                    master.EmailMaster = EmailMasterTB.Text;
                    master.PhoneNumberMaster = PhoneNumberMasterTB.Text;
                    master.IdStatusWorkMaster = Int32.Parse(StatusWorkMasterCB.SelectedValue.ToString());
                    if(selectedFileName !="")
                    {
                        master.PhotoMaster = ImageClass.ConvertImageToByteArray(selectedFileName);
                    }
                    
                    

                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Сохранено");
                    NavigationService.Navigate(new MasterFolder.ListMasterPage());
                }
                catch (Exception ex)
                {
                    //throw;
                    MBClass.ErrorMB(ex.Message);
                }
            }
        }
        string selectedFileName = "";
    }
}
