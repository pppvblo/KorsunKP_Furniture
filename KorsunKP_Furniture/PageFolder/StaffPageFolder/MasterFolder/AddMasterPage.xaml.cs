using KorsunKP_Furniture.ClassFolder;
using KorsunKP_Furniture.DataFolder;
using KorsunKP_Furniture.WindowFolder;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KorsunKP_Furniture.PageFolder.StaffPageFolder.MasterFolder
{
    /// <summary>
    /// Логика взаимодействия для AddMasterPage.xaml
    /// </summary>
    public partial class AddMasterPage : Page
    {
        Master master = new Master();
        Address address = new Address();
        public AddMasterPage()
        {
            InitializeComponent();

            StatusWorkMasterCB.ItemsSource = DBEntities.GetContext().StatusWorkMaster.ToList();
        }

        private void SaveMasterBtn_Click(object sender, RoutedEventArgs e)
        {            
            if (string.IsNullOrWhiteSpace(AddLastNameMasterTB.Text) ||
              string.IsNullOrWhiteSpace(AddFirstNameMasterTB.Text) ||
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
                    DBEntities.GetContext().Master.Add(new Master()
                    {
                        LastNameMaster = AddLastNameMasterTB.Text,
                        FirstNameMaster = AddFirstNameMasterTB.Text,
                        MiddleNameMaster = AddMiddleNameMasterTB.Text,
                        DateOfBirthMaster = DateTime.Parse(DateOfBirthMasterTB.Text),
                        EmailMaster = EmailMasterTB.Text,
                        PhoneNumberMaster = PhoneNumberMasterTB.Text,                                            
                        IdStatusWorkMaster = Int32.Parse(StatusWorkMasterCB.SelectedValue.ToString()),
                        PhotoMaster = ImageClass.ConvertImageToByteArray(selectedFileName)
                    });

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

        private void StatusWorkMasterPIC_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //new AddStatusWindow().ShowDialog();
        }

        string selectedFileName = "";


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

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MasterFolder.ListMasterPage());
        }
    }
}

