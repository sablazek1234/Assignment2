using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class frmProducts : Form
    {
        private clsProducts _Products;

        public frmProducts()
        {
            InitializeComponent();
        }

        private static Dictionary<string, frmProducts> _ProductFormList =
            new Dictionary<string, frmProducts>();

        public void SetDetails(clsProducts prProducts)
        {
            _Products = prProducts;
            tbProductName.Enabled = string.IsNullOrEmpty(_Products.Name);
            updateForm();
            frmMain.Instance.ProductNameChanged += new frmMain.Notify(updateTitle);
            //updateTitle(_Artist.ArtistList.GalleryName);
            Show();
        }

        public static void Run(string prProductName)
        {
            frmProducts lcProductForm;
            if (string.IsNullOrEmpty(prProductName) ||
            !_ProductFormList.TryGetValue(prProductName, out lcProductForm))
            {
                lcProductForm = new frmProducts();
                if (string.IsNullOrEmpty(prProductName))
                    lcProductForm.SetDetails(new clsProducts());
                else
                {
                    _ProductFormList.Add(prProductName, lcProductForm);
                    lcProductForm.refreshFormFromDB(prProductName);
                }
            }
            else
            {
                lcProductForm.Show();
                lcProductForm.Activate();
            }
        }

        private async void refreshFormFromDB(string prProductName)
        {
            SetDetails(await ServiceClient.GetProductAsync(prProductName));
        }

        protected void updateForm()
        {
            //base.updateForm();
            tbProductName.Text = _Products.Name.ToString();
            tbQuantity.Text = _Products.Quantity.ToString();
            tbPrice.Text = _Products.Price.ToString();
        }

        protected void pushData()
        {
            //base.pushData();
            _Products.Name = tbProductName.Text;
            _Products.Quantity = Convert.ToUInt16(tbQuantity.Text);
            _Products.Price = Convert.ToDecimal(tbPrice.Text);
        }

        private void updateTitle(string prProductName)
        {
            if (!string.IsNullOrEmpty(prProductName))
                Text = "Product Details - " + prProductName;
        }

        private async Task btnOK_ClickAsync(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                if (tbProductName.Enabled)
                    MessageBox.Show(await ServiceClient.InsertProductAsync(_Products));
                else
                    MessageBox.Show(await ServiceClient.UpdateProductAsync(_Products));

                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Boolean isValid()
        {
            return true;
        }
    }
}
