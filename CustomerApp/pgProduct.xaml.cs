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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CustomerApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgProduct : Page
    {
        private static readonly pgProduct Instance = new pgProduct();

        public pgProduct()
        {
            this.InitializeComponent();
        }

        private clsProducts _Products;

       
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                string lcProductName = e.Parameter.ToString();
                //_Products = await pgMain.ServiceClient.GetArtistAsync(lcProductName);
            }
            else 
                _Products = new clsProducts();
        }

        protected void updateForm()
        {
         //   base.updateForm();
            tbName.Text = _Products.Name.ToString();
            tbQuantity.Text = _Products.Quantity.ToString();
            tbPrice.Text = _Products.Price.ToString();
        }

        protected void pushData()
        {
            //base.pushData();
            _Products.Name = tbName.Text;
            _Products.Quantity = Convert.ToInt16(tbQuantity.Text);
            _Products.Price = Convert.ToDecimal(tbPrice.Text);
        }

        private void EditProduct(clsProducts prProduct)
        {
            if (prProduct != null)
                Frame.Navigate(typeof(pgProductDetails), prProduct);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private async void btnDelete_ClickAsync(object sender, RoutedEventArgs e)
        {
            if (listProductList.SelectedIndex >= 0)
                {
                MessageDialog lcMessageBox = new MessageDialog("Are you sure?");
                //lcMessageBox.Commands.Add(new UICommand("Yes", async x =>
                //{
                    //tbMessages.Text += await ServiceClient.DeleteProductAsync(listProductList.SelectedItem as clsProducts) +'\n';
                //}));
            lcMessageBox.Commands.Add(new UICommand("No"));
            await lcMessageBox.ShowAsync();
            _Products = await ServiceClient.GetCategoryAsync(_Products.Name);
            }
    }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void saveProduct()
        {
            if (tbName.IsEnabled)
            {
                tbMessages.Text +=
                await ServiceClient.InsertProductAsync(_Products) + '\n';
                tbName.IsEnabled = false;
            }
            else
                tbMessages.Text +=
                await ServiceClient.UpdateProductAsync(_Products) + '\n';
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            saveProduct();
        }
    }
}
