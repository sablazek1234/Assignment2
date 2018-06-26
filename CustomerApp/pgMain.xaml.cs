using AdminApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CustomerApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        //private async void Grid_LoadedAsync(object sender, RoutedEventArgs e)
        //{
        //    listProducts.ItemsSource = await ServiceClient.GetCategoryAsync();
        //}

        private void EditProducts()
        {
            if (listProducts.SelectedItem != null)
                Frame.Navigate(typeof(pgProduct), listProducts.SelectedItem);
        }

        private void listProducts_DoubleClick(object sender, SelectionChangedEventArgs e)
        {
            EditProducts();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditProducts();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string lcProduct = Convert.ToString(listProducts.SelectedItem);
            if (!string.IsNullOrEmpty(lcProduct))
            {
                MessageDialog lcMessageBox = new MessageDialog("Are you sure?");
                lcMessageBox.Commands.Add(new UICommand("Yes", async x =>           
                tbMessages.Text = await ServiceClient.DeleteProductAsync(lcProduct) + '\n'));
                lcMessageBox.Commands.Add(new UICommand("No"));
                await lcMessageBox.ShowAsync();
                //listProducts.ItemsSource = await ServiceClient.GetCategoryAsync();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
