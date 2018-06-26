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
    public partial class frmProductDetails : Form
    {
        public frmProductDetails()
        {
            InitializeComponent();
        }

        public clsProducts _Products;

        public void SetDetails(clsProducts prProducts)
        {
            _Products = prProducts;
            updateForm();
            ShowDialog();
        }

        private async void btnOK_Click(object sender, EventArgs e)
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

        protected virtual bool isValid()
        {
            return true;
        }

        protected virtual void updateForm()
        {
            tbProductName.Text = _Products.Name;
            tbProductName.Enabled = string.IsNullOrEmpty(_Products.Name);
            tbOrigin.Text = _Products.Origin.ToString();
            tbProductCondition.Text = _Products.ProductCondition.ToString();
            tbBrand.Text = _Products.Brand.ToString();
            tbQuantity.Text = _Products.Quantity.ToString();
        }

        protected virtual void pushData()
        {
            _Products.Name = tbProductName.Text;
            _Products.Origin = tbOrigin.Text;
            _Products.ProductCondition = tbProductCondition.Text;
            _Products.Brand = tbBrand.Text;
            _Products.Quantity = Convert.ToUInt16(tbQuantity.Text);
        }
    }
}
