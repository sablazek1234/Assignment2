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
    public sealed partial class pgCategory : Page
    {
        private clsCategory _Category;

        public pgCategory()
        {
            this.InitializeComponent();
        }

        protected void updateForm()
        {
            //base.updateForm();
            tbCategory.Text = _Category.CategoryName.ToString();
            tbDescription.Text = _Category.Description.ToString();
        }

        protected void pushData()
        {
            //base.pushData();
            _Category.CategoryName = tbCategory.Text;
            _Category.Description = tbDescription.Text;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
