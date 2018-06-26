using AdminApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class pgProductDetails : Page
    {
        private static readonly pgProductDetails Instance = new pgProductDetails();

        private clsProducts _Products;

        public pgProductDetails()
        {
            this.InitializeComponent();
        }

        private void updatePage(clsProducts prProducts)
        {
            _Products = prProducts;
            tbName.Text = _Products.Name;
            tbName.IsEnabled = string.IsNullOrEmpty(_Products.Name);
            tbOrigin.Text = _Products.Origin.ToString();
            tbProductCondition.Text = _Products.ProductCondition.ToString();
            tbBrand.Text = _Products.Brand.ToString();
            tbQuantity.Text = _Products.Quantity.ToString();
        }

        private void pushData(clsProducts prProducts)
        {
            prProducts = _Products;
            _Products.Name = tbName.Text;
            _Products.Origin = tbOrigin.Text;
            _Products.ProductCondition = tbProductCondition.Text;
            _Products.Brand = tbBrand.Text;
            _Products.Quantity = Convert.ToUInt16(tbQuantity.Text);
            (ctcWorkSpecs.Content as IProductDetailsControl).UpdateControl(prProducts);
        }

        //private async void btnOK_ClickAsync(object sender, RoutedEventArgs e)
        //{
        //    pushData();
        //    if (tbName.IsEnabled)
        //        await ServiceClient.InsertCategoryAsync(_Products);
        //    else
        //        await ServiceClient.UpdateCategoryAsync(_Products);
        //    Frame.GoBack();
        //}

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
